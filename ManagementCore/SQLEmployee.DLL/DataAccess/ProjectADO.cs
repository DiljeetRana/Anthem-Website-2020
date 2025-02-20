using SQLEmployee.DLL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.DataAccess
{
    public partial class Projects
    {

        public List<EmployeeEntity.Project> GetAllProjects(string projectName)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Project> projectsList = new List<EmployeeEntity.Project>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAllProjects",
                    new SqlParameter("@projectName", projectName)))
                    while (dr.Read())
                    {
                        EmployeeEntity.Project ProjectData = new EmployeeEntity.Project();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectCode = Convert.ToString(dr["ProjectCode"]);
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
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        ProjectData.Publish = Convert.ToInt32(dr["Publish"]);
                        projectsList.Add(ProjectData);
                    }
                return projectsList;
            }
        }

        public EmployeeEntity.Project GetProjectByProjectid(int projectId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Project ProjectData = new EmployeeEntity.Project();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getProjectByProjectId",
                    new SqlParameter("@projectId",projectId)))
                    while (dr.Read())
                    {
                       
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectCode = Convert.ToString(dr["ProjectCode"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = Convert.ToString(dr["SubCategories"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDescription = dr["SmallDescription"].ToString();
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                       // projectsList.Add(ProjectData);
                    }
                return ProjectData;
            }
        }


        /// <summary>
        /// Add New Project Record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string AddNewProject(EmployeeEntity.Project projectData)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                string show;
              //  parameter.Size = 50;
                SqlParameter message = new SqlParameter();
                message.SqlDbType = SqlDbType.VarChar;
                message.Direction = ParameterDirection.Output;
                message.Size = 50;
                message.ParameterName = "@message";
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_AddNewPorject",
                    new SqlParameter("@name", projectData.ProjectName),
                    new SqlParameter("@projectImage", projectData.ProjectImage),
                    new SqlParameter("@description", projectData.Description),
                    new SqlParameter("@URL", projectData.URL),
                    new SqlParameter("@dateOfProject", projectData.DateofProject),
                    new SqlParameter("@projectCategories", projectData.ProjectCategory),
                    new SqlParameter("@projectTechnologies", projectData.Technolgies),
                    new SqlParameter("@projectSubCategories", projectData.ProjectSubCategory),
                    new SqlParameter("@endDateofProject", projectData.EndDateofProject),
                    new SqlParameter("@smalldescription", projectData.SmallDescription),
                    new SqlParameter("@Priority", projectData.Priority),
                     message
                   ))

                   
               show = message.Value.ToString();
                return show;
            }
        }

        /// <summary>
        /// Add New Project Record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string UpdateProjectByPorjectId(EmployeeEntity.Project projectData)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                string show;
                //  parameter.Size = 50;
                SqlParameter message = new SqlParameter();
                message.SqlDbType = SqlDbType.VarChar;
                message.Direction = ParameterDirection.Output;
                message.Size = 50;
                message.ParameterName = "@message";
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_UpdateProjectByPorjectId",
                    new SqlParameter("@projectId", projectData.ProjectID),
                    new SqlParameter("@name", projectData.ProjectName),
                    new SqlParameter("@projectImage", projectData.ProjectImage),
                    new SqlParameter("@description", projectData.Description),
                    new SqlParameter("@URL", projectData.URL),
                    new SqlParameter("@dateOfProject", projectData.DateofProject),
                    new SqlParameter("@projectCategories", projectData.ProjectCategory),
                    new SqlParameter("@projectTechnologies", projectData.Technolgies),
                    new SqlParameter("@projectsubcategory",projectData.ProjectSubCategory),
                    new SqlParameter("@projectenddate",projectData.EndDateofProject),
                    new SqlParameter("@smalldescription",projectData.SmallDescription),
                    new SqlParameter("@Priority", projectData.Priority),
                    message

                   ))
                show=message.Value.ToString();
                return show;
            }
        }

        
        /// <summary>
        /// Delete a project from db
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string DeleteProject(int projectId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_DeleteProject",
                    new SqlParameter("@projectId", projectId)
                   ))
                return "Success";
            }
        }

        public int UnpublishProject(long projectid)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_UnpublishProject",
                    new SqlParameter("@projectid", projectid)))
                    return 0;
            }
        }

        public int PublishProject(long projectid)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_PublishProject",
                    new SqlParameter("@projectid", projectid)))
                    return 0;
            }
        }

        public List<EmployeeEntity.Project> GetSortedProjects(int selectedVal)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Project> projectsList = new List<EmployeeEntity.Project>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetSortedProjects",
                    new SqlParameter("@ddlvalue", selectedVal)))
                    while (dr.Read())
                    {
                        EmployeeEntity.Project ProjectData = new EmployeeEntity.Project();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectCode = Convert.ToString(dr["ProjectCode"]);
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
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        ProjectData.Publish = Convert.ToInt32(dr["Publish"]);
                        projectsList.Add(ProjectData);
                    }
                return projectsList;
            }
        }

    }
}
