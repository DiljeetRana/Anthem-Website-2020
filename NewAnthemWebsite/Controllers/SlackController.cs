using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Web.UI.WebControls;
using SlackAPI;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using NewAnthemWebsite;
using System.Globalization;
using AnthemEntities;
using AnthermBLL;
using NLog;
using System.Drawing;
using System.Web.UI;
using WebGrease.Activities;
using System.Collections.Specialized;
using System.Security.Policy;
using Newtonsoft.Json.Serialization;
using System.Web.Helpers;

namespace MySlackApp.Controllers
{
    public class SlackController : Controller
    {
        AnthemEntities.SlackEntity slackleave = new AnthemEntities.SlackEntity();
        SlackBLL slackbll = new SlackBLL();
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        private static readonly HttpClient client = new HttpClient();
        NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        string triggerId = string.Empty;
        // code added y nitya 04/03

        [HttpPost]
        public async Task<ActionResult> MySlashCommand()
        {
            var responseContent = "";
            // Get the current date
            //string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            string currentDate = indianTime.ToString("yyyy-MM-dd");
            // logger.Info("Slash Command");
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;
                // Define the Block Kit Builder view modal
                string text = @"
            {
                'title': {
                'type': 'plain_text',
		'text': 'Apply Leave'


    },
	'submit': {
                'type': 'plain_text',
		'text': 'Submit',
        
        

    },
	
	'blocks': [
		{
			'type': 'input',
            'block_id': 'start_date',
			'element': {
				'type': 'datepicker',
				'initial_date': '2023-01-01',
				'placeholder': {
					'type': 'plain_text',
					'text': 'Select a date',
					'emoji': true
				},
				'action_id': 'start_date_action'
			},
			'label': {
				'type': 'plain_text',
				'text': 'Start Date',
				'emoji': true
			}
		},
		{
			'type': 'input',
            'block_id': 'end_date',
			'element': {
				'type': 'datepicker',
				'initial_date': '2023-01-01',
				'placeholder': {
					'type': 'plain_text',
					'text': 'Select a date',
					'emoji': true
				},
				'action_id': 'end_date_action'
			},
			'label': {
				'type': 'plain_text',
				'text': 'End Date',
				'emoji': true
			}
		},
		{
			'type': 'input',
            'block_id': 'leave_type',
			'element': {
				'type': 'static_select',
				'placeholder': {
					'type': 'plain_text',
					'text': 'Select options',
					'emoji': true
				},
				'options': [
					{
						'text': {
							'type': 'plain_text',
							'text': 'Is Full Day',
							'emoji': true
						},
						'value': 'value-0'
					},
					{
						'text': {
							'type': 'plain_text',
							'text': 'Is Half Day',
							'emoji': true
						},
						'value': 'value-1'
					}
				],
				'action_id': 'leave_type_action',
                ""initial_option"": {
					""text"": {
						""type"": ""plain_text"",
						""text"": ""Is Full Day""
					},
					""value"": ""value-0""
				}
			},
			'label': {
				'type': 'plain_text',
				'text': 'Leave Type',
				'emoji': true
			}
		},
		{
			'type': 'input',
            'block_id': 'leave_reason',
			'element': {
				'type': 'plain_text_input',
				'multiline': true,
				'action_id': 'reason_action'
			},
			'label': {
				'type': 'plain_text',
				'text': 'Reason For Leave',
				'emoji': true
			}
		}
	],

	'type': 'modal',
'callback_id': 'my_form_submission'
}";
                dynamic abc = JsonConvert.DeserializeObject(text);
                // string sDate = abc["start_date"]["element"]["initial_date"].Value<string>();
                abc.blocks[0].element.initial_date= currentDate;
                abc.blocks[1].element.initial_date = currentDate;
                text = JsonConvert.SerializeObject(abc); 
                //logger.Info(text);
                triggerId = Request.Form["trigger_id"];
                string token = ConfigurationManager.AppSettings["SLACK_ACCESS_TOKEN"];
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //logger.Info("trigger_id");
                //logger.Info($"{triggerId}");

                var formData = new MultipartFormDataContent();
                formData.Add(new StringContent(triggerId), "trigger_id");
                formData.Add(new StringContent(text), "view");
                var response = await client.PostAsync("https://slack.com/api/views.open", formData);
                // Create an HTTP client and send a POST request to the Slack API's views.open endpoint
                // Return the response content as a JSON object
                responseContent = await response.Content.ReadAsStringAsync();
                //logger.Info(responseContent);
            }
            catch (Exception ex)
            {
                logger.Error("MySlashCommand-  " + ex);
                throw;
            }
            return Json(null);

        }


      
        [HttpPost]
        public async Task<ActionResult> SubmitForm(Slack s)
        {
            
            try
            {
                //new code 11/03/23
                string payload = Request.Form["payload"];
                //logger.Info(payload);
                JObject parsedPayload = JObject.Parse(payload);
                string userId = parsedPayload["user"]["id"].ToString();
                //parsedPayload["user"]["name"].ToString();
                string viewId = parsedPayload["view"]["id"].ToString();
                var email = await GetUserEmail(userId);
                var userInfo = await GetUserInfo(userId);
                //var email = userInfo.email;
                var userDisplayName = userInfo;
                string userName = userDisplayName;
                //logger.Info("Email:- "+email+ " Display Name:- " + userDisplayName);  
                string triggerId = parsedPayload["trigger_id"].ToString();
                string viewHash = parsedPayload["view"]["hash"].ToString();

                JToken inputs = parsedPayload["view"]["state"]["values"];

                string startDate = inputs["start_date"]["start_date_action"]["selected_date"].Value<string>();
                string endDate = inputs["end_date"]["end_date_action"]["selected_date"].Value<string>();
                string leaveType = inputs["leave_type"]["leave_type_action"]["selected_option"]["text"]["text"].Value<string>();
                string Reason = inputs["leave_reason"]["reason_action"]["value"].Value<string>();

                //string inputDate = "2023-03-28";
                DateTime s_date = DateTime.Parse(startDate); // Convert the string to a DateTime object
                string outputSDate = s_date.ToString("dd/MM/yyyy"); // Convert the DateTime object to the desired format
                DateTime e_date = DateTime.Parse(endDate); // Convert the string to a DateTime object
                string outputEDate = s_date.ToString("dd/MM/yyyy");
                logger.Info(outputEDate);
                DateTime start_date = DateTime.ParseExact(outputSDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime end_date = DateTime.ParseExact(outputEDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                var day1 = start_date.Day;
                var day2 = end_date.Day;
                var year1 = start_date.Year;
                var year2 = end_date.Year;
                var month1 = start_date.Month;
                var month2 = end_date.Month;

                //int userId = Convert.ToInt16(Session["userId"]);
                //employees.EmployeeId = userId;


                if (year1 > year2)
                {
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('End Date must be greater then Start Date')", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "validateDate();", true);
                    //txtto.Text = string.Empty;
                    //btnsubmit.Focus();
                }
                else
                {
                    if (year1 == year2)
                    {
                        if (month1 > month2)
                        {
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('End Date must be greater then Start Date')", true);
                            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "validateDate();", true);
                            //txtto.Text = string.Empty;
                            //btnsubmit.Focus();
                        }
                        else
                        {
                            if (month1 == month2)
                            {
                                if (day1 > day2)
                                {
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('End Date must be greater then Start Date')", true);
                                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "validateDate();", true);
                                    //txtto.Text = string.Empty;
                                    //btnsubmit.Focus();
                                }
                                else
                                {
                                   slackleave= InsertDetails(start_date.ToString("dd/MM/yyyy"), end_date.ToString("dd/MM/yyyy"), leaveType, Reason, email);

                                }
                            }
                            else
                            {
                                slackleave = InsertDetails(start_date.ToString("dd/MM/yyyy"), end_date.ToString("dd/MM/yyyy"), leaveType, Reason, email);

                            }
                        }
                    }
                    else
                    {
                        slackleave = InsertDetails(start_date.ToString("dd/MM/yyyy"), end_date.ToString("dd/MM/yyyy"), leaveType, Reason, email);

                    }
                }
                //btnsubmit.Focus();
                sendmail(email, userName, slackleave);
                await SendMessageToSlackAsync(slackleave,userName,email);
                //await SlackAction(viewId);

                //await CloseDialog(viewId);

                //end new code 11/03/23

            }
            catch (Exception ex)
            {

                logger.Info("Exception :-" + ex);
            }
            
            return Content(null);

        }

        SlackEntity InsertDetails(string startDate, string endDate, string leaveType, string reason, string email)
        {
            //slackleave.EmployeeId = Convert.ToInt16(Session["userId"]);
            //slackleave.StartDate = startDate;
            //slackleave.EndDate = endDate;
            logger.Info(startDate+ " " + endDate);
            
            string noOfDays = "1";
            if (leaveType == "2")
            {
                DateTime start_date = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime end_date = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //noOfDays = ((end_date - start_date).TotalDays + 0.5).ToString();
            }
            else
            {
                DateTime start_date = DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime end_date = DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //noOfDays = ((end_date - start_date).TotalDays + 1).ToString();
            }
            int userId = Convert.ToInt16(Session["userId"]);
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
            slackleave.Email = email;
            slackleave.StartDate = startDate;
            slackleave.EndDate = endDate;
            slackleave.Reason = reason;
            slackleave.NoOfDays = noOfDays;
            slackleave.Creation = indianTime;
            //logger.Info(slackleave.StartDate);
            slackbll.InsertLeaveDetails(slackleave);
            return slackleave;
            
        }

        [HttpPost]
        public ActionResult ReceiveFormSubmission()
        {
            // Parse the request body to get the event data
            string requestBody = new StreamReader(Request.InputStream).ReadToEnd();
            var data = JsonConvert.DeserializeObject<dynamic>(requestBody);
            var eventData = data["event"];
            // Extract the form submission data
            var formSubmission = eventData["submission"];
            string firstName = formSubmission["first_name"];
            string lastName = formSubmission["last_name"];
            string email = formSubmission["email"];

            // Process the form submission as necessary
            // For example, save the data to a database
            //SaveFormSubmission(firstName, lastName, email);
            // Return a response to acknowledge receipt of the event
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        public async Task<string> GetUserInfo(string userId)
        {
            var accessToken = ConfigurationManager.AppSettings["SLACK_ACCESS_TOKEN"];
            var client = new HttpClient();
            var url = $"https://slack.com/api/users.info?user={userId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            //logger.Info(responseContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get user info: {responseContent}");
            }

            var jsonObject = JObject.Parse(responseContent);
            var user = jsonObject["user"]["profile"];

            //var email = user.Value<string>("email");
            var displayName = user.Value<string>("display_name");

            return displayName;
        }
        private async Task<string> GetUserEmail(string userId)
        {
            var apiUrl = "https://slack.com/api/users.info";
            var accessToken = ConfigurationManager.AppSettings["SLACK_ACCESS_TOKEN"];
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var request = new HttpRequestMessage(HttpMethod.Get, $"{apiUrl}?user={userId}");
            var response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            SlackUserInfoResponse userInfo = JsonConvert.DeserializeObject<SlackUserInfoResponse>(json);            
            return userInfo.User.Profile.Email;
        }

        public class SlackUserInfoResponse
        {
            public bool Ok { get; set; }
            public SlackUser User { get; set; }
        }

        public class SlackUser
        {
            public string Id { get; set; }
            public SlackUserProfile Profile { get; set; }
        }

        public class SlackUserProfile
        {
            public string Email { get; set; }
            
        }

        //end

        //this function will post message into channel
        public async Task SendMessageToSlackAsync(SlackEntity s,string userName,string email)
        {
            try
            {
                userName = char.ToUpper(userName[0]) + userName.Substring(1);
                // Define the webhook URL and message payload
                string url = "https://hooks.slack.com/services/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";
                string channel = "#anthem_leaves";
                string message =string.Empty;
                string employeeName =userName;
                string employeeEmail =email;

                //DateTime sdt = DateTime.ParseExact(s.StartDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                string startDate = s.StartDate;//sdt.ToString("dd/MM/yyyy");
                //DateTime edt = DateTime.ParseExact(s.EndDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                string endDate = s.EndDate;//edt.ToString("dd/MM/yyyy");
                string noOfDays = s.NoOfDays;
                string reason = s.Reason;
                message = "Leave has been successfully applied by "+employeeName+" from " + startDate + " to " + endDate + " for a duration of " + noOfDays + " day(s), and the reason for the leave is \'" + reason +"\'.";
                //logger.Info(message);
                string payload = $"{{ \"channel\": \"{channel}\", \"text\": \"{message}\" }}";

                // Set up an HttpClient instance
                HttpClient httpClient = new HttpClient();

                // Set the content type header to application/json
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Send the POST request to the webhook URL
                HttpResponseMessage response = await httpClient.PostAsync(url, new StringContent(payload, Encoding.UTF8, "application/json"));
                //logger.Info(response);
                // Print the response from Slack's API
                string responseBody = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(responseBody);
            }
            catch (Exception ex)
            {

                logger.Info(ex);
            }
        }

        //Send Email during the time of Leave Apply
        void sendmail(string email, string employeeName, SlackEntity s)
        {

            try
            {
                var To_result = ConfigurationManager.AppSettings["TO_Email"].ToString();
                var CC_result = ConfigurationManager.AppSettings["CC_Email"].ToString();
                string smptServer = ConfigurationManager.AppSettings["SlackSMTPServer"].ToString();
                string userName = ConfigurationManager.AppSettings["senderemail"].ToString();
                string userPassword = ConfigurationManager.AppSettings["senderpassword"].ToString();
                int smtpport = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"].ToString());
                MailMessage mm = new MailMessage();

                mm.To.Add(To_result);
                mm.CC.Add(CC_result);
                mm.Subject = "Leave Request From " + employeeName;
                string str = string.Empty;

                str = " Respected Sir,<br /><br /> I will not be able to make out to office from " + s.StartDate + " to " + s.EndDate + " for " + s.NoOfDays+ " days. <br /><br /> Reason for this leave is :<br /> " + s.Reason + "<br /><br /> Please allow me for the same .<br /> Regards <br /> " + employeeName;

                MailAddress fromAddress = new MailAddress("management@antheminfotech.net");
                mm.From = fromAddress;
                mm.Body = str.ToString();
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = smptServer;
                smtp.EnableSsl = false;
                //smtp.UseDefaultCredentials = true;
                NetworkCredential NetworkCred = new NetworkCredential(userName, userPassword);

                smtp.Credentials = NetworkCred;
                smtp.Port = smtpport;
                smtp.Timeout = 200000;
                smtp.Send(mm);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }         
            
        }

    }
}
