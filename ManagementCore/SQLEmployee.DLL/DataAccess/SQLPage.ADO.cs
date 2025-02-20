using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using System.Data;
using SQLEmployee.DLL.ADO;
using System.Data.SqlClient;

namespace SQLEmployee.DLL.DataAccess
{
    public partial class SQLPage
    {
        #region Sql Operations

     

        public int AddPage(EmployeeEntity.Page page)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertPages",                   
                    new SqlParameter("@Page1title",page.Page1Title),
                    new SqlParameter("@page1content",page.Page1Content),
                    new SqlParameter("@page1status",page.Page1Status),
                    new SqlParameter("@Page2title",page.Page2Title),
                    new SqlParameter("@page2content",page.Page2Content),
                    new SqlParameter("@page2status",page.Page2Status),
                    new SqlParameter("@Page3title",page.Page3Title),
                    new SqlParameter("@page3content",page.Page3Content),
                    new SqlParameter("@page3status",page.Page3Status),
                    new SqlParameter("@Page4title",page.Page4Title),
                    new SqlParameter("@page4content",page.Page4Content),
                    new SqlParameter("@page4status",page.Page4Status),
                    new SqlParameter("@Page5title",page.Page5Title),
                    new SqlParameter("@page5content",page.Page5Content),
                    new SqlParameter("@page5status",page.Page5Status)))                
                    return 0;
            }

        }

       
        public EmployeeEntity.Page  GetPages() 
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Page page = new Page();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetPages",
                    null))
                {
                    if (dr.Read())
                    {
                        
                        page.Page1Title = dr["Page1Title"].ToString();
                        page.Page1Content = dr["Page1Content"].ToString();
                        page.Page1Status = Convert.ToBoolean(dr["Page1Status"].ToString());
                        page.Page2Title = dr["Page2Title"].ToString();
                        page.Page2Content = dr["Page2Content"].ToString();
                        page.Page2Status = Convert.ToBoolean(dr["Page2Status"].ToString());
                        page.Page3Title = dr["Page3Title"].ToString();
                        page.Page3Content = dr["Page3Content"].ToString();
                        page.Page3Status = Convert.ToBoolean(dr["Page3Status"].ToString());
                        page.Page4Title = dr["Page4Title"].ToString();
                        page.Page4Content = dr["Page4Content"].ToString();
                        page.Page4Status = Convert.ToBoolean(dr["Page4Status"].ToString());
                        page.Page5Title = dr["Page5Title"].ToString();
                        page.Page5Content = dr["Page5Content"].ToString();
                        page.Page5Status = Convert.ToBoolean(dr["Page5Status"].ToString());
                       
                        
                    }
                    return page;
                }
            }
        }
     
        //public EmployeeEntity.Page GetPageByStatus()
        
        //{
        //    using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
        //    {
        //        EmployeeEntity.Page page1 = new Page();
                
        //        using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetPagesByStatus",
        //            null))
        //        {

        //            if (dr.Read())
        //            {
                        
                        
        //                //if (page1.Page1Title != null)
        //                //{
        //                //    page1.Page1Title = dr["Page1Title"].ToString();
        //                //}
        //                ////page1.Page1Content = dr["Page1Content"].ToString();
        //                //if (page1.Page2Title != null)
        //                //{
        //                //    page1.Page2Title = dr["Page2Title"].ToString();
        //                //}
        //                ////page1.Page2Content = dr["Page2Content"].ToString();
        //                //if (page1.Page3Title != null)
        //                //{
        //                //    page1.Page3Title = dr["Page3Title"].ToString();
        //                //}
        //                ////page1.Page3Content = dr["Page3Content"].ToString();
        //                //if (page1.Page4Title != null)
        //                //{
        //                //    page1.Page4Title = dr["Page4Title"].ToString();
        //                //}
        //                ////page1.Page4Content = dr["Page4Content"].ToString();
        //                //if (page1.Page5Title != null)
        //                //{
        //                //    page1.Page5Title = dr["Page5Title"].ToString();
        //                //}
        //                ////page1.Page5Content = dr["Page5Content"].ToString();
                        
        //            }
        //            return page1;
        //        } 
        //    }
        //}

        public DataTable GetPageByStatus()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader cmd = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetPagesByStatus", null))
                {
                    using (DataTable dt = new DataTable()) 
                    {
                        dt.Load(cmd);

                        return dt;
                    }

                }

            }
        }

        public EmployeeEntity.Page GetPageContent(string pagetitle)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Page page1 = new EmployeeEntity.Page();
                 using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetPagesContent", new SqlParameter("@pagetitle", pagetitle)))
                {
                     if (dr.Read())
                    //using (DataTable dt = new DataTable())
                    {
                        //dt.Load(cmd);
                        page1.Page1Content = dr["Page1Content"].ToString();
                    }
                     return page1;

                }
                  

            } 
        }


     


       
        #endregion
    }
}

