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
    public partial class Technologies
    {
        public List<EmployeeEntity.Technologies> GetAllTechnologies()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Technologies> technologyList = new List<EmployeeEntity.Technologies>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAllTechnologies",
                    null))
                    while (dr.Read())
                    {
                        EmployeeEntity.Technologies technologyData = new EmployeeEntity.Technologies();
                        technologyData.Id = Convert.ToInt32(dr["Id"]);
                        technologyData.Name = Convert.ToString(dr["Name"]);
                        technologyList.Add(technologyData);
                    }
                return technologyList;
            }
        }

        public List<EmployeeEntity.Technologies> GetTechnolgiesListForAutoComplete(string prefix)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Technologies> technologyList = new List<EmployeeEntity.Technologies>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetTechnolgiesListForAutoComplete",
                    new SqlParameter("@prefix", prefix)))
                    while (dr.Read())
                    {
                        EmployeeEntity.Technologies technologyData = new EmployeeEntity.Technologies();
                        technologyData.Name = Convert.ToString(dr["Name"]);
                        technologyList.Add(technologyData);
                    }
                return technologyList;
            }
        }
    }
}
