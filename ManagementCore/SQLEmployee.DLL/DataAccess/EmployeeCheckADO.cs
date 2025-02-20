#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmployeeEntity;
using SQLEmployee.DLL.ADO;
using System.Globalization;
#endregion
namespace SQLEmployee.DLL.DataAccess
{

    public partial class EmployeeCheck
    {
        #region All Sql Operations
        public void EmployeeCheckIn(EmployeeCheckEntity CheckIn)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_EmployeeCheckIn",
                    new SqlParameter("@employeeid", CheckIn.EmployeeId),
                    new SqlParameter("@checkintime", CheckIn.CheckInTime)
                    ))
                { }
            }
        }

        public int EmployeeCheckConfirm(int employeeid)
        {
            int count;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@count";
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_EmployeeCheckConfirm",
                      new SqlParameter("@employeeid", employeeid),
                      parameter))
                {
                    return count = Convert.ToInt32(parameter.Value);
                }
            }
        }

        public void EmployeeCheckOut(EmployeeCheckEntity CheckOut)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_EmployeeCheckOut",
                    new SqlParameter("@employeeid", CheckOut.EmployeeId),
                    new SqlParameter("@workreport", CheckOut.WorkReport),
                    new SqlParameter("@checkouttime", CheckOut.CheckOutTime)
                    ))
                {

                }
            }
        }



        public List<EmployeeCheckEntity> GetCurrentMonthCheckOfEmployee(int imployeeid)
        {
            List<EmployeeCheckEntity> CheckList = new List<EmployeeCheckEntity>();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetEmployeeCheck",
                    new SqlParameter("@employeeid", imployeeid)
                    ))
                    while (dr.Read())
                    {
                        EmployeeCheckEntity check = new EmployeeCheckEntity();
                        check.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        check.CheckId = Convert.ToInt32(dr["CheckId"]);
                        check.Dated = Convert.ToString(dr["Dated"]);
                        check.OnLeave = Convert.ToString(dr["IsLeave"]);
                        if (Convert.ToBoolean(dr["IsLeave"]))
                        {
                            check.CheckInTime = "--On leave--";
                            check.CheckOutTime = "--On leave--";
                            check.WorkReport = "--On leave--";
                        }
                        else
                        {
                            string chkin = Convert.ToString(dr["CheckInTime"]);
                            if (chkin != "" && chkin != null)
                            {
                                check.CheckInTime = chkin.Insert(chkin.Length - 2, " ");
                            }
                            string chkout = Convert.ToString(dr["CheckOuttime"]);
                            if (chkout != "" && chkin != null)
                            {
                                check.CheckOutTime = chkout.Insert(chkout.Length - 2, " ");
                            }


                            check.WorkReport = dr["WorkReport"].ToString();
                        }





                        CheckList.Add(check);
                    }
                return CheckList;
            }
        }

        public string GetEmployeeOfficeEmailById(int employeeid)
        {
            string email;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Size = 100;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@email";
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetEmployeeOfficeEmailById",
                    new SqlParameter("@employeeid", employeeid),
                    parameter))
                {
                    return email = parameter.Value.ToString();
                }
            }
        }

        public EmployeeCheckEntity GetTodayCheckInAndOutOfEmployee(int employeeid)
        {
            EmployeeCheckEntity Check = new EmployeeCheckEntity();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetTodayCheckInCheckOutOfEmployee",
                    new SqlParameter("@employeeid", employeeid)
                    ))
                {
                    if (dr.Read())
                    {
                        Check.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        string chkin = Convert.ToString(dr["CheckInTime"]);
                        if (chkin != "")
                        {
                            Check.CheckInTime = chkin.Insert(chkin.Length - 2, " ");
                        }
                        string chkout = Convert.ToString(dr["CheckOuttime"]);
                        if (chkout != "")
                        {
                            Check.CheckOutTime = chkout.Insert(chkout.Length - 2, " ");
                            Check.WorkReport = Convert.ToString(dr["WorkReport"]);
                        }
                        Check.Dated = Convert.ToString(dr["Dated"]);
                    }
                    return Check;
                }
            }
        }

        public int MarkOnLeave(EmployeeCheckEntity Check)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@count";
                using (IDbCommand cmd = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_MarkOnLeave",
                    new SqlParameter("@employeeid", Check.EmployeeId),
                    new SqlParameter("@dated", Check.Dated),
                    new SqlParameter("@endleavedate", Check.EndLeaveDate),
                    new SqlParameter("@reason", Check.Reason), parameter
                    ))
                {
                    int count = Convert.ToInt32(parameter.Value);
                    return count;
                }
            }
        }

        public List<EmployeeCheckEntity> GetEmployeeLeaveAndCheckStatus(int employeeId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeCheckEntity> employeeleaveandchecklist = new List<EmployeeCheckEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetEmployeeLeaveAndCheckStatus",
                    new SqlParameter("@employeeid", employeeId)))
                    while (dr.Read())
                    {
                        EmployeeCheckEntity employeeleave = new EmployeeCheckEntity();
                        employeeleave.CheckId = (int)dr["CheckId"];

                        employeeleave.CheckInTime = dr["CheckInTime"].ToString();
                        string incheck = employeeleave.CheckInTime;
                        if (incheck != DBNull.Value.ToString())
                        {
                            DateTime checkin = DateTime.Parse(employeeleave.CheckInTime);
                            employeeleave.CheckInTime = checkin.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                        }

                        employeeleave.CheckOutTime = dr["CheckOutTime"].ToString();
                        string outcheck = employeeleave.CheckOutTime;
                        if (outcheck != DBNull.Value.ToString())
                        {
                            DateTime checkout = DateTime.Parse(employeeleave.CheckOutTime);
                            employeeleave.CheckOutTime = checkout.ToString("hh:mm tt", CultureInfo.InvariantCulture);
                        }
                        employeeleave.Dated = dr["Dated"].ToString();
                        employeeleave.EndLeaveDate = dr["EndLeaveDate"].ToString();
                        bool leave = (bool)(dr["IsLeave"]);
                        if (leave == true)
                        {
                            employeeleave.OnLeave = "Leave";
                            employeeleave.Color = "Red";
                        }
                        else
                        {
                            employeeleave.OnLeave = "Present";
                            employeeleave.Color = "Green";
                        }
                        //if (Convert.ToDateTime(employeeleave.Dated) < DateTime.Now && Convert.ToDateTime(employeeleave.EndLeaveDate) < DateTime.Now)
                        //{
                        //    employeeleave.Color = "Green";
                        //}
                        //else if (Convert.ToDateTime(employeeleave.Dated) < DateTime.Now && Convert.ToDateTime(employeeleave.EndLeaveDate) > DateTime.Now)
                        //{
                        //    employeeleave.Color = "Purple";
                        //}
                        //else if (Convert.ToDateTime(employeeleave.Dated) > DateTime.Now && Convert.ToDateTime(employeeleave.EndLeaveDate) > DateTime.Now)
                        //{
                        //    employeeleave.Color = "Red";
                        //}
                        employeeleaveandchecklist.Add(employeeleave);
                    }
                return employeeleaveandchecklist;
            }
        }

        public EmployeeCheckEntity GetLeavedetailofEmployee(int checkid)
        {
            EmployeeCheckEntity Check = new EmployeeCheckEntity();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetLeavedetailofEmployee",
                    new SqlParameter("@checkid", checkid)
                    ))
                {
                    if (dr.Read())
                    {
                        Check.CheckId = Convert.ToInt32(dr["CheckId"]);
                        Check.Dated = Convert.ToString(dr["Dated"]);
                        Check.EndLeaveDate = (dr["EndLeavedate"]).ToString();
                        Check.CheckInTime = dr["CheckInTime"].ToString();
                        Check.CheckOutTime = dr["CheckOutTime"].ToString();
                        Check.Reason = dr["Reason"].ToString();
                        bool leave = (bool)(dr["IsLeave"]);
                        if (leave == true)
                        {
                            Check.OnLeave = "Leave";
                        }
                        else
                        {
                            Check.OnLeave = "Present";
                        }
                        Check.WorkReport = dr["WorkReport"].ToString();

                    }
                    return Check;
                }
            }
        }

        public string UpdateEmployeeLeaveDetail(EmployeeCheckEntity check)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand cmd = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_UpdateEmployeeLeaveDetail",
                    new SqlParameter("@checkid", check.CheckId),
                    new SqlParameter("@dated", check.Dated),
                    new SqlParameter("@endleavedate", check.EndLeaveDate),
                    new SqlParameter("@reason", check.Reason)
                    ))
                {
                    return "Updated Successfully";
                }
            }
        }

        public string DeleteEmployeeleaveDetail(int checkid)
        {
            using (ADOExecution exec = new ADOExecution(DataAccess.SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_DeleteEmployeeleaveDetail",

                    new SqlParameter("@checkid", checkid)
                    ))
                {

                }
            }
            return "Deleted Successfully";
        }

        public List<EmployeeCheckEntity> GetDateOfleave(int employeeid)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeCheckEntity> dateofleave = new List<EmployeeCheckEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetDateOfleave",
                    new SqlParameter("@employeeid", employeeid)))
                    while (dr.Read())
                    {
                        EmployeeCheckEntity leave = new EmployeeCheckEntity();
                        leave.Dated = dr["Dated"].ToString();
                        leave.EndLeaveDate = dr["EndLeaveDate"].ToString();
                        dateofleave.Add(leave);
                    }
                return dateofleave;
            }
        }

        /// <summary>
        /// Retreive Work Report of all employees for sending email
        /// </summary>
        /// <returns></returns>
        public DataTable SendWorkReportEmail()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_sendworkreportemail", null))
                {
                    using (DataTable dt = new DataTable())
                    {
                        dt.Load(dr);
                        return dt;
                    }
                }

            }
        }



        public List<EmployeeCheckEntity> GetEmployeeNotCheckInMail()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeCheckEntity> candidatesList = new List<EmployeeCheckEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetEmployeeNotCheckInDetails"))
                {
                    while (dr.Read())
                    {
                        EmployeeCheckEntity report = new EmployeeCheckEntity();
                        //report.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        report.Name = Convert.ToString(dr["Name"]);
                        report.EmployeeMail = Convert.ToString(dr["OfficeEmail"]);
                        report.Today = Convert.ToString(dr["Today"]);
                        report.TodayDate = Convert.ToString(dr["TodayDate"]);
                        report.FestivalDate = Convert.ToString(dr["FestivalDate"]);
                        report.CheckInTime = Convert.ToString(dr["CheckInTime"]);
                        report.CheckOutTime = Convert.ToString(dr["CheckOutTime"]);
                        candidatesList.Add(report);
                    }
                    return candidatesList;
                }
            }


        }
        /// <summary>
        /// WorkReport List
        /// </summary>
        public List<EmployeeCheckEntity> GetWorkStatusList(int employeeid, int year, int month, int day)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeCheckEntity> candidatesList = new List<EmployeeCheckEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_selectworkreport",
                    new SqlParameter("@employeeid", employeeid),
                    new SqlParameter("@month", month),
                    new SqlParameter("@year", year),
                    new SqlParameter("@day", day)
                     ))
                {
                    while (dr.Read())
                    {
                        EmployeeCheckEntity report = new EmployeeCheckEntity();
                        report.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        report.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Convert.ToString(dr["Name"]).ToLower());
                        report.CheckInTime = Convert.ToString(dr["CheckInTime"]);
                        report.CheckOutTime = Convert.ToString(dr["CheckOutTime"]);
                        report.WorkReport = Convert.ToString(dr["WorkReport"]);
                        report.CreatedOn = Convert.ToString(dr["CreatedOn"]);
                        candidatesList.Add(report);
                    }
                    return candidatesList;
                }
            }
        }

        public List<EmployeeCheckEntity> GetActiveEmployeeNames()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeCheckEntity> emp = new List<EmployeeCheckEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_activeemployeenames",
                    null))
                {
                    while (dr.Read())
                    {
                        EmployeeCheckEntity emplist = new EmployeeCheckEntity();
                        emplist.Name = Convert.ToString(dr["Name"]);
                        emp.Add(emplist);
                    }
                    return emp;
                }
            }
        }


        public DataSet GetAttendanceOfLastThirtyDays(string starttime, string endtime)
        {
            //using (SqlConnection con = new SqlConnection(SQLBase.GetConnectionString()))
            //{
            //    DataTable dt = new DataTable();
            //    using (SqlCommand cmd = new SqlCommand("sp_GetAttendanceReport", con))
            //    {
            //        con.Open();
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@STARTDATE", starttime);
            //        cmd.Parameters.AddWithValue("@ENDDATE", endtime);
            //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            //        {

            //                sda.Fill(dt);


            //        }
            //        cmd.Dispose();
            //        con.Close();
            //    }
            //    return dt;

            //}


            //SqlConnection connection = new SqlConnection(SQLBase.GetConnectionString());
            ////connection.ConnectionString = "Password=sasasasas;Persist Security Info=True;User ID=sa;Initial Catalog=sasasas;Data Source=sasasas;";
            ////This doe sthe task of fetching data from sql server

            ////Create the command object
            //SqlCommand command = new SqlCommand();
            //command.CommandText = "sp_GetAttendanceReport";
            ////Inline query or stored procedure
            //command.CommandType = CommandType.StoredProcedure;
            ////adp.SelectCommand = command;
            //command.Parameters.AddWithValue("@STARTDATE", starttime);
            //command.Parameters.AddWithValue("@ENDDATE", endtime);
            //command.Connection = connection;
            //connection.Open();

            ////Open the connedction to sql server

            ////connection.Open();
            //SqlDataAdapter adp = new SqlDataAdapter(command);
            ////Fill to datatable
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //connection.Close();
            //return ds;


            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBEmployees"].ConnectionString);
            SqlCommand command = new SqlCommand("sp_GetAttendanceReport", con);
            command.Parameters.AddWithValue("@STARTDATE", starttime);
            command.Parameters.AddWithValue("@ENDDATE", endtime);

            command.CommandType = CommandType.StoredProcedure;
            con.Open();
            var adapter = new SqlDataAdapter(command);

            adapter.Fill(ds);
            con.Close();
            return ds;

        }

        public DataSet GetMonthlyAttendanceReport(string starttime, string endtime)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBEmployees"].ConnectionString);
            SqlCommand command = new SqlCommand("usp_GetMonthlyAttendanceReport", con);
            command.Parameters.AddWithValue("@STARTDATE", starttime);
            command.Parameters.AddWithValue("@ENDDATE", endtime);

            command.CommandType = CommandType.StoredProcedure;
            con.Open();
            var adapter = new SqlDataAdapter(command);

            adapter.Fill(ds);
            con.Close();
            return ds;

        }

        public string GetWorkingHourOfEmployee(int employeeid, string date)
        {
            string workinghour = "";
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetWorkingHourOfEmployee",
                    new SqlParameter("@employeeid", employeeid),
                    new SqlParameter("@date", date)
                    ))
                {
                    if (dr.Read())
                    {
                        workinghour = dr["WorkingHour"].ToString();

                    }
                    return workinghour;
                }
            }
        }



        public EmployeeCheckEntity GetCheckinDetailOfEmployeeeBasedOnGivenDate(int employeeid, string date)
        {
            EmployeeCheckEntity Check = new EmployeeCheckEntity();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetCheckinDetailOfEmployeeeBasedOnGivenDate",
                    new SqlParameter("@employeeid", employeeid),
                    new SqlParameter("@date", date)
                    ))
                {
                    if (dr.Read())
                    {

                        Check.CheckInTime = dr["CheckInTime"].ToString();
                        Check.CheckOutTime = dr["CheckOutTime"].ToString();
                        Check.Name = dr["Name"].ToString();
                        Check.WorkReport = dr["WorkReport"].ToString();

                    }
                    return Check;
                }
            }
        }
        public List<EmployeeCheckEntity> GetFestivalDetail()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeCheckEntity> candidatesList = new List<EmployeeCheckEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getholidays"))
                {
                    while (dr.Read())
                    {
                        EmployeeCheckEntity report = new EmployeeCheckEntity();
                        report.HolidayId = Convert.ToInt32(dr["HolidayId"]);
                        report.FestivalDate = Convert.ToString(dr["FestivalDate"]);

                        candidatesList.Add(report);
                    }
                    return candidatesList;
                }
            }


        }
        public List<EmployeeCheckEntity> GetDetails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeCheckEntity> candidatesList = new List<EmployeeCheckEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getholidays"))
                {
                    while (dr.Read())
                    {
                        EmployeeCheckEntity report = new EmployeeCheckEntity();
                        report.HolidayId = Convert.ToInt32(dr["HolidayId"]);
                        report.FestivalDate = Convert.ToString(dr["FestivalDate"]);

                        candidatesList.Add(report);
                    }
                    return candidatesList;
                }
            }


        }

        #endregion
    }


}
