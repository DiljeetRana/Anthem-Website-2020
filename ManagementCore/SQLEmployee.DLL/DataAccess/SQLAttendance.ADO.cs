using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using System.Data;
using SQLEmployee.DLL.ADO;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SQLEmployee.DLL.DataAccess
{
  public partial class SQLAttendance
  {

      #region Sql Operations

      public List<EmployeeEntity.Attendance> GetAttendance(long employeeid)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              List<EmployeeEntity.Attendance> attendancelist = new List<Attendance>();
              using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_GetAttendance",
                  new SqlParameter("@employeeid",employeeid)))
                  while (dr.Read())
                  {
                      EmployeeEntity.Attendance attendance = new Attendance();
                      attendance.Id = (int)dr["Id"];
                      string[] formats = {"dd/MM/yyyy", "dd-MMM-yyyy", "yyyy-MM-dd", 
                   "dd-MM-yyyy", "M/d/yyyy", "dd MMM yyyy"};
                      string dbdate = dr["Date"].ToString();
                    
                      string tempdate = DateTime.ParseExact(dbdate.ToString(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
                      DateTime dt = DateTime.Now.AddHours(14);
                      DateTime dtt = dt.AddMinutes(32);
                      string todaydate=dtt.ToString("MM/dd/yyyy");
                  
                      DateTime dt2 = Convert.ToDateTime(tempdate);
                      TimeSpan twodate = dt.Subtract(dt2);
                      int totaldays =Convert.ToInt32(twodate.TotalDays);
                      if (tempdate == todaydate)
                      {
                          attendance.Date = "Today";
                      }
                      //else
                          //if (totaldays == 2)
                          //{
                          //    attendance.Date = "Yesterday";
                          //}
                          else
                          {
                              attendance.Date = dr["Date"].ToString();
                          }
                      string intime=dr["InTime"].ToString();
                      if (intime == "")
                      {
                          attendance.InTime = intime;
                      }
                      else
                      {
                          string[] insplit = intime.Split(':');
                          string aftersplitin1 = insplit[0];
                          string aftersplitin2 = insplit[1];
                       
                          var numAlpha = new Regex("(?<Numeric>[0-9]*)(?<Alpha>[a-zA-Z]*)");
                          var match = numAlpha.Match(aftersplitin2);

                          var alpha = match.Groups["Alpha"].Value;
                          var num = match.Groups["Numeric"].Value;

                          attendance.InTime = aftersplitin1 + ":"+num+" "+alpha;
                      }
                      string outtime = dr["OutTime"].ToString();
                      if (outtime == "")
                      {
                          attendance.OutTime = outtime;
                      }
                      else
                      {
                          string[] outsplit = outtime.Split(':');
                          string aftersplitin1 = outsplit[0];
                          string aftersplitin2 = outsplit[1];

                          var numAlpha = new Regex("(?<Numeric>[0-9]*)(?<Alpha>[a-zA-Z]*)");
                          var match = numAlpha.Match(aftersplitin2);

                          var alpha = match.Groups["Alpha"].Value;
                          var num = match.Groups["Numeric"].Value;

                          attendance.OutTime = aftersplitin1 + ":" + num + " " + alpha;
                      }
                      string leave = dr["MarkOnLeave"].ToString();
                      if (leave == "False")
                      {
                          attendance.MarkOnLeave = "Present";
                      }
                      else if(leave=="True")
                      {
                          attendance.MarkOnLeave = "Absent";
                      }
                      else
                          if (leave == null)
                          {
                              attendance.MarkOnLeave = "";
                          }
                     
                      attendancelist.Add(attendance);
                  }
              return attendancelist;
          }
      }

      public int AddAttendance(EmployeeEntity.Attendance attendance)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertAttendance",
                  new SqlParameter("@employeeid",attendance.EmployeeId),
                  new SqlParameter("@date", attendance.Date),
                  new SqlParameter("@intime", attendance.InTime),
                  new SqlParameter("@outtime", attendance.OutTime),
                  new SqlParameter("@markonleave", attendance.MarkOnLeave)))
                  return 0;
          }

      }


      public int OutTimeAttendance(EmployeeEntity.Attendance attendance)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_OutTimeAttendance",
                  new SqlParameter("@id", attendance.Id),
                  new SqlParameter("@outtime", attendance.OutTime)))
                  return 0;
          }
      }

      public int AddMissingAttendance(EmployeeEntity.Attendance attendance)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertMissingAttendance",
                  new SqlParameter("@employeeid", attendance.EmployeeId),
                  new SqlParameter("@date", attendance.Date),
                  new SqlParameter("@intime", attendance.InTime),
                  new SqlParameter("@outtime", attendance.OutTime),
                  new SqlParameter("@markonleave", attendance.MarkOnLeave)))
                  return 0;
          }

      }

      public int CheckTodayAttendance(long employeeid)
      {
          int count = 0;
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_CheckTodayAttendance",
                  new SqlParameter("@employeeid",employeeid)))
                  if (dr.Read())
                  {
                      count =Convert.ToInt32(dr[0]);
                  }
              return count;
          }
      }

      public DataTable GetEmployeesWhoSkipAttendance()
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetEmployeeDetailsWhoSkipAttendance", null))
              {
                  using (DataTable dt = new DataTable())
                  {
                      dt.Load(dr);
                      return dt;
                  }
              }
          }
      }

      public List<EmployeeEntity.EmployeeEntity> GetEmployeesDetailsWhoSkipAttendanceFrom5Days()
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
              using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Usp_CheckAttendanceWhoSkipFrom5Days", null))
                  while (dr.Read())
                  {
                      EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                      employee.Name = dr["Name"].ToString();
                      employee.OfficeEmail = dr["OfficeEmail"].ToString();
                      employeelist.Add(employee);
                  }
              return employeelist;
          }
      }
      #endregion
  }
}
