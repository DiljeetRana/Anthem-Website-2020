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
    public partial class Controls
    {
        public EmployeeEntity.Controls GetCheckoutIndividualEmails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Controls Obj = new EmployeeEntity.Controls();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetControlDetails",
                    new SqlParameter("@ID", 1)))
                    while (dr.Read())
                    {
                        Obj.To = dr["To"].ToString();
                        Obj.CC = dr["CC"].ToString();
                    }
                return Obj;
            }
        }
        public EmployeeEntity.Controls GetCheckoutCombinedEmails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Controls Obj = new EmployeeEntity.Controls();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetControlDetails",
                    new SqlParameter("@ID", 2)))
                    while (dr.Read())
                    {
                        Obj.To = dr["To"].ToString();
                        Obj.CC = dr["cc"].ToString();
                    }
                return Obj;
            }
        }
        public bool SaveDetails(EmployeeEntity.Controls obj)
        { 
            bool result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                
                EmployeeEntity.Controls Obj = new EmployeeEntity.Controls();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_SaveControlDetails",
                    new SqlParameter("@To", obj.To),
                    new SqlParameter("@CC", obj.CC),
                    new SqlParameter("@ID", obj.ID)))
                    while (dr.Read())
                    {
                        result = Convert.ToBoolean(dr["InformationSavedSuccessfull"]);
                    }
                return result;
            }
        }
        public EmployeeEntity.Controls GetBirthdayEmails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Controls Obj = new EmployeeEntity.Controls();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetBirthdayEmails",
                    null))
                    while (dr.Read())
                    {
                        Obj.CC = dr["EmailsForCC"].ToString();
                    }
                return Obj;
            }
        }
        public EmployeeEntity.Controls GetAnniversaryEmails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Controls Obj = new EmployeeEntity.Controls();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAnniversaryEmails",
                    null))
                    while (dr.Read())
                    {
                        Obj.CC = dr["CC"].ToString();
                    }
                return Obj;
            }
        }
        public EmployeeEntity.Controls GetMonthlyattendanceEmails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Controls Obj = new EmployeeEntity.Controls();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetMonthlyAttendanceEmails",
                    null))
                    while (dr.Read())
                    {
                        Obj.To = dr["To"].ToString();
                        Obj.CC = dr["CC"].ToString();
                    }
                return Obj;
            }
        }
    }
}
