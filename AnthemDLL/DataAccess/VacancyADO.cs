using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemDLL.DataAccess
{
    public partial class Vacancy
    {
        #region SQL operations

        public List<AnthemEntites.Vacancy> GetAllActiveVacancies()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Vacancy> vacancyList = new List<AnthemEntites.Vacancy>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "dbo.Usp_GetAllActiveVacancies",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Vacancy vacancyData = new AnthemEntites.Vacancy();
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

        public int GetActiveVacanciesCount()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetActiveVacanciesCount",
                    null))
                    while (dr.Read())
                    {
                        return Convert.ToInt32(dr["VacanciesCount"]);
                    }
                return 0;
            }
        }

        #endregion
    }
}
