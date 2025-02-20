using EmployeeEntity;
using SQLEmployee.DLL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.DataAccess
{
    public partial class MultipleMail
    {
        #region functions
        public List<MultipleMails> GetEmployess()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.MultipleMails> Obj_List = new List<EmployeeEntity.MultipleMails>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "spGetDataEmployees"))
                    while (dr.Read())
                    {
                        EmployeeEntity.MultipleMails Obj = new EmployeeEntity.MultipleMails();
                        Obj.Name = dr["Name"].ToString();
                        Obj.Email = dr["Email"].ToString();
                        Obj.IsClient = Convert.ToBoolean(dr["IsClient"]);

                        Obj_List.Add(Obj);
                    }
                return Obj_List;
            }
        }

        public List<MultipleMails> GetClients()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.MultipleMails> Obj_List = new List<EmployeeEntity.MultipleMails>();                
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "spGetDataClients"))
                    while (dr.Read())
                    {
                        EmployeeEntity.MultipleMails Obj = new EmployeeEntity.MultipleMails();
                        Obj.Name = dr["Name"].ToString();
                        Obj.Email = dr["Email"].ToString();
                        Obj.IsClient = Convert.ToBoolean(dr["IsClient"]);

                        Obj_List.Add(Obj);
                    }
                return Obj_List;
            }
        }
        #endregion
    }
}
