using SQLEmployee.DLL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.DataAccess
{

    public partial class ClientDetails
    {
        #region Function definations
        public List<EmployeeEntity.ClientDetails> GetClientDetails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ObClientDetList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetClientDetails",
                    new SqlParameter("@ID", null),
                    new SqlParameter("@SearchKeyword", "")))
                    while (dr.Read())
                    {
                        var Date = (dr["Dateofbirth"].ToString()).Split(' ');
                        var DD = Convert.ToDateTime(Date[0]);
                        var FinalDate = DD.ToString("dd'/'MM'/'yyyy");

                        EmployeeEntity.ClientDetails ObClientDet = new EmployeeEntity.ClientDetails();
                        ObClientDet.ID = Convert.ToInt32(dr["ID"]);
                        ObClientDet.Name = Convert.ToString(dr["ClientName"]);
                        ObClientDet.Project = Convert.ToString(dr["ProjectName"]);
                        //ObClientDet.DateOfBirth = Convert.ToDateTime(FinalDate);
                        ObClientDet.Date_OfBirth = FinalDate;
                        ObClientDet.Anniversary = Convert.ToDateTime(dr["Anniversary"]) != Convert.ToDateTime("1753-01-01") ? (Convert.ToDateTime(dr["Anniversary"].ToString())).ToString("d'/'M'/'yyyy") : "";
                        ObClientDet.City = Convert.ToString(dr["City"]);
                        ObClientDet.Email = Convert.ToString(dr["Email"]);
                        ObClientDet.Timezone = Convert.ToString(dr["Timezone"]);
                        ObClientDet.Organisation = Convert.ToString(dr["Organisation"]);
                        ObClientDet.IsActive = Convert.ToBoolean(dr["WorkingState"]);
                        ObClientDet.IconBinder = Convert.ToBoolean(dr["WorkingState"]) == true ? "<i class='glyphicon glyphicon-ok'></i>" : "<i class='glyphicon glyphicon-remove' ></i>";
                        ObClientDet.Contact = (dr["Contact"]).ToString();
                        ObClientDet.Address = (dr["Address"]).ToString();

                        ObClientDetList.Add(ObClientDet);
                    }
                return ObClientDetList;
            }
        }

        public bool DeleteClientDetails(int ID) 
        {
            var Result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_DeleteClietDetails",
                    new SqlParameter("@ID", ID)
                    ))
                    while (dr.Read())
                    {
                        Result = Convert.ToBoolean(dr["Deleted"]);
                    }
            }
            return Result;
        }

        public EmployeeEntity.ClientDetails GetClientById(int Id)
        {
            EmployeeEntity.ClientDetails Client = new EmployeeEntity.ClientDetails();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetClientDetails",
                    new SqlParameter("@ID", Id)))
                    while (dr.Read())
                    {
                        DateTime annivirsary = Convert.ToDateTime(dr["Anniversary"]);

                        Client.ID = Convert.ToInt32(dr["ID"]);
                        Client.Name = dr["ClientName"].ToString();
                        Client.Project = dr["ProjectName"].ToString();
                        Client.Contact = dr["Contact"].ToString();
                        Client.DateOfBirth = Convert.ToDateTime(dr["Dateofbirth"]);
                        Client.Anniversary = (dr["Anniversary"]).ToString();
                        Client.City = dr["City"].ToString();
                        Client.Timezone = dr["Timezone"].ToString();
                        Client.Address = dr["Address"].ToString();
                        Client.Organisation = dr["Organisation"].ToString();
                        Client.IsActive = Convert.ToBoolean(dr["WorkingState"]);
                        Client.Facebook_Link = dr["Facebook"] == null ? "N/A" : dr["Facebook"].ToString();
                        Client.Twitter_Link = dr["Twitter"] == null ? "N/A" : dr["Twitter"].ToString();
                        Client.LinkdIn_Link = dr["LinkdIn"] == null ? "N/A" : dr["LinkdIn"].ToString();
                        Client.Website = dr["Website"] == null ? "N/A" : dr["Website"].ToString();
                        Client.Photo = dr["Photo"] == null ? "N/A" : dr["Photo"].ToString();
                        Client.Remarks = dr["Remarks"] == null ? "N/A" : dr["Remarks"].ToString();
                    }
            }
            return Client;
        }

        public string InsertClient(EmployeeEntity.ClientDetails Model, int? ClientID, bool IsNew = false, string Contactnumber = "", string Email = "") 
        {
            string Result = string.Empty;
            Model.Contact = Contactnumber;
            //EmployeeEntity.ClientDetails Client = new EmployeeEntity.ClientDetails();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                var Anniversary_Date = Convert.ToDateTime(Model.Anniversary);
                var Final_Date = Anniversary_Date.ToString("dd'/'MM'/'yyyy");

                var Date = IsNew ? Convert.ToDateTime(Model.Anniversary) : DateTime.ParseExact(Final_Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                
                // DateTime.ParseExact(Model.Anniversary, "dd/mm/yy", null);
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_InsertClientDetails",
                    new SqlParameter("@ClientID", ClientID),
                    new SqlParameter("@Name", Model.Name),
                    new SqlParameter("@Project", Model.Project),
                    new SqlParameter("@DateOfBirth", Model.DateOfBirth),
                    new SqlParameter("@Anniversary", Date),
                    new SqlParameter("@ContatcNumber", Model.Contact),
                    new SqlParameter("@Email", Email),
                    new SqlParameter("@Address", Model.Address),
                    new SqlParameter("@TimeZone", Model.Timezone),
                    new SqlParameter("@City", Model.City),
                    new SqlParameter("@IsActive", Model.IsActive),
                    new SqlParameter("@Facebook", Model.Facebook_Link),
                    new SqlParameter("@Twitter", Model.Twitter_Link),
                    new SqlParameter("@LinkdIn", Model.LinkdIn_Link),
                    new SqlParameter("@WebSite", Model.Website),
                    new SqlParameter("@Photo", Model.Photo),
                    new SqlParameter("@Remarks", Model.Remarks),
                    new SqlParameter("@IsNew", IsNew),
                    new SqlParameter("@organisation", Model.Organisation)
                ))
                    while (dr.Read())
                    {
                        Result = (dr["Result"]).ToString();
                    }
            }

            return Result;
        }

        public List<EmployeeEntity.Projects> GetProjects()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Projects> ObProjectsList = new List<EmployeeEntity.Projects>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetDataForDropDown",
                    new SqlParameter("@Projects", true)))
                    while (dr.Read())
                    {
                        EmployeeEntity.Projects ObProjects = new EmployeeEntity.Projects();
                        ObProjects.AllProjects = (dr["AllProjects"]).ToString();

                        ObProjectsList.Add(ObProjects);
                    }
                return ObProjectsList;
            }
        }        

        public List<EmployeeEntity.ClientDetails> GetClientNameAndId()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ObProjectsList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetClientNameAndId",
                    null))
                    while (dr.Read())
                    {
                        EmployeeEntity.ClientDetails ObProjects = new EmployeeEntity.ClientDetails();
                        ObProjects.ID = Convert.ToInt32(dr["ClientID"]);
                        ObProjects.Name = Convert.ToString(dr["Name"]);
                        ObProjects.Organisation = Convert.ToString(dr["Organisation"]);
                        ObProjectsList.Add(ObProjects);
                    }
                return ObProjectsList;
            }
        }

        public List<EmployeeEntity.ClientDetails> GetClientDetailsBySearch(string Search)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ClientList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetClientDetails",
                    new SqlParameter("@ID", -2),
                    new SqlParameter("@SearchKeyword", Search)))
                    while (dr.Read())
                    {
                        EmployeeEntity.ClientDetails Clients = new EmployeeEntity.ClientDetails();
                        Clients.ID = Convert.ToInt32(dr["ID"]);
                        Clients.Name = Convert.ToString(dr["ClientName"]);
                        Clients.Project = Convert.ToString(dr["ProjectName"]);
                        Clients.Contact = dr["Contact"].ToString();
                        Clients.DateOfBirth = Convert.ToDateTime(dr["Dateofbirth"]);
                        Clients.Anniversary = (dr["Anniversary"]).ToString();
                        Clients.City = Convert.ToString(dr["City"]);
                        Clients.Email = Convert.ToString(dr["Email"]);
                        Clients.Timezone = Convert.ToString(dr["Timezone"]);
                        Clients.Organisation = Convert.ToString(dr["Organisation"]);
                        Clients.IsActive = Convert.ToBoolean(dr["WorkingState"]);
                        Clients.IconBinder = Convert.ToBoolean(dr["WorkingState"]) == true ? "<i class='glyphicon glyphicon-ok'></i>" : "<i class='glyphicon glyphicon-remove' ></i>";
                        ClientList.Add(Clients);
                    }
                return ClientList;
            }
        }

        public List<EmployeeEntity.ClientDetails> GetClientForBirthday()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ObClientDetList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetClientDetails",
                    new SqlParameter("@ID", null),
                    new SqlParameter("@SearchKeyword", "")))
                    while (dr.Read())
                    {
                        EmployeeEntity.ClientDetails ObClientDet = new EmployeeEntity.ClientDetails();
                        ObClientDet.ID = Convert.ToInt32(dr["ID"]);
                        ObClientDet.Name = Convert.ToString(dr["ClientName"]);
                        ObClientDet.Project = Convert.ToString(dr["ProjectName"]);
                        ObClientDet.DateOfBirth = Convert.ToDateTime(dr["Dateofbirth"]);
                        ObClientDet.Anniversary = Convert.ToDateTime(dr["Anniversary"]) != Convert.ToDateTime("1753-01-01") ? (Convert.ToDateTime(dr["Anniversary"].ToString())).ToString("d'/'M'/'yyyy") : "";
                        ObClientDet.City = Convert.ToString(dr["City"]);
                        ObClientDet.Email = Convert.ToString(dr["Email"]);
                        ObClientDet.Timezone = Convert.ToString(dr["Timezone"]);
                        ObClientDet.Organisation = Convert.ToString(dr["Organisation"]);
                        ObClientDet.IsActive = Convert.ToBoolean(dr["WorkingState"]);
                        ObClientDet.IconBinder = Convert.ToBoolean(dr["WorkingState"]) == true ? "<i class='glyphicon glyphicon-ok'></i>" : "<i class='glyphicon glyphicon-remove' ></i>";
                        ObClientDet.Contact = (dr["Contact"]).ToString();
                        ObClientDet.Address = (dr["Address"]).ToString();

                        ObClientDetList.Add(ObClientDet);
                    }

                //var res = (ObClientDetList).RemoveAll(x => x.Name == "Gursharajit singh hoti");
                return ObClientDetList;
            }
        }

        public List<EmployeeEntity.ClientDetails> GetAMCDetails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ObClientDetList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAMCDetails"))
                    while (dr.Read())
                    {
                        var sd = Convert.ToString(dr["AMCStartDate"]).Split(' ');
                        var sd1 =Convert.ToDateTime(sd[0]);
                        var startdate = sd1.ToString("dd/MM/yyyy");

                        var ed = Convert.ToString(dr["AMCEndDate"]).Split(' ');
                        var ed1= Convert.ToDateTime(ed[0]);
                        var enddate = ed1.ToString("dd/MM/yyyy");

                        EmployeeEntity.ClientDetails ObClientDet = new EmployeeEntity.ClientDetails();
                        ObClientDet.SrNo = Convert.ToInt32(dr["SrNo"]);
                        ObClientDet.ID = Convert.ToInt32(dr["ClientId"]);
                        ObClientDet.Name = Convert.ToString(dr["ClientName"]);
                        ObClientDet.AMCTitle = Convert.ToString(dr["AMCTitle"]);                       
                        ObClientDet.AMCStartDate =Convert.ToDateTime(dr["AMCStartDate"]);
                        ObClientDet.AMCEndDate = Convert.ToDateTime(dr["AMCEndDate"]);
                        ObClientDet.PaymentMode = Convert.ToString(dr["PaymentMode"]);
                        ObClientDet.StartEnddate = startdate + " to " + enddate;
                        ObClientDet.PaymentType= Convert.ToString(dr["PaymentType"]);
                        ObClientDetList.Add(ObClientDet);
                    }
                return ObClientDetList;
            }
        }

        public bool CheckTitleExist(string name, string clientid)
        {
            var Result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[sp_CheckTitleExist]",
                    new SqlParameter("@title", name),
                    new SqlParameter("@Clientid", Convert.ToInt32(clientid))))
                    while (dr.Read())
                    {
                        Result = Convert.ToBoolean(dr["Existed"]);
                    }
            }
            return Result;
        }
        public int AddAMCDetail(EmployeeEntity.ClientDetails client)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertAMCDetail",
                    new SqlParameter("@clientid", client.ID),
                    new SqlParameter("@AMCTitle", client.AMCTitle),
                    new SqlParameter("@AMCStartDate", client.AMCStartDate),
                    new SqlParameter("@AMCEndDate", client.AMCEndDate),
                    new SqlParameter("@PaymentMode", client.PaymentMode),
                   new SqlParameter("@PaymentType", client.PaymentType)
                    ))
                    return 0;
            }

        }
        public bool DeleteAMCDetails(int ID)
        {
            var Result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_DeleteAMCDetails",
                    new SqlParameter("@ID", ID)
                    ))
                    while (dr.Read())
                    {
                        Result = Convert.ToBoolean(dr["Deleted"]);
                    }
            }
            return Result;
        }

        public EmployeeEntity.ClientDetails GetAMCById(int Id)
        {
            EmployeeEntity.ClientDetails Client = new EmployeeEntity.ClientDetails();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAMCById",
                    new SqlParameter("@SrNo", Id)))
                    while (dr.Read())
                    {                        
                        Client.SrNo = Convert.ToInt32(dr["SrNo"]);
                        Client.ID =Convert.ToInt32( dr["ClientId"]);	
                        Client.Name=dr["Name"].ToString();
				        Client.AMCTitle = dr["AMCTitle"].ToString();
				        Client.AMCStartDate = Convert.ToDateTime(dr["AMCStartDate"]);
				        Client.AMCEndDate = Convert.ToDateTime(dr["AMCEndDate"]);
				        Client.PaymentMode = dr["PaymentMode"].ToString();
                        Client.PaymentType=dr["PaymentType"].ToString();
                    }
            }
            return Client;
        }

        public int UpdateAMCDetails(EmployeeEntity.ClientDetails client)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "[sp_UpdateAMCdetail]",
                    new SqlParameter("@clientid", client.ID),
                    new SqlParameter("@SrNo", client.SrNo),
                    new SqlParameter("@AMCTitle", client.AMCTitle),
                    new SqlParameter("@AMCStartDate", client.AMCStartDate),
                    new SqlParameter("@AMCEndDate", client.AMCEndDate),
                    new SqlParameter("@PaymentMode", client.PaymentMode), 
                    new SqlParameter("@PaymentType", client.PaymentType)
                    ))
                    return 0;
            }

        }
        public List<EmployeeEntity.ClientDetails> BindAMCdetails(int Id)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ObClientDetList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetClientAMC",
                     new SqlParameter("@ClientId", Id)))
                    while (dr.Read())
                    {               
                        EmployeeEntity.ClientDetails ObClientDet = new EmployeeEntity.ClientDetails();
                        ObClientDet.SrNo = Convert.ToInt32(dr["SrNo"]);                   
                        ObClientDet.AMCTitle = Convert.ToString(dr["AMCTitle"]);
                        ObClientDetList.Add(ObClientDet);
                    }
                return ObClientDetList;
            }
        }
        public int AddInvoiceDetail(EmployeeEntity.ClientDetails client)
        {
            
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_InsertInvoiceDetail",
                    new SqlParameter("@AMCId", client.SrNo),
                    new SqlParameter("@InvoiceGeneratedate", client.InvoiceGeneratedate),
                    new SqlParameter("@InvoiceNo", client.InvoiceNo),                    
                    new SqlParameter("@InvoiceSent", client.InvoiceSent),
                    new SqlParameter("@InvoiceDispatchNo", client.InvoiceDispatchNo),
                    new SqlParameter("@InvoiceSentDate", client.InvoiceSentDate),
                    new SqlParameter("@PaymentReceived", client.PaymentReceived),
                    new SqlParameter("@PaymentReceivedDate", client.PaymentReceivedDate),
                    new SqlParameter("@Description", client.Description)))
                    return 0;
            }

        }
        public List<EmployeeEntity.ClientDetails> BindInvoiceGrid(int SrNo)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ObClientDetList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetInvoiceDetails",
                    new SqlParameter("@SrNo", SrNo)))
                    while (dr.Read())
                    {
                        EmployeeEntity.ClientDetails ObClientDet = new EmployeeEntity.ClientDetails();
                        ObClientDet.InvoiceId = Convert.ToInt32(dr["InvoiceId"]);
                        ObClientDet.SrNo = Convert.ToInt32(dr["SrNo"]);
                        ObClientDet.AMCTitle = Convert.ToString(dr["AMCTitle"]);
                        ObClientDet.InvoiceNo = Convert.ToString(dr["InvoiceNo"]);
                        ObClientDet.InvoiceGeneratedate = Convert.ToString(dr["InvoiceGeneratedate"]);
                        if (dr["InvoiceSent"].ToString() == "Yes")
                        {
                            ObClientDet.InvoiceSent = Convert.ToString(dr["InvoiceSentDate"]);
                        }
                        else
                        {
                            ObClientDet.InvoiceSent = Convert.ToString(dr["InvoiceSent"]);
                        }
                        ObClientDet.InvoiceDispatchNo = Convert.ToString(dr["InvoiceDispatchNo"]);
                        if (dr["PaymentReceived"].ToString() == "Yes")
                        {
                            ObClientDet.PaymentReceived = Convert.ToString(dr["PaymentReceivedDate"]);
                        }
                        else
                        {
                            ObClientDet.PaymentReceived = Convert.ToString(dr["PaymentReceived"]);
                        }
                        ObClientDet.Description = Convert.ToString(dr["Description"]);
                        ObClientDetList.Add(ObClientDet);
                    }
                return ObClientDetList;
            }
        }

        public bool DeleteInvoiceDetail(int InvoiceID)
        {
            var Result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_DeleteInvoiceDetail",
                    new SqlParameter("@InvoiceID", InvoiceID)
                    ))
                    while (dr.Read())
                    {
                        Result = Convert.ToBoolean(dr["Deleted"]);
                    }
            }
            return Result;
        }
        public EmployeeEntity.ClientDetails GetInvoiceById(int InvoiceId)
        {
            EmployeeEntity.ClientDetails Client = new EmployeeEntity.ClientDetails();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetInvoiceById",
                    new SqlParameter("@InvoiceId", InvoiceId)))
                    while (dr.Read())
                    {
                        Client.InvoiceId = Convert.ToInt32(dr["InvoiceId"]);
                        Client.SrNo = Convert.ToInt32(dr["AMCId"]);
                        Client.Name = dr["Name"].ToString();
                        Client.AMCTitle = dr["AMCTitle"].ToString();
                        Client.InvoiceGeneratedate = dr["InvoiceGeneratedate"].ToString();
                        Client.InvoiceNo = dr["InvoiceNo"].ToString();
                        Client.PaymentReceivedDate = dr["PaymentReceivedDate"].ToString();
                        if (dr["PaymentReceived"].ToString() == "")
                        {
                            Client.PaymentReceived = "No";
                        }
                        else
                        {
                            Client.PaymentReceived = dr["PaymentReceived"].ToString();
                        }
                        if (dr["InvoiceSent"].ToString() == "")
                        {
                            Client.InvoiceSent = "No";
                        }
                        else
                        {
                            Client.InvoiceSent = dr["InvoiceSent"].ToString();
                        }
                        Client.InvoiceSentDate = dr["InvoiceSentDate"].ToString();
                        Client.InvoiceDispatchNo = dr["InvoiceDispatchNo"].ToString();
                        Client.Description= dr["Description"].ToString();
                    }
            }
            return Client;
        }
        public int UpdateInvoiceDetails(EmployeeEntity.ClientDetails client)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "[sp_UpdateInvoicedetail]",
                    new SqlParameter("@InvoiceId", client.InvoiceId),
                    new SqlParameter("@AMCId", client.SrNo),
                    new SqlParameter("@InvoiceGeneratedate", client.InvoiceGeneratedate),
                    new SqlParameter("@InvoiceNo", client.InvoiceNo),                    
                    new SqlParameter("@InvoiceSent", client.InvoiceSent),
                    new SqlParameter("@InvoiceDispatchNo", client.InvoiceDispatchNo),
                    new SqlParameter("@InvoiceSentDate", client.InvoiceSentDate),
                    new SqlParameter("@PaymentReceived", client.PaymentReceived),
                    new SqlParameter("@PaymentReceivedDate", client.PaymentReceivedDate),
                    new SqlParameter("@Description", client.Description)
                    ))
                    return 0;
            }

        }
        public bool CheckNameExist(string Clientname, string Organisation)
        {
            var Result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[sp_CheckClientName]",
                    new SqlParameter("@Clientname", Clientname),
                    new SqlParameter("@Organisation", Organisation)))
                    while (dr.Read())
                    {
                        Result = Convert.ToBoolean(dr["Existed"]);
                    }
            }
            return Result;
        }
        public bool  CheckDispatchNo(string dispatchNo)
        {
            var Result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[sp_CheckDispatchNo]",
                    new SqlParameter("@dispatchNo", dispatchNo)))
                    while (dr.Read())
                    {
                        Result = Convert.ToBoolean(dr["Existed"]);
                    }
            }
            return Result;
        }

        public bool CheckInvoiceNo(string invoiceno)
        {
            var Result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[sp_CheckInvoiceNo]",
                    new SqlParameter("@invoiceno", invoiceno)))
                    while (dr.Read())
                    {
                        Result = Convert.ToBoolean(dr["Existed"]);
                    }
            }
            return Result;
        }
        public List<EmployeeEntity.ClientDetails> CheckPaymentreceived()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ObClientDetList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[sp_paymentreceived]"))
                    while (dr.Read())
                    {
                        EmployeeEntity.ClientDetails ObClientDet = new EmployeeEntity.ClientDetails();
                        ObClientDet.Name= Convert.ToString(dr["Name"]);
                        ObClientDet.AMCTitle = Convert.ToString(dr["AMCTitle"]);
                        ObClientDet.InvoiceDispatchNo = Convert.ToString(dr["InvoiceDispatchNo"]);
                        ObClientDet.InvoiceSentDate = Convert.ToString(dr["InvoiceSentDate"]);
                        ObClientDet.InvoiceId = Convert.ToInt32(dr["InvoiceId"]);
                        ObClientDetList.Add(ObClientDet);
                    }
                return ObClientDetList;
            }
        }
        public int updatePaymentDate(string invoiceid, string paymentdate)
        {           
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[sp_UpdatePaymentDate]",
                    new SqlParameter("@invoiceid", Convert.ToInt32(invoiceid)),
                    new SqlParameter("@paymentdate", paymentdate)))
                    while (dr.Read())
                    {
                        return 0;
                    }
            }
            return 0;
        }
        public List<EmployeeEntity.ClientDetails> CheckInvoicenotSent()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ClientDetails> ObClientDetList = new List<EmployeeEntity.ClientDetails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[sp_InvoicenotSent]"))
                    while (dr.Read())
                    {
                        EmployeeEntity.ClientDetails ObClientDet = new EmployeeEntity.ClientDetails();
                        ObClientDet.Name = Convert.ToString(dr["Name"]);
                        ObClientDet.AMCTitle = Convert.ToString(dr["AMCTitle"]);
                        ObClientDet.InvoiceGeneratedate= Convert.ToString(dr["InvoiceGeneratedate"]);
                        ObClientDet.InvoiceNo = Convert.ToString(dr["InvoiceNo"]);
                        ObClientDet.InvoiceSentDate = Convert.ToString(dr["InvoiceSentDate"]);
                        ObClientDet.InvoiceId = Convert.ToInt32(dr["InvoiceId"]);
                        ObClientDetList.Add(ObClientDet);
                    }
                return ObClientDetList;
            }
        }
        public int updateInvoiceSentDate(string invoiceid, string InvoiceSentDate,string DispatchNo)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[sp_updateInvoiceSentDate]",
                    new SqlParameter("@invoiceid", Convert.ToInt32(invoiceid)),
                    new SqlParameter("@InvoiceSentDate", InvoiceSentDate),
                    new SqlParameter("@DispatchNo", DispatchNo)
                    ))
                    while (dr.Read())
                    {
                        return 0;
                    }
            }
            return 0;
        }

        #endregion
    }
}
