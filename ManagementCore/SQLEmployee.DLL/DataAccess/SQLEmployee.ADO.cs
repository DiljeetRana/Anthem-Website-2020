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
using System.Web;
using System.Globalization;
using System.Security.Cryptography;


namespace SQLEmployee.DLL.DataAccess
{
    public partial class SQLEmployee
    {
        #region All ADO Operations

        /// <summary>
        /// All Employees Records from Database
        /// </summary>
        /// <returns></returns>
        /// 
        public string EncryptPassword(string password)
        {
            string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(password);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public string DecryptPassword(string encryptpass)
        {
            try
            {
                encryptpass = encryptpass.Replace(" ", "+");
                string DecryptKey = "2013;[pnuLIT)WebCodeExpert";
                byte[] byKey = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                byte[] inputByteArray = new byte[encryptpass.Length];

                byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(encryptpass.Replace(" ", "+"));
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        public List<EmployeeEntity.EmployeeEntity> GetFilteredEmployees()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getActiveuser", null))
                {
                    while (dr.Read())
                    {
                        var dd = dr["Birthday"].ToString();
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (long)dr["EmployeeId"];
                        employee.EmpCode = dr["EmpCode"].ToString();
                        employee.Name = dr["Name"].ToString();
                        employee.Gender = dr["Gender"].ToString();
                        employee.Designation = dr["Designation"].ToString();
                        employee.JoiningDate = dr["JoiningDate"].ToString();
                        employee.ContactNumber = dr["ContactNumber"].ToString();
                        employee.Status = dr["StatusName"].ToString();
                        employee.Birthday = DateTime.ParseExact(dd, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                        // Convert.ToDateTime(dr["Birthday"]); //DateTime.ParseExact(dd, "MM/dd/yyyy", CultureInfo.InvariantCulture); 
                        employee.OfficeEmail = dr["OfficeEmail"].ToString();
                        employee.IsVerified = dr["Isverified"].ToString();
                        employee.Password = dr["Password"].ToString();

                        var encryptpass = dr["Password"].ToString();

                        string decrypt = DecryptPassword(encryptpass);
                        employee.Password = decrypt;



                        if (dr["ActiveId"] == DBNull.Value)
                        {
                            employee.ActiveId = 0;
                        }
                        else
                        {
                            employee.ActiveId = (int)dr["ActiveId"];
                        }
                        employeelist.Add(employee);
                        employee.password = string.Empty;
                    }
                }
                return employeelist;
            }
            //return null;
        }

        public List<EmployeeEntity.EmployeeEntity> GetEmployees()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getuser", null))
                {
                    while (dr.Read())
                    {
                        var dd = dr["Birthday"].ToString();
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (long)dr["EmployeeId"];
                        employee.EmpCode = dr["EmpCode"].ToString();
                        employee.Name = dr["Name"].ToString();
                        employee.Gender = dr["Gender"].ToString();
                        employee.Designation = dr["Designation"].ToString();
                        employee.JoiningDate = dr["JoiningDate"].ToString();
                        employee.ContactNumber = dr["ContactNumber"].ToString();
                        employee.Status = dr["StatusName"].ToString();
                        employee.Birthday = DateTime.ParseExact(dd, "MM-dd-yyyy", CultureInfo.InvariantCulture);
                        // Convert.ToDateTime(dr["Birthday"]); //DateTime.ParseExact(dd, "MM/dd/yyyy", CultureInfo.InvariantCulture); 
                        employee.OfficeEmail = dr["OfficeEmail"].ToString();
                        employee.IsVerified = dr["Isverified"].ToString();
                        employee.Password = dr["Password"].ToString();

                        var encryptpass = dr["Password"].ToString();

                        string decrypt = DecryptPassword(encryptpass);
                        employee.Password = decrypt;



                        if (dr["ActiveId"] == DBNull.Value)
                        {
                            employee.ActiveId = 0;
                        }
                        else
                        {
                            employee.ActiveId = (int)dr["ActiveId"];
                        }
                        employeelist.Add(employee);
                        employee.password = string.Empty;
                    }
                }
                return employeelist;
            }
        }

        /// <summary>
        /// Add New Employee Record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string AddEmployees(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@status";
                parameter.Size = 50;

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_insertuser",
                    new SqlParameter("@empcode", employee.EmpCode),
                    new SqlParameter("@name", employee.Name),
                    new SqlParameter("@gender", employee.Gender),
                    new SqlParameter("@designation", employee.Designation),
                    new SqlParameter("@contactnumber", employee.ContactNumber),
                    new SqlParameter("@alternatenumber", employee.AlternateNumber),
                    new SqlParameter("@email", employee.Email),
                    new SqlParameter("@officeemail", employee.OfficeEmail),
                    new SqlParameter("@birthday", employee.Birthday),
                    new SqlParameter("@aniversary", employee.Aniversary),
                    new SqlParameter("@contactaddress", employee.ContactAddress),
                    new SqlParameter("@joiningdate", employee.JoiningDate),
                    new SqlParameter("@statusid", employee.StatusId),
                    new SqlParameter("@lasthikedate", employee.LastHikeDate),
                    new SqlParameter("@currentsalary", employee.CurrentSalary),
                    new SqlParameter("@nexthikeduedate", employee.NextHikeDueDate),
                    new SqlParameter("@picture", employee.Photo),
                    new SqlParameter("@gradeid", employee.GradeId),
                    new SqlParameter("@isdeleted", employee.IsDeleted),
                    new SqlParameter("@creation", employee.Creation),
                    new SqlParameter("@isverified", employee.IsVerified),
                    new SqlParameter("@islogin", employee.IsFirstLogin),
                    new SqlParameter("@companyaccountnumber", employee.CompanyAccountNumber),
                    new SqlParameter("@anonymous1", employee.Anonymous1),
                    new SqlParameter("@anonymous2", employee.Anonymous2),
                    new SqlParameter("@anonymous3", employee.Anonymous3)
                    , parameter))
                    employee.message = parameter.Value.ToString();
                return employee.message;
            }
        }

        
        public string updateemp(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                //SqlParameter parameter = new SqlParameter();
                //parameter.SqlDbType = SqlDbType.VarChar;
                //parameter.Direction = ParameterDirection.Output;
                //parameter.ParameterName = "@status";
                //parameter.Size = 50;

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_updatetest",
                    new SqlParameter("@ename", employee.Name),
                  new SqlParameter("@addres", employee.ContactAddress),
                  new SqlParameter("@gradeid", employee.GradeId),
                  new SqlParameter("@isverified", employee.IsVerified)
                    //, parameter
                    ))
                    return null;
                //employee.message = parameter.Value.ToString();
            }
        }
        public string updateLeaveRequest(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_updateLeaveRequest",
                  new SqlParameter("@empid", employee.ActiveId),
                  new SqlParameter("@status", employee.StatusId)
                    ))
                    return null;
            }
        }
        public string InsertLeaveDetails(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertLeaveDetails",
                  new SqlParameter("@empid", employee.EmployeeId),
                  new SqlParameter("@startdate", employee.LeaveStartDate),
                  new SqlParameter("@enddate", employee.LeaveEndDate),
                  new SqlParameter("@reason", employee.Reason),
                  new SqlParameter("@reqdate", employee.Creation),
                  new SqlParameter("@noofdays", employee.NoOfDays)
                    ))
                    return null;
            }
        }
        /// <summary>
        /// Update Employee Record
        /// </summary>
        /// <param name="employeeentity"></param>
        /// <returns></returns>
        public string UpdateEmployee(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@status";
                parameter.Size = 50;
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_updateemployee",
                    new SqlParameter("@employeeid", employee.EmployeeId),
                    new SqlParameter("@empcode", employee.EmpCode),
                    new SqlParameter("@name", employee.Name),
                    new SqlParameter("@gender", employee.Gender),
                    new SqlParameter("@designation", employee.Designation),
                    new SqlParameter("@contactnumber", employee.ContactNumber),
                    new SqlParameter("@alternatenumber", employee.AlternateNumber),
                    new SqlParameter("@email", employee.Email),
                    new SqlParameter("@officeemail", employee.OfficeEmail),
                    new SqlParameter("@birthday", employee.Birthday),
                    new SqlParameter("@aniversary", employee.Aniversary),
                    new SqlParameter("@contactaddress", employee.ContactAddress),
                    new SqlParameter("@joiningdate", employee.JoiningDate),
                    new SqlParameter("@statusid", employee.StatusId),
                    new SqlParameter("@lasthikedate", employee.LastHikeDate),
                    new SqlParameter("@currentsalary", employee.CurrentSalary),
                    new SqlParameter("@nexhikeduedate", employee.NextHikeDueDate),
                    new SqlParameter("@picture", employee.Photo),
                    new SqlParameter("@gradeid", employee.GradeId),
                    new SqlParameter("@isverified", employee.IsVerified),
                    new SqlParameter("@password", employee.Password),
                    new SqlParameter("@companyaccountnumber", employee.CompanyAccountNumber),
                    new SqlParameter("@anonymous1", employee.Anonymous1),
                    new SqlParameter("@anonymous2", employee.Anonymous2),
                    new SqlParameter("@anonymous3", employee.Anonymous3)
                    , parameter))
                    employee.message = parameter.Value.ToString();
                return employee.message;
            }
        }

        /// <summary>
        /// Fetch Status Id and Name to Dropdownlist 
        /// </summary>
        /// <returns></returns>
        public List<EmployeeEntity.EmployeeEntity> GetStatusIdAndName()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getstatusidandname", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.StatusId = (int)dr["StatusId"];
                        employee.Status = dr["StatusName"].ToString();
                        employeelist.Add(employee);
                    }
                    return employeelist;
                }
            }
        }

        public List<EmployeeEntity.EmployeeEntity> GetLeaveDetails(EmployeeEntity.EmployeeEntity employees)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getleavedetail",
                   new SqlParameter("@empid", employees.EmployeeId)))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (int)dr["EmployeeId"];
                        employee.LeaveStartDate = dr["StartDate"].ToString();
                        employee.LeaveEndDate = dr["EndDate"].ToString();
                        employee.Creation = Convert.ToDateTime(dr["RequestDate"]);
                        employee.Status = dr["StatusName"].ToString();
                        employee.Reason = dr["Reason"].ToString();
                        employee.NoOfDays = dr["NoOfDays"].ToString();
                        employeelist.Add(employee);
                    }
                    return employeelist;
                }
            }
        }

        public List<EmployeeEntity.EmployeeEntity> GetLeaveDetailsforadmin(EmployeeEntity.EmployeeEntity employees)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getleavedetailforadmin",
                    new SqlParameter("@empid", employees.EmployeeId),
                    new SqlParameter("@status", employees.Status)
                    ))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (int)dr["EmployeeId"];
                        employee.ActiveId = (int)dr["Id"];
                        employee.Name = dr["Name"].ToString();
                        employee.LeaveStartDate = dr["StartDate"].ToString();
                        employee.LeaveEndDate = dr["EndDate"].ToString();
                        employee.Creation = Convert.ToDateTime(dr["RequestDate"]);
                        employee.Reason = dr["Reason"].ToString();
                        employee.NoOfDays = dr["NoOfDays"].ToString();
                        employee.Status = dr["StatusName"].ToString();
                        employeelist.Add(employee);
                    }
                    return employeelist;
                }
            }
        }

        public List<EmployeeEntity.EmployeeEntity> checkforleaverequest(EmployeeEntity.EmployeeEntity employees)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_checkforleaverequest",
                    new SqlParameter("@empid", employees.EmployeeId),
                    new SqlParameter("@startdate", employees.LeaveStartDate),
                    new SqlParameter("@enddate", employees.LeaveEndDate)
                    ))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (int)dr["EmployeeId"];
                        employee.ActiveId = (int)dr["Id"];
                        employee.Creation = Convert.ToDateTime(dr["RequestDate"]);
                        employee.Reason = "Already requested";
                        employee.NoOfDays = dr["NoOfDays"].ToString();
                        employeelist.Add(employee);
                    }
                    return employeelist;
                }
            }
        }

        public List<EmployeeEntity.EmployeeEntity> Getnameforadmin(EmployeeEntity.EmployeeEntity employees)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getnameforadmin", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.Name = dr["Name"].ToString();
                        employee.EmployeeId = Convert.ToInt16(dr["EmployeeId"].ToString());
                        employeelist.Add(employee);
                    }
                    return employeelist;
                }
            }
        }


        public EmployeeEntity.EmployeeEntity getOfficeEmail(int userId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getofficeemail",
                   new SqlParameter("@empid", userId)))
                {
                    while (dr.Read())
                    {
                        employee.OfficeEmail = dr["OfficeEmail"].ToString();

                    }
                    return employee;
                }
            }
        }

        public EmployeeEntity.EmployeeEntity getdetailstosendmail(EmployeeEntity.EmployeeEntity employees)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getdetailstosendmail",
                   new SqlParameter("@id", employees.ActiveId)))
                {
                    while (dr.Read())
                    {
                        employees.OfficeEmail = dr["OfficeEmail"].ToString();
                        employees.Name = dr["Name"].ToString();
                        employees.Reason = dr["Reason"].ToString();
                        employees.LeaveStartDate = dr["StartDate"].ToString();
                        employees.LeaveEndDate = dr["EndDate"].ToString();
                        employees.NoOfDays = dr["NoOfDays"].ToString();
                        employees.Status = dr["ApprovalStatus"].ToString();
                    }
                    return employees;
                }
            }
        }

        /// <summary>
        /// Fetch Grade Id and Grade Name to Dropdownlist
        /// </summary>
        /// <returns></returns>
        public List<EmployeeEntity.EmployeeEntity> GetGradeIdAndName()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getgradeidandname", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.GradeId = (int)dr["GradeId"];
                        employee.Grade = dr["Grade"].ToString();
                        employeelist.Add(employee);
                    }
                    return employeelist;
                }
            }
        }

        /// <summary>
        /// Delete Employee Record from Admin Not Underlying Table
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public string DeleteEmployee(long employeeid)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_deleteuser",
                    new SqlParameter("@employeeid", employeeid),
                    new SqlParameter("@isdeleted", 1)))
                    return "Delete Successfully";
            }
        }

        /// <summary>
        /// Retrieve  Employee Record By EmployeeId
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>

        public EmployeeEntity.EmployeeEntity GetEmployeeDetailsById(long employeeid)
        {
            using (ADOExecution exec = new ADOExecution(DataAccess.SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getuserbyid",

                 new SqlParameter("@employeeid", employeeid)
                 ))
                {
                    while (dr.Read())
                    {
                        employee.EmpCode = dr["EmpCode"].ToString();
                        employee.Name = dr["Name"].ToString();
                        employee.Gender = dr["Gender"].ToString();
                        employee.Designation = dr["Designation"].ToString();
                        employee.ContactNumber = dr["ContactNumber"].ToString();
                        employee.AlternateNumber = dr["AlternateNumber"].ToString();
                        employee.Email = dr["Email"].ToString();
                        employee.OfficeEmail = dr["OfficeEmail"].ToString();
                        employee.Birthday = (DateTime)dr["Birthday"];
                        employee.Aniversary = dr["Aniversary"].ToString();
                        employee.ContactAddress = dr["ContactAddress"].ToString();
                        employee.JoiningDate = dr["JoiningDate"].ToString();
                        employee.Status = dr["StatusName"].ToString();
                        employee.LastHikeDate = dr["LastHikeDate"].ToString();
                        employee.CurrentSalary = dr["CurrentSalary"].ToString();
                        employee.NextHikeDueDate = dr["NextHikeDueDate"].ToString();
                        employee.Grade = dr["Grade"].ToString();
                        employee.Password = dr["Password"].ToString();
                        employee.CompanyAccountNumber = dr["CompanyAccountNumber"].ToString();
                        employee.Anonymous1 = dr["Anonymous1"].ToString();
                        employee.Anonymous2 = dr["Anonymous2"].ToString();
                        employee.Anonymous3 = dr["Anonymous3"].ToString();
                    }
                }

                return employee;
            }
        }

        /// <summary>
        /// Retrieve  Employee Record By EmployeeId
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public EmployeeEntity.EmployeeEntity GetEmployeeById(long employeeid)
        {
            using (ADOExecution exec = new ADOExecution(DataAccess.SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getuserbyid",

                 new SqlParameter("@employeeid", employeeid)
                 ))
                {
                    while (dr.Read())
                    {
                        employee.EmpCode = dr["EmpCode"].ToString();
                        employee.Name = dr["Name"].ToString();
                        employee.Gender = dr["Gender"].ToString();
                        employee.Designation = dr["Designation"].ToString();
                        employee.ContactNumber = dr["ContactNumber"].ToString();
                        employee.AlternateNumber = dr["AlternateNumber"].ToString();
                        employee.Email = dr["Email"].ToString();
                        employee.OfficeEmail = dr["OfficeEmail"].ToString();
                        employee.Birthday = (DateTime)dr["Birthday"];
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
                        if (dr["GradeId"] == DBNull.Value)
                        {
                            employee.GradeId = 0;
                        }
                        else
                        {
                            employee.GradeId = (int)dr["GradeId"];
                        }
                        if (dr["StatusId"] == DBNull.Value)
                        {
                            employee.StatusId = 0;
                        }
                        else
                        {
                            employee.StatusId = (int)dr["StatusId"];
                        }
                        employee.Password = dr["Password"].ToString();
                        if (dr["IsVerified"] == DBNull.Value)
                        {
                            employee.IsVerified = "0";
                        }
                        else
                        {
                            employee.IsVerified = dr["IsVerified"].ToString();
                        }
                    }
                }

                return employee;
            }
        }

        /// <summary>
        /// retrieve Image of employee by employee id
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public Stream DisplayImage(long employeeid)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_retrieveimage",
                    new SqlParameter("@employeeid", employeeid)))
                {
                    dr.Read();
                    object theImg = dr["Picture"];

                    try
                    {
                        return new MemoryStream((byte[])theImg);
                    }
                    catch
                    {
                        return null;
                    }

                }
            }

        }

        /// <summary>
        /// if Username and Password is Correct Than Logged In
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int CheckUsernameAndPassword(string username, string password)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_CheckUsernameAndPassword",
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)))
                {
                    int returncode = 0;
                    if (dr.Read())
                    {
                        returncode = 1;
                    }
                    else
                    {
                        returncode = 0;
                    }
                    return returncode;
                }
            }
        }

        /// <summary>
        /// get all employees record in datatable
        /// </summary>
        /// <returns></returns>
        public DataTable EmployeesReportInExcel()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader cmd = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getallemployees", null))
                {
                    using (DataTable dt = new DataTable())
                    {
                        dt.Load(cmd);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// get employees upcoming birthdays,anniversary
        /// </summary>
        /// <returns></returns>
        //public DataTable GetUpcomingBirthdayAndAnniversary()
        //{
        //    using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
        //    {
        //        using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_namebirthdayandanniversary", null))
        //        {
        //            using (DataTable dt = new DataTable())
        //            {
        //                dt.Load(dr);
        //                return dt;
        //            }
        //        }
        //    }
        //}
        public List<EmployeeEntity.EmployeeEntity> GetUpcomingBirthdayAndAnniversary()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeeEntities = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_namebirthdayandanniversary", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (Int64)dr["EmployeeId"];
                        employee.Name = dr["Name"].ToString();
                        employee.Type = dr["Type"].ToString();
                        employee.Date = dr["Date"].ToString();
                        employee.Day = dr["All_Day"].ToString();
                        employeeEntities.Add(employee);
                    }
                    return employeeEntities;
                }
            }
        }

        /// <summary>
        /// get holidays for current year
        /// </summary>
        /// <returns></returns>
        public List<HolidayEnitity> GetHolidaysList()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<HolidayEnitity> holidayentity = new List<HolidayEnitity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getholidays", null))
                {
                    while (dr.Read())
                    {
                        HolidayEnitity holiday = new HolidayEnitity();
                        holiday.HolidayId = (int)dr["HolidayId"];
                        holiday.FestivalName = dr["FestivalName"].ToString();
                        holiday.FestivalDate = dr["FestivalDate"].ToString();
                        holiday.FestivalDay = dr["FestivalDay"].ToString();
                        holidayentity.Add(holiday);
                    }
                    return holidayentity;
                }
            }
        }

        /// <summary>
        /// get years of holidays
        /// </summary>
        /// <returns></returns>
        public List<HolidayEnitity> GetYearOfHoliday()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<HolidayEnitity> holidayentity = new List<HolidayEnitity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getyearofholidays", null))
                {
                    while (dr.Read())
                    {
                        HolidayEnitity holiday = new HolidayEnitity();
                        holiday.FestivalDate = dr["FestivalDate"].ToString();
                        holidayentity.Add(holiday);
                    }
                    return holidayentity;
                }
            }
        }

        /// <summary>
        /// get holidays list by year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<HolidayEnitity> GetHolidaysByYear(string year)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<HolidayEnitity> holidayentity = new List<HolidayEnitity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getholidaysbyyear",
                    new SqlParameter("@year", year)))
                {
                    while (dr.Read())
                    {
                        HolidayEnitity holiday = new HolidayEnitity();
                        holiday.HolidayId = (int)dr["HolidayId"];
                        holiday.FestivalName = dr["FestivalName"].ToString();
                        holiday.FestivalDate = dr["FestivalDate"].ToString();

                        holiday.FestivalDay = dr["FestivalDay"].ToString();
                        holidayentity.Add(holiday);
                    }

                    return holidayentity;
                }
            }
        }

        /// <summary>
        /// delete holiday by holidayid
        /// </summary>
        /// <param name="holidayid"></param>
        /// <returns></returns>
        public int DeleteHolidayById(int holidayid)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_deleteholidaybyid",
                    new SqlParameter("@holidayid", holidayid)))
                    return 0;
            }
        }

        /// <summary>
        /// insert new holiday
        /// </summary>
        /// <param name="holidayentity"></param>
        /// <returns></returns>
        public string AddHolidays(HolidayEnitity holidayentity)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@message";
                parameter.Size = 50;
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_insertholiday",
                    new SqlParameter("@festivalname", holidayentity.FestivalName),
                    new SqlParameter("@festivaldate", holidayentity.FestivalDate),
                    new SqlParameter("@festivalday", holidayentity.FestivalDay), parameter))
                    holidayentity.Message = parameter.Value.ToString();
                return holidayentity.Message;
            }
        }

        /// <summary>
        /// get holiday name and date by id 
        /// </summary>
        /// <param name="holidayid"></param>
        /// <returns></returns>
        public HolidayEnitity GetFestivalNameAndDateById(int holidayid)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                HolidayEnitity holidayentity = new HolidayEnitity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_getholidaybyid",
                    new SqlParameter("@holidayid", holidayid)))
                {
                    if (dr.Read())
                    {
                        holidayentity.FestivalName = dr["FestivalName"].ToString();
                        holidayentity.FestivalDate = dr["FestivalDate"].ToString();
                    }
                    return holidayentity;
                }
            }
        }

        /// <summary>
        /// update holiday name and date
        /// </summary>
        /// <param name="holidayentity"></param>
        /// <returns></returns>
        public string UpdateHoliday(HolidayEnitity holidayentity)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@message";
                parameter.Size = 50;
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_updateholiday",
                    new SqlParameter("@holidayid", holidayentity.HolidayId),
                    new SqlParameter("@festivalname", holidayentity.FestivalName),
                    new SqlParameter("@festivaldate", holidayentity.FestivalDate),
                    new SqlParameter("@festivalday", holidayentity.FestivalDay), parameter))
                    holidayentity.Message = parameter.Value.ToString();
                return holidayentity.Message;
            }
        }

        /// <summary>
        /// get employees today birthday's,anniversary and completed one year in company
        /// </summary>
        /// <returns></returns>
        public List<EmployeeEntity.EmployeeEntity> TodayOccasions()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeeentity = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_todayoccasions", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.Name = dr["Name"].ToString();
                        employee.EmployeeId = (long)dr["EmployeeId"];
                        employee.Occasions = dr["happy"].ToString();
                        employeeentity.Add(employee);
                    }
                    return employeeentity;
                }
            }
        }

        /// <summary>
        /// get all employees whose on payroll
        /// </summary>
        /// <returns></returns>
        public List<EmployeeEntity.EmployeeEntity> OurTeam()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeeentity = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_ourteam", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.Name = dr["Name"].ToString();
                        employee.EmployeeId = (long)dr["EmployeeId"];
                        employee.Designation = dr["Designation"].ToString();
                        employeeentity.Add(employee);
                    }
                    return employeeentity;
                }
            }
        }

        /// <summary>
        /// retreive employees whose birthday,anniversary today for sending email
        /// </summary>
        /// <returns></returns>
        public DataTable SendEmailToTodayOccasions()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_sendemailonoccasions", null))
                {
                    using (DataTable dt = new DataTable())
                    {
                        dt.Load(dr);
                        return dt;
                    }
                }
            }
        }

        //underdeveloped method
        public List<EmployeeEntity.EmployeeEntity> ActiveMembersEmail()
        {
            List<EmployeeEntity.EmployeeEntity> Obj_List = new List<EmployeeEntity.EmployeeEntity>();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetActiveEmployeesEmail", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity Obj = new EmployeeEntity.EmployeeEntity();
                        Obj.Email = dr["Email"].ToString();
                        Obj_List.Add(Obj);
                    }
                    return Obj_List;
                }
            }
        }


        /// <summary>
        /// get employees name and id
        /// </summary>
        /// <returns></returns>
        public List<EmployeeEntity.EmployeeEntity> GetEmployeesEmailId()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetEmployeesName", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (long)dr["EmployeeId"];

                        string[] name = dr["Name"].ToString().Split(' ');
                        string firstname = name[0].First().ToString().ToUpper() + name[0].Substring(1);
                        string lastname;
                        string fullname;
                        if (name.Length > 1)
                        {
                            lastname = name[1].First().ToString().ToUpper() + name[1].Substring(1);
                            fullname = firstname + " " + lastname;
                            employee.Name = fullname;
                        }
                        else
                        {
                            fullname = firstname;
                            employee.Name = fullname;
                        }

                        employeelist.Add(employee);
                    }
                }
                return employeelist;
            }
        }

        /// <summary>
        /// get email id's by employee id.
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        public EmployeeEntity.EmployeeEntity GetEmailIdByEmployeeId(long employeeid)
        {
            EmployeeEntity.EmployeeEntity employeeentity = new EmployeeEntity.EmployeeEntity();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetEmailIdByEmployee",
                    new SqlParameter("@employeeid", employeeid)))
                {
                    if (dr.Read())
                    {
                        employeeentity.OfficeEmail = dr["OfficeEmail"].ToString();
                    }
                }
                return employeeentity;
            }
        }

        public int ChangeAdminPassword(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_changeadminpassword",
                    new SqlParameter("@username", employee.Username),
                    new SqlParameter("@password", employee.Password)))
                    return 0;
            }
        }

        public List<EmployeeEntity.EmployeeEntity> EmployeesLoginDetails()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeeslist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_EmployeesLoginDetails", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (long)dr["EmployeeId"];
                        employee.Name = dr["EmpName"].ToString();
                        employee.OfficeEmail = dr["OfficeEmail"].ToString();
                        employee.Password = dr["Password"].ToString();
                        if (dr["ActiveId"] == DBNull.Value)
                        {
                            employee.ActiveId = 0;
                        }
                        else
                        {
                            employee.ActiveId = (int)dr["ActiveId"];
                        }
                        employee.ActiveName = dr["Name"].ToString();
                        employeeslist.Add(employee);
                    }
                    return employeeslist;
                }

            }
        }

        public EmployeeEntity.EmployeeEntity EmployeeForgotPassword(string username)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_ForgotPassword",
                    new SqlParameter("@username", username)))
                    if (dr.Read())
                    {
                        employee.Password = dr["Password"].ToString();
                    }

                return employee;
            }
        }

        public int EmployeeChangePassword(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_employeechangepassword",
                    new SqlParameter("@username", employee.OfficeEmail),
                    new SqlParameter("@password", employee.Password)))
                    return 0;
            }
        }

        public EmployeeEntity.EmployeeEntity EmployeeProfileByUsername(string username)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_EmployeeProfile",
                    new SqlParameter("@username", username)))
                    if (dr.Read())
                    {
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
                        employee.CompanyAccountNumber = dr["CompanyAccountNumber"].ToString();
                        employee.Anonymous1 = dr["Anonymous1 "].ToString();
                        employee.Anonymous2 = dr["Anonymous2"].ToString();
                        employee.Anonymous3 = dr["Anonymous3"].ToString();
                    }
                return employee;
            }
        }


        public string AddDoc(EmployeeEntity.DocumentEntity DocName)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                string message;
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@message";
                parameter.Size = 100;
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertDocument",
                new SqlParameter("@name", DocName.Name),
                new SqlParameter("@docname", DocName.DocName),
                new SqlParameter("@extension", DocName.Extension),
                new SqlParameter("@filename", DocName.FileName),
                parameter))
                    message = parameter.Value.ToString();
                return message;
            }

        }
        public List<EmployeeEntity.EmployeeEntity> GetDocuments()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> documentlist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetDocuments", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity doc = new EmployeeEntity.EmployeeEntity();
                        doc.DocId = (int)dr["DocId"];
                        doc.DocName = dr["DocName"].ToString();
                        doc.Extension = dr["Extension"].ToString();


                        if (doc.Extension == ".bmp")
                        {

                            doc.Image = "..//DocImages//bmp.jpg";
                        }
                        if (doc.Extension == ".doc")
                        {
                            doc.Image = "..//DocImages//doc.png";
                        }
                        if (doc.Extension == ".docx")
                        {
                            doc.Image = "..//DocImages//docx.png";
                        }
                        if (doc.Extension == ".txt")
                        {
                            doc.Image = "..//DocImages//text.jpg";
                        }
                        if (doc.Extension == ".pdf")
                        {
                            doc.Image = "..//DocImages//pdf.jpg";
                        }
                        if (doc.Extension == ".jpeg")
                        {
                            doc.Image = "..//DocImages//JPEG.png";
                        }
                        if (doc.Extension == ".jpg")
                        {
                            doc.Image = "..//DocImages//jpg.png";
                        }
                        if (doc.Extension == ".png")
                        {
                            doc.Image = "..//DocImages//png.jpg";
                        }
                        if (doc.Extension == ".xls")
                        {
                            doc.Image = "..//DocImages//xls.jpg";
                        }
                        if (doc.Extension == ".xlsx")
                        {
                            doc.Image = "..//DocImages//xlsx.jpg";
                        }

                        doc.FileName = dr["FileName"].ToString();

                        doc.CreatedOn = (Convert.ToDateTime(dr["CreatedOn"])).ToShortDateString();
                        doc.DateUploaded = (Convert.ToDateTime(dr["CreatedOn"])).ToShortDateString();
                        //doc.DateUploaded = dr["DateUploaded"].ToString();                    
                        documentlist.Add(doc);
                    }
                    return documentlist;
                }
            }
        }
        public List<DocumentEntity> GetDocumentsById(int DocId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<DocumentEntity> documentlist = new List<DocumentEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetDocumentsById",
                    new SqlParameter("@docid", DocId)))
                {
                    if (dr.Read())
                    {
                        DocumentEntity doc = new DocumentEntity();

                        doc.DocName = dr["DocName"].ToString();
                        doc.Name = (byte[])dr["Name"];
                        //doc.Name = (Convert.ToByte(dr["Name"]));
                        doc.DateUploaded = dr["DateUploaded"].ToString();
                        doc.Extension = dr["Extension"].ToString();
                        doc.FileName = dr["FileName"].ToString();
                        doc.CreatedOn = (Convert.ToDateTime(dr["CreatedOn"])).ToShortDateString();
                        doc.DateUploaded = (Convert.ToDateTime(dr["CreatedOn"])).ToShortDateString();
                        documentlist.Add(doc);
                    }
                    return documentlist;
                }

            }

        }

        public string UpdateDoc(EmployeeEntity.DocumentEntity DocName)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                string message;
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@message";
                parameter.Size = 100;
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_UpdateDocuments",
                    new SqlParameter("@docid", DocName.DocId),
                    new SqlParameter("@name", DocName.Name),
                    new SqlParameter("@docname", DocName.DocName),
                    new SqlParameter("@extension", DocName.Extension),
                    new SqlParameter("@filename", DocName.FileName), parameter))
                    message = parameter.Value.ToString();
                return message;

            }
        }
        public int DeleteDoc(int DocId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_DeleteDocument",
                    new SqlParameter("@docid", DocId)))
                    return 0;
            }
        }

        public EmployeeEntity.EmployeeEntity GetEmployeeDetailByEmail(string email)
        {
            EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetEmployeeDetailByEmail",
                    new SqlParameter("@email", email)))
                {
                    if (dr.Read())
                    {
                        employee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        employee.ActiveId = Convert.ToInt32(dr["ActiveId"]);
                        employee.Name = dr["Name"].ToString();

                    }
                    return employee;
                }
            }
        }
        public void GenratePassword(EmployeeEntity.EmployeeEntity employee)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand cmd = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_GenratePassword",
                    new SqlParameter("@employeeid", employee.EmployeeId),
                    new SqlParameter("@password", employee.Password)))
                {

                }
            }
        }
        public EmployeeEntity.EmployeeEntity GetEmployeePassword(string officeemail)
        {

            EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                //string password = "";
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_getEmployeePassword",
                    new SqlParameter("@officialemail", officeemail)))
                {
                    if (dr.Read())
                    {
                        employee.EmployeePassword = dr["EmployeePassword"].ToString();
                        employee.EmployeePassword1 = dr["EmployeePassword1"].ToString();
                        employee.EmployeePassword2 = dr["EmployeePassword2"].ToString();

                    }
                    return employee;
                }
            }
        }

        public string UpdateUsedOTP(int employeeid, string otp)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_UpdateUsedOTP",
                    new SqlParameter("@employeeid", employeeid),
                    new SqlParameter("@otppassword", otp)
                    ))

                    return "";
            }

        }


        /// <summary>
        /// get employees name
        /// </summary>
        /// <returns></returns>
        public List<EmployeeEntity.EmployeeEntity> GetEmployeesNames()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.EmployeeEntity> employeelist = new List<EmployeeEntity.EmployeeEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetEmployeesName", null))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.EmployeeEntity employee = new EmployeeEntity.EmployeeEntity();
                        employee.EmployeeId = (long)dr["EmployeeId"];
                        string[] name = dr["Name"].ToString().Split(' ');
                        string firstname = name[0].First().ToString().ToUpper() + name[0].Substring(1);
                        string lastname;
                        string fullname;
                        if (name.Length > 1)
                        {
                            lastname = name[1].First().ToString().ToUpper() + name[1].Substring(1);
                            fullname = firstname + " " + lastname;
                            employee.Name = fullname;
                        }
                        else
                        {
                            fullname = firstname;
                            employee.Name = fullname;
                        }

                        employeelist.Add(employee);
                    }
                }
                return employeelist;
            }
        }

        //public EmployeeEntity.EmployeeEntity GetLoginNew(EmployeeEntity.EmployeeEntity Model)
        //{

        //    using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
        //    {
        //        using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetEmployeeNewlogin",
        //               new SqlParameter("@OfficeEmail", Model.OfficeEmail)                        
        //        ))
        //            return Model;

        //    }
        //}



        public EmployeeEntity.EmployeeEntity GetLoginNew(string Mail )
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.EmployeeEntity Model = new EmployeeEntity.EmployeeEntity();
                //EmployeeEntity.EmployeeProjectEntity Model = new EmployeeEntity.EmployeeProjectEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Sp_GetEmployeeNewlogin",
                    new SqlParameter("@OfficeEmail",Mail)))
                    while (dr.Read())
                    {                     
                        Model.password = dr["NewPassword"].ToString();
                        Model.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                        Model.Name = dr["Name"].ToString();
                        Model.ActiveId = Convert.ToInt32(dr["ActiveId"]);
                       

                    }
                return Model;
            }
        }

        public bool InsertException(string ext, string uploadImage)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "insert_Exception",
                    new SqlParameter("@Error", ext),
                    new SqlParameter("@MethodName", uploadImage)
                    ))

                    return true;
            }
        }
        public DataTable GetWorkAnniversary(string currYear, string currMon)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_namebirthdayandanniversary", null))
                {
                    using (DataTable dt = new DataTable())
                    {
                        dt.Load(dr);
                        return dt;
                    }
                }
            }
        }
        #endregion
    }
}
