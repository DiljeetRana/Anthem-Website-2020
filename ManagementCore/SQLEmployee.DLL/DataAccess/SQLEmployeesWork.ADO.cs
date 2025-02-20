using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using SQLEmployee.DLL.ADO;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SQLEmployee.DLL.DataAccess
{
  public partial class SQLEmployeesWork
  {
      #region All ADO Operatons

      /// <summary>
      /// Insert employees personal details from employees
      /// </summary>
      /// <param name="employee"></param>
      /// <returns></returns>
      public string RegisterEmployee(EmployeeEntity.EmployeeEntity employee)
      {
         using(ADOExecution exec=new ADOExecution(SQLBase.GetConnectionString()))
         {
               SqlParameter parameter = new SqlParameter();
              parameter.SqlDbType = SqlDbType.VarChar;
              parameter.Direction = ParameterDirection.Output;
              parameter.ParameterName = "@message";
              parameter.Size = 50;
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_AddRegisterEmployees",
                 new SqlParameter("@name",employee.Name),
                 new SqlParameter("@gender",employee.Gender),
                 new SqlParameter("@contactnumber",employee.ContactNumber),
                 new SqlParameter("@alternatenumber",employee.AlternateNumber),
                 new SqlParameter("@email",employee.Email),
                 new SqlParameter("@birthday",employee.Birthday),
                 new SqlParameter("@anniversary",employee.Aniversary),
                 new SqlParameter("@contactaddress",employee.ContactAddress),
                 new SqlParameter("@picture",employee.Photo),
                 new SqlParameter("@creation",employee.Creation),
                 new SqlParameter("@isdeleted",employee.IsDeleted),
                 new SqlParameter("@isfirstlogin",employee.IsFirstLogin)
                 ,parameter))
                 employee.message = parameter.Value.ToString();
             return employee.message;
         }
      }


        public string ChangeImage(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                //SqlParameter parameter = new SqlParameter();
                //parameter.SqlDbType = SqlDbType.VarChar;
                //parameter.Direction = ParameterDirection.Output;
                //parameter.ParameterName = "@message";
                //parameter.Size = 50;
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_ChangeImage",
                    new SqlParameter("@employeeid", employee.EmployeeId),
                   new SqlParameter("@picture", employee.Photo)
                   ))
                    return null;
                    //employee.message = parameter.Value.ToString();
                //return employee.message;
            }
        }
        /// <summary>
        /// generate password and saved in table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int GeneratePassword(EmployeeEntity.EmployeeEntity employee)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_GeneratePassword",
                  new SqlParameter("@employeeid", employee.EmployeeId),
                  new SqlParameter("@password", employee.Password),
                  new SqlParameter("@isverified",employee.IsVerified),
                  new SqlParameter("@activeid",employee.ActiveId)))
                  return 0;
          }
      }

      /// <summary>
      /// send username and random password to employee
      /// </summary>
      /// <param name="employeeid"></param>
      /// <returns></returns>
      public EmployeeEntity.EmployeeEntity SendUsernameAndPassword(long employeeid)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
              using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_SendUsernameAndPassword",
                  new SqlParameter("@employeeid",employeeid)))
                  if (dr.Read())
                  {
                      employee.OfficeEmail = dr["OfficeEmail"].ToString();
                      employee.Password = dr["Password"].ToString();
                      employee.Email = dr["Email"].ToString();
                     
                  }
              return employee;
          }
      }

      /// <summary>
      /// if Username and Password is Correct Than Logged In
      /// </summary>
      /// <param name="username"></param>
      /// <param name="password"></param>
      /// <returns></returns>
      public EmployeeEntity.EmployeeEntity CheckUsernameAndPassword(string username, string password)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
              using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_CheckEmployeesUsernameAndpassword",
                  new SqlParameter("@username", username),
                  new SqlParameter("@password", password)))
              {
                 
                  if (dr.Read())
                  {
                      employee.EmployeeId = (long)dr["EmployeeId"];
                      employee.Name = dr["Name"].ToString();
                      employee.OfficeEmail = dr["OfficeEmail"].ToString();
                      employee.Password = dr["Password"].ToString();
                      employee.IsFirstLogin = Convert.ToInt32(dr["IsFirstTimeLogin"]);
                      employee.ActiveId = (int)dr["ActiveId"];
                  }
                  return employee;
              }
          }
      }

      /// <summary>
      /// change random password of employees
      /// </summary>
      /// <param name="employee"></param>
      /// <returns></returns>
      public int ChangePassword(EmployeeEntity.EmployeeEntity employee)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_UpdateIsLoginFirstTime",
                  new SqlParameter("@username", employee.OfficeEmail),
                  new SqlParameter("@password", employee.Password),
                  new SqlParameter("@islogin",employee.IsFirstLogin)))
                  return 0;
          }
      }

      public EmployeeEntity.EmployeeEntity CheckIsVerified(long employeeid)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
              using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_Checkisverified",
                  new SqlParameter("@employeeid",employeeid)))
                  if (dr.Read())
                  {
                    employee.IsVerified = dr["isverified"].ToString();
                  
                  }
              return employee;
          }
      }

      public EmployeeEntity.EmployeeEntity EmployeeProfile(string username)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
              using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_EmployeeProfile",
                  new SqlParameter("@username",username)))
                  if (dr.Read())
                  {
                      employee.EmployeeId = Convert.ToInt64(dr["EmployeeId"]);
                      employee.EmpCode = dr["EmpCode"].ToString();
                      employee.Name = dr["Name"].ToString();
                      employee.Gender = dr["Gender"].ToString();
                      employee.Designation = dr["Designation"].ToString();
                      employee.ContactNumber = dr["ContactNumber"].ToString();
                      employee.AlternateNumber = dr["AlternateNumber"].ToString();
                      employee.Email = dr["Email"].ToString();
                      employee.OfficeEmail = dr["OfficeEmail"].ToString();
                      employee.Birthday = Convert.ToDateTime(dr["Birthday"]);
                      employee.Aniversary = dr["Aniversary"].ToString();
                      employee.ContactAddress = dr["ContactAddress"].ToString();
                      employee.JoiningDate = dr["JoiningDate"].ToString();
                      employee.Status = dr["StatusName"].ToString();
                      employee.LastHikeDate = dr["LastHikeDate"].ToString();
                      employee.CurrentSalary = dr["CurrentSalary"].ToString();
                      employee.NextHikeDueDate = dr["NextHikeDueDate"].ToString();
                      employee.Grade = dr["Grade"].ToString();
                      employee.CompanyAccountNumber = dr["CompanyAccountNumber"].ToString();
                      employee.Anonymous1 = dr["Anonymous1"].ToString();
                      employee.Anonymous2 = dr["Anonymous2"].ToString();
                      employee.Anonymous3 = dr["Anonymous3"].ToString();
                      employee.Password = dr["Password"].ToString();
                  }
              return employee;
          }
      }

      public int BlockEmployee(long employeeid)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_BlockEmployee",
                  new SqlParameter("@employeeid", employeeid)))
                  return 0;
          }
      }

      public int ActivateEmployee(long employeeid)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_ActivateEmployees",
                  new SqlParameter("@employeeid", employeeid)))
                  return 0;
          }
      }

      public int CheckFirstTimeProfile(string username)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              int firsttimeprofile = 0;
              using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_CheckProfileFIrstTime",
                  new SqlParameter("@username",username)))
                  if (dr.Read())
                  {
                      if (dr["IsProfileFirstTime"] == DBNull.Value)
                      {
                          firsttimeprofile = 2;
                      }
                      else
                      {
                          firsttimeprofile = (int)dr["IsProfileFirstTime"];
                      }
                  }
              return firsttimeprofile;
          }
      }
      #endregion
  }
}
