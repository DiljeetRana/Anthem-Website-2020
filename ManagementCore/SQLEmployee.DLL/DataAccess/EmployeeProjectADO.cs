using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.ADO;
using System.Data;
using System.Data.SqlClient;
using EmployeeEntity;

namespace SQLEmployee.DLL.DataAccess
{
    public partial class EmployeeProjectSql
    {
        public List<EmployeeEntity.EmployeeProjectEntity> GetEmployeeProjects(int EmployeeId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeProjectEntity> EmployeeProjectList = new List<EmployeeEntity.EmployeeProjectEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetEmployeeProjects",
                    new SqlParameter("@EmployeeId", EmployeeId)))
                    while (dr.Read())
                    {

                        EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                        Model.EmployeeProjectId = Convert.ToInt32(dr["EmployeeProjectId"]);
                        Model.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                        Model.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        Model.ProjectName = dr["ProjectName"].ToString();
                        Model.FromDate = Convert.ToDateTime(dr["FromDate"]);
                        Model.ToDate = Convert.ToDateTime(dr["ToDate"]);
                        Model.RoleDescriptions = dr["RoleDescriptions"].ToString();
                        EmployeeProjectList.Add(Model);
                    }
                return EmployeeProjectList;
            }
        }

        public string AddGetEmployeeProject(EmployeeEntity.EmployeeProjectEntity Model)
        {
            string Result = string.Empty;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_InsertEmployeeProject",
                new SqlParameter("@ProjectId", Model.ProjectId),
                new SqlParameter("@EmployeeId", Model.EmployeeId),
                new SqlParameter("@FromDate", Model.FromDate),
                new SqlParameter("@ToDate", Model.ToDate),
                new SqlParameter("@RoleDescriptions", Model.RoleDescriptions)
                ))
                    while (dr.Read())
                    {
                        Result = (dr["Result"]).ToString();
                    }
            }
            return Result;

        }


        public bool DeleteEmployeeProject(int EmployeeProjectId)
        {
            var result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_DeleteEmployeeProject",
                new SqlParameter("@EmployeeProjectId", EmployeeProjectId)
                ))
                    while (dr.Read())
                    {
                        result = Convert.ToBoolean(dr["IsDeleted"]);
                    }
            }
            return result;

        }

        




        public EmployeeEntity.EmployeeProjectEntity UpdateEmployeeProject(EmployeeEntity.EmployeeProjectEntity Model)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_UpdateEmployeeProject",
                       new SqlParameter("@EmployeeProjectId", Model.EmployeeProjectId),
                        new SqlParameter("@ProjectId", Model.ProjectId),

                        new SqlParameter("@FromDate", Model.FromDate),
                        new SqlParameter("@ToDate", Model.ToDate),
                        new SqlParameter("@RoleDescriptions", Model.RoleDescriptions)
                //new SqlParameter("@ContactNumber", Model.ContactNumber)
                ))
                    return Model;

            }

        }

        public EmployeeEntity.EmployeeProjectEntity GetEmployeeProject(int EmployeeProjectId)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetEmployeeProject",
                    new SqlParameter("@EmployeeProjectId", EmployeeProjectId)))
                    while (dr.Read())
                    {
                        Model.EmployeeProjectId = Convert.ToInt32(dr["EmployeeProjectId"]);
                        Model.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                        Model.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        Model.ProjectName = dr["ProjectName"].ToString();
                        Model.FromDate = Convert.ToDateTime(dr["FromDate"]);
                        Model.ToDate = Convert.ToDateTime(dr["ToDate"]);
                        Model.RoleDescriptions = dr["RoleDescriptions"].ToString();
                    }
                return Model;
            }
        }

        public string AddGetWork(EmployeeEntity.EmployeeProjectEntity Model)
        {
            string Result = string.Empty;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_InsertWork",
                new SqlParameter("@EmployeeId", Model.EmployeeId),
                new SqlParameter("@CompanyName", Model.CompanyName),
                new SqlParameter("@Position", Model.Position),
                new SqlParameter("@City", Model.City),
                new SqlParameter("@Description", Model.Description),
                new SqlParameter("@TimePeriod", Model.TimePeriod)
                ))
                    while (dr.Read())
                    {
                        Result = (dr["Result"]).ToString();
                    }
            }
            return Result;

        }


        public string AddGetEducation(EmployeeEntity.EmployeeProjectEntity Model)
        {
            string Result = string.Empty;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_InsertEducation",
                new SqlParameter("@EmployeeId", Model.EmployeeId),
                new SqlParameter("@SchoolName", Model.SchoolName),
                 new SqlParameter("@TimePeriod", Model.TimePeriod),
                new SqlParameter("@Education", Model.Education),
                new SqlParameter("@Description", Model.Description)

                ))
                    while (dr.Read())
                    {
                        Result = (dr["Result"]).ToString();
                    }
            }
            return Result;

        }

        public EmployeeEntity.EmployeeProjectEntity GetWorkInfomation(int CompanyId)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetWorkInfomation",
                    new SqlParameter("@CompanyId", CompanyId)))
                    while (dr.Read())
                    {

                        Model.CompanyName = dr["CompanyName"].ToString();
                        Model.Position = dr["Position"].ToString();
                        Model.City = dr["City"].ToString();
                        Model.Description = dr["Description"].ToString();
                        Model.TimePeriod = dr["TimePeriod"].ToString();
                    }
                return Model;
            }
        }


        public EmployeeEntity.EmployeeProjectEntity UpdateWork(EmployeeEntity.EmployeeProjectEntity CompanyDetail)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_UpdateWork",
                       new SqlParameter("@CompanyId", CompanyDetail.CompanyId),
                        new SqlParameter("@CompanyName", CompanyDetail.CompanyName),
                        new SqlParameter("@Position", CompanyDetail.Position),
                        new SqlParameter("@City", CompanyDetail.City),
                        new SqlParameter("@Description", CompanyDetail.Description),
                        new SqlParameter("@TimePeriod", CompanyDetail.TimePeriod)
                //new SqlParameter("@ContactNumber", Model.ContactNumber)
                ))
                    return CompanyDetail;

            }

        }

        public List<EmployeeEntity.EmployeeProjectEntity> GetAllWorks(int EmployeeId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeProjectEntity> EmployeeProjectList = new List<EmployeeEntity.EmployeeProjectEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetAllWorks",
                    new SqlParameter("@EmployeeId", EmployeeId)))
                    while (dr.Read())
                    {

                        EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                        Model.CompanyId = Convert.ToInt32(dr["CompanyId"]);
                        Model.CompanyName = dr["CompanyName"].ToString();
                        Model.Position = dr["Position"].ToString();
                        Model.City = dr["City"].ToString();
                        Model.Description = dr["Description"].ToString();
                        Model.TimePeriod = dr["TimePeriod"].ToString();
                        EmployeeProjectList.Add(Model);
                    }
                return EmployeeProjectList;
            }
        }

            public List<EmployeeEntity.EmployeeProjectEntity> GetEducationInformations(int EmployeeId)
            {
                using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
                {
                    List<EmployeeEntity.EmployeeProjectEntity> EmployeeProjectList1 = new List<EmployeeEntity.EmployeeProjectEntity>();
                    using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetEducationInformation",
                        new SqlParameter("@EmployeeId", EmployeeId)))
                        while (dr.Read())
                        {

                            EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                            Model.SchoolId = Convert.ToInt32(dr["SchoolId"]);
                            Model.SchoolName = dr["SchoolName"].ToString();
                            Model.TimePeriod = dr["TimePeriod"].ToString();
                            Model.Education = dr["Education"].ToString();
                            Model.Description = dr["Description"].ToString();
                            EmployeeProjectList1.Add(Model);
                        }
                    return EmployeeProjectList1;
                }

            }
        public bool DeleteWork(int CompanyId)
        {
            var result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_DeleteWork",
                new SqlParameter("@CompanyId", CompanyId)
                ))
                    while (dr.Read())
                    {
                        result = Convert.ToBoolean(dr["IsDeleted"]);
                    }
            }
            return result;
        }


        public EmployeeEntity.EmployeeProjectEntity GetEducation(int SchoolId)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetEducation",
                    new SqlParameter("@SchoolId", SchoolId)))
                    while (dr.Read())
                    {

                        Model.SchoolName = dr["SchoolName"].ToString();
                        Model.TimePeriod = dr["TimePeriod"].ToString();
                        Model.Education = dr["Education"].ToString();
                        Model.Description = dr["Description"].ToString();

                    }
                return Model;
            }
        }


        public EmployeeEntity.EmployeeProjectEntity UpdateEducation(EmployeeEntity.EmployeeProjectEntity SchoolDetail)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_UpdateEducation",
                       new SqlParameter("@SchoolId", SchoolDetail.SchoolId),
                        new SqlParameter("@SchoolName", SchoolDetail.SchoolName),
                        new SqlParameter("@TimePeriod", SchoolDetail.TimePeriod),
                        new SqlParameter("@Education", SchoolDetail.Education),
                        new SqlParameter("@Description", SchoolDetail.Description)

                //new SqlParameter("@ContactNumber", Model.ContactNumber)
                ))
                    return SchoolDetail;

            }

        }


        public bool DeleteEducation(int SchoolId)
        {
            var result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_DeleteEducation",
                new SqlParameter("@SchoolId", SchoolId)
                ))
                    while (dr.Read())
                    {
                        result = Convert.ToBoolean(dr["IsDeleted"]);
                    }
            }
            return result;
        }




        public string AddPage(EmployeeEntity.EmployeeProjectEntity Model)
        {
            string Result;
            SqlParameter Message = new SqlParameter();
            Message.SqlDbType = SqlDbType.VarChar;
            Message.Direction = ParameterDirection.Output;
            Message.Size = 50;
            Message.ParameterName= "@Message";
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_InsertDynamicPage",
                //new SqlParameter("@PageId", Model.PageId),
                new SqlParameter("@PageName", Model.PageName),
                new SqlParameter("@PublicUrl", Model.PublicUrl),
                new SqlParameter("@Description", Model.Description),
                new SqlParameter("@IsPublic", Model.IsPublic),
                new SqlParameter("@CreatedOn", Model.CreatedOn),
                Message
                ))
                Result = Message.Value.ToString();
                return Result;
                //while (dr.Read())
                //{
                //    Result = (dr["Result"]).ToString();
                //}
            }
           

        }



        public List<EmployeeEntity.EmployeeProjectEntity> GetPages()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeProjectEntity> EmployeePageList = new List<EmployeeEntity.EmployeeProjectEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetDynamicPages"))

                    while (dr.Read())
                    {

                        EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                        Model.PageId = Convert.ToInt32(dr["PageId"]);
                        Model.PageName = dr["PageName"].ToString();
                        Model.PublicUrl = dr["PublicUrl"].ToString();
                        Model.Description = dr["Description"].ToString();
                        Model.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                        Model.IsPublic = Convert.ToBoolean(dr["IsPublic"]);

                        EmployeePageList.Add(Model);
                    }
                return EmployeePageList;
            }
        }
      public bool DeletePage(int PageId)
        {
            var result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_DeleteDynamicPage",
                new SqlParameter("@PageId", PageId)
                ))
                    while (dr.Read())
                    {
                        result = Convert.ToBoolean(dr["IsDeleted"]);
                    }
            }
            return result;
        }


        public EmployeeEntity.EmployeeProjectEntity GetPage(int PageId)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetDynamicPage",
                    new SqlParameter("@PageId", PageId)))
                    while (dr.Read())
                    {

                        Model.PageName = dr["PageName"].ToString();
                        Model.Description = dr["Description"].ToString();
                        Model.IsPublic = Convert.ToBoolean(dr["IsPublic"]);
                        

                    }
                return Model;
            }
        }

        public string UpdatePage(EmployeeEntity.EmployeeProjectEntity PageI)
        {

            string Result;
            SqlParameter Message = new SqlParameter();
            Message.SqlDbType = SqlDbType.VarChar;
            Message.Direction = ParameterDirection.Output;
            Message.Size = 50;
            Message.ParameterName = "@Message";
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_UpdateDynamicPage",
                       new SqlParameter("@PageId", PageI.PageId),
                        new SqlParameter("@PageName", PageI.PageName),
                        new SqlParameter("@Description", PageI.Description),
                        new SqlParameter("@IsPublic", PageI.IsPublic),
                        new SqlParameter("@CreatedOn", PageI.CreatedOn),
                        Message
                     

                //new SqlParameter("@ContactNumber", Model.ContactNumber)
                ))
                    Result = Message.Value.ToString();
                    return Result;
            }
            //return Result;

        }


        public EmployeeEntity.EmployeeProjectEntity GetViewPage(string PageName)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
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
        public List<EmployeeEntity.EmployeeCheckEntity> GetFestivalDetail()
        {
            List<EmployeeEntity.EmployeeCheckEntity> candidatesList = new List<EmployeeEntity.EmployeeCheckEntity>();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getholidays"))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeCheckEntity report = new EmployeeEntity.EmployeeCheckEntity();
                        report.HolidayId = Convert.ToInt32(dr["HolidayId"]);
                        report.FestivalDate = Convert.ToString(dr["FestivalDate"]);

                        candidatesList.Add(report);
                    }
                    return candidatesList;
                }
            }


        }





    }
}
