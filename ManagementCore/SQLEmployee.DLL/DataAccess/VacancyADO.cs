#region Name Spaces

using SQLEmployee.DLL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace SQLEmployee.DLL.DataAccess
{
    public partial class Vacancy
    {

        #region SQL Opeartions

        public List<EmployeeEntity.Vacancy> GetAllVacancies()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Vacancy> vacancyList = new List<EmployeeEntity.Vacancy>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "dbo.Usp_GetAllVacancies",
                    null))
                    while (dr.Read())
                    {
                        EmployeeEntity.Vacancy vacancyData = new EmployeeEntity.Vacancy();
                        vacancyData.id = Convert.ToInt32(dr["id"]);
                        vacancyData.JobTitle = Convert.ToString(dr["JobTitle"]);
                        vacancyData.Content = Convert.ToString(dr["Content"]);
                        vacancyData.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        vacancyData.IsDelete = Convert.ToBoolean(dr["IsDelete"]);
                        vacancyData.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                        vacancyList.Add(vacancyData);
                    }
                return vacancyList;
            }
        }

        public EmployeeEntity.Vacancy GetVacancyById(int id)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Vacancy vacancyData = new EmployeeEntity.Vacancy();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetVacnacyById",
                    new SqlParameter("@vacancyid", id)))
                    while (dr.Read())
                    {
                        
                        vacancyData.id = Convert.ToInt32(dr["id"]);
                        vacancyData.JobTitle = Convert.ToString(dr["JobTitle"]);
                        vacancyData.Content = Convert.ToString(dr["Content"]);
                        vacancyData.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        vacancyData.IsDelete = Convert.ToBoolean(dr["IsDelete"]);
                        vacancyData.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
                        
                    }
                return vacancyData;
            }
        }


       
        public string UpdateStatusByVacancyId(int vacancyId,Boolean status)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_UpdateVacancyStatusById",
                    new SqlParameter("@vacancyid", vacancyId),
                    new SqlParameter("@status", status)
                   ))
                return "Successfull";
            }
        }

        public string UpdateVacancyByVacancyId(EmployeeEntity.Vacancy vacancy)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_UpdateVacancyById",
                    new SqlParameter("@vacancyid", vacancy.id),
                    new SqlParameter("@jobTitle", vacancy.JobTitle),
                    new SqlParameter("@content", vacancy.Content)
                   ))
                    return "Successfull";
            }
        }

        public string AddNewVacancy(EmployeeEntity.Vacancy vacancy)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_AddNewVacancyId",
                    new SqlParameter("@status", vacancy.IsActive),
                    new SqlParameter("@jobTitle", vacancy.JobTitle),
                    new SqlParameter("@content", vacancy.Content)
                   ))
                    return "Successfull";
            }
        }

        public string DeleteVacancyById(int vacancyId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "dbo.usp_DeleteVacancyById",
                    new SqlParameter("@vacancyid", vacancyId)
                   ))
                    return "Successfull";
            }
        }


        #endregion

    }
}
