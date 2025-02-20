using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.ADO;
using EmployeeEntity;
using System.Data;
using System.Data.SqlClient;

namespace SQLEmployee.DLL.DataAccess
{
   public partial class Leave
   {

       #region All Sql Operations

       public int AddLeave(EmployeeEntity.Leave leave)
       {
           using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
           {
               using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertLeave",
                   new SqlParameter("@startdate", leave.StartDate),
                   new SqlParameter("@enddate", leave.EndDate),
                   new SqlParameter("@ishalf", leave.IsHalf),
                   new SqlParameter("@reason", leave.Reason),
                   new SqlParameter("@employeeid", leave.EmployeeId)))
                   return 0;
           }
       }

       public List<EmployeeEntity.Leave> GetLeavesByEmployeeId(long employeeid)
       {
           using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
           {
               List<EmployeeEntity.Leave> leavelist = new List<EmployeeEntity.Leave>();
               using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_GetLeaveByEmployeeid",
                   new SqlParameter("@employeeid",employeeid)))
                   while (dr.Read())
                   {
                       EmployeeEntity.Leave leave = new EmployeeEntity.Leave();
                       leave.Id = (int)dr["Id"];
                       leave.StartDate = dr["StartDate"].ToString();
                       leave.EndDate = dr["EndDate"].ToString();
                       leave.Reason = dr["Reason"].ToString();
                       if (dr["IsHalf"].ToString() == "False")
                       {
                           leave.IsHalf = "No";
                       }
                       else
                       {
                           leave.IsHalf = "Yes";
                       }
                      
                       leavelist.Add(leave);
                   }
               return leavelist;
           }
       }

       public int CancelLeaveByLeaveId(int leaveid)
       {
           using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
           {
               using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_CancelLeaveByEmployee",
                   new SqlParameter("@id", leaveid)))
                   return 0;
           }
       }

       public DataTable GetEmployeeEmailByEmployeeId(long employeeid)
       {
           using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
           {
               using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetEmployeeEmailByEmployeeId",
                   new SqlParameter("@employeeid", employeeid)))
               {
                   using (DataTable dt = new DataTable())
                   {
                       dt.Load(dr);
                       return dt;
                   }
               }
           }
       }

       public DataTable GetDetailsOfCancelsLeavesByLeaveId(int leaveid)
       {
           using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
           {
               using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_GetCancelLeavesByLeaveId",
                   new SqlParameter("@leaveid",leaveid)))
               using (DataTable dt = new DataTable())
               {
                   dt.Load(dr);
                   return dt;
               }
           }
       }
      
      
       #endregion
   }
}
