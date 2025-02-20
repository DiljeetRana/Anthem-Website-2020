#region Name Spaces

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AnthemEntites;

#endregion

namespace AnthemDLL.DataAccess
{
    public partial class Project
    {

        #region Sql Operations

        public List<Projects> GetAllProjects()
        {
            using (ADOExecution exec = new ADOExecution(GetConnectionString()))
            {
                List<AnthemEntites.Projects> projectsList = new List<AnthemEntites.Projects>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAllProjects",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Projects ProjectData = new AnthemEntites.Projects();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        projectsList.Add(ProjectData);
                    }
                return projectsList;
            }
        }
        //public List<Projects> technology()
        //{
        //    using (ADOExecution exec = new ADOExecution(GetConnectionString()))
        //    {
        //        List<AnthemEntites.Projects> projectsList = new List<AnthemEntites.Projects>();
        //        using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAllProjects",
        //            null))
        //            while (dr.Read())
        //            {
        //                AnthemEntites.Projects ProjectData = new AnthemEntites.Projects();
        //                ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
        //                ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
        //                ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
        //                ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
        //                ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
        //                ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
        //                ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
        //                projectsList.Add(ProjectData);
        //            }
        //        return projectsList;
        //    }
        //}

        public List<Projects> GetAllProjectsByQuerystring(string s)
        {
            using (ADOExecution exec = new ADOExecution(GetConnectionString()))
            {
                List<AnthemEntites.Projects> projectsList = new List<AnthemEntites.Projects>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetallProjectThroughQuerystring",
                      new SqlParameter("@ProjectCategory", s)))
                    while (dr.Read())
                    {
                        AnthemEntites.Projects ProjectData = new AnthemEntites.Projects();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        projectsList.Add(ProjectData);
                    }
                return projectsList;
            }
        }

        //public AnthemEntites.Projects GetProjectDetailsByProjectName(string projectName)
        //{
        //    using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
        //    {
        //        AnthemEntites.Projects ProjectData = new AnthemEntites.Projects();
        //        using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetProjectDetailsByProjectName",
        //            new SqlParameter("@projectName", projectName)))
        //            while (dr.Read())
        //            {

        //                ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
        //                ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
        //                ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
        //                ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
        //                ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
        //                ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
        //                ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
        //                ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
        //                ProjectData.Description = Convert.ToString(dr["Description"]);
        //                ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
        //                ProjectData.URL = Convert.ToString(dr["URL"]);

        //            }
        //        return ProjectData;
        //    }
        //}

        public AnthemEntites.Projects GetProjectDetailsByProjectName(string projectName)
        {
            // Create a task and wait synchronously for its completion
            Task<AnthemEntites.Projects> task = GetProjectDetailsByProjectNameAsync(projectName);
            task.Wait(); // This blocks the current thread until the task is completed
            return task.Result; // Retrieve the result of the completed task
        }

        public async Task<AnthemEntites.Projects> GetProjectDetailsByProjectNameAsync(string projectName)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                AnthemEntites.Projects ProjectData = new AnthemEntites.Projects();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetProjectDetailsByProjectName",
                    new SqlParameter("@projectName", projectName)))
                {
                    while (dr.Read())
                    {
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);

                        //string url = Convert.ToString(dr["URL"]);
                        //if (!string.IsNullOrEmpty(url))
                        //{
                        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                        //WebRequest webRequest = WebRequest.Create(url);
                        //WebResponse webResponse;
                        //try
                        //{
                        //    webResponse = webRequest.GetResponse();
                        //}
                        //catch //If exception thrown then couldn't get response from address
                        //{
                        //    Console.WriteLine("An error occurred5: ");

                        //}


                        //try
                        //    {
                        //           using (var client = new WebClient())
                        //    {
                        //        string content = client.DownloadString(url);
                        //        Console.WriteLine("URL is valid and exists.");
                        //    }

                        //    }

                        //catch (WebException ex)
                        //{
                        //    if (ex.Status == WebExceptionStatus.ProtocolError)
                        //    {
                        //        Console.WriteLine("URL is not valid or does not exist (HTTP error).");
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("An error occurred5: " + ex.Message);
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    Console.WriteLine("An error occurred5: " + ex.Message);
                        //}

                        //}
                        //else
                        //{
                        //    ProjectData.URL = null; // No URL provided
                        //}

                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        string url = Convert.ToString(dr["URL"]);

                        // Check if the URL is not empty and not equal to "No link" (case insensitive)
                        if (!string.IsNullOrEmpty(url) && !string.Equals(url, "No link", StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                // Create a WebRequest and set timeout values (adjust as needed)
                                WebRequest webRequest = WebRequest.Create(url);
                                webRequest.Timeout = 5000;  // 5 seconds timeout for the request
                                webRequest.Method = "HEAD"; // Use HEAD method to check only headers

                                using (WebResponse webResponse = webRequest.GetResponse())
                                {
                                    // URL is valid, so set it to ProjectData.URL
                                    ProjectData.URL = url;
                                }
                            }
                            catch (WebException ex)
                            {
                                // URL is invalid or an error occurred during the request
                                ProjectData.URL = null;
                                // Log the error or handle it appropriately
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                        else
                        {
                            // URL is empty or equal to "No link" (case insensitive)
                            ProjectData.URL = null;
                        }




                        //string url = Convert.ToString(dr["URL"]);


                        //if (!string.IsNullOrEmpty(url) && url != "No link")
                        //{
                        //    WebRequest webRequest = WebRequest.Create(url);
                        //    WebResponse webResponse;

                        //    try
                        //    {
                        //        webResponse = webRequest.GetResponse();
                        //        ProjectData.URL = url;
                        //    }
                        //    catch
                        //    {
                        //        ProjectData.URL = null;
                        //        //Console.WriteLine("An error occurred.");
                        //    }
                        //}
                        //else if(url != "no link")
                        //{
                        //    ProjectData.URL = null;
                        //}
                        //else {
                        //    ProjectData.URL = null;

                        //}
                    }
                }
                return ProjectData;
            }
        }

  


        public string InsertChatgptDetails(string IPAddress, string Question)
        {
            if (string.IsNullOrEmpty(IPAddress) || string.IsNullOrEmpty(Question))
            {
                return null;
            }

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_InsertAnthemChatGpt",
                  new SqlParameter("@IpAddress", IPAddress),
                  new SqlParameter("@UserQuestion", Question)
               
                    ))
                    return null;
            }
        }



        public List<AnthemEntites.Projects> GetProjectByCategory(string PCategory)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Projects> projectsList = new List<AnthemEntites.Projects>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetProjectByProjectCategory",
                    new SqlParameter("@SubCategories", PCategory)))
                    while (dr.Read())
                    {
                        AnthemEntites.Projects ProjectData = new AnthemEntites.Projects();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        projectsList.Add(ProjectData);
                    }
                return projectsList;
            }
        }
        public List<AnthemEntites.ProjectImages> GetAllProjectImagesByProjectId(int projectId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.ProjectImages> projectsList = new List<AnthemEntites.ProjectImages>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetAllImagesByProjectId",
                    new SqlParameter("@projectId", projectId)))
                    while (dr.Read())
                    {
                        AnthemEntites.ProjectImages ProjectData = new AnthemEntites.ProjectImages();
                        ProjectData.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                        ProjectData.ImageId = Convert.ToInt32(dr["ImageId"]);
                        ProjectData.ImageURL = Convert.ToString(dr["ImageURL"]);
                        projectsList.Add(ProjectData);
                    }
                return projectsList;
            }
        }


       public AnthemEntites.Projects GetViewPage(string PageName)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                AnthemEntites.Projects Model = new AnthemEntites.Projects();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetViewDynamicPage",
                    new SqlParameter("@PageName", PageName)))
                    while (dr.Read())
                    {
                        Model.PageName = dr["PageName"].ToString();
                        Model.Description = dr["Description"].ToString();
                        Model.IsPublic = Convert.ToBoolean(dr["IsPublic"]);

                    }
                return Model;
            }
        }


        #endregion

        public List<AnthemEntites.Projects> GetAllEmployees()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Projects> TeamList = new List<AnthemEntites.Projects>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "GetAllTeamList"
                   ))
                    while (dr.Read())
                    {
                        AnthemEntites.Projects TeamData = new AnthemEntites.Projects();
                        TeamData.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        TeamData.Name = dr["Name"].ToString();
                        TeamData.Designation = dr["Designation"].ToString();
                        TeamData.Picture= dr["Picture"];
                        TeamList.Add(TeamData);
                    }
                return TeamList;
            }
        }

       
    }
}
