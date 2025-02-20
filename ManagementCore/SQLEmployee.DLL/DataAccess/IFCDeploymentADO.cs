#region namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmployeeEntity;
using SQLEmployee.DLL.ADO;

#endregion

namespace SQLEmployee.DLL.DataAccess
{
    public partial class IFCDeployment
    {
        #region SQL Operations

        /// <summary>
        /// Define All Sql Operations Here
        /// </summary>
        #region GetIFCDeployment Function

        /// <summary>
        /// Define a Function to get all records  Here
        /// </summary>
        public List<EmployeeEntity.IFCDeployment> GetIFCDeployment(int pageIndex,int pageSize)
        {
            using (ADOExecution exec = new ADOExecution(DataAccess.SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.IFCDeployment> ifcdeploymentlist = new List<EmployeeEntity.IFCDeployment>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAllIFCDeployments", new SqlParameter("@pageindex", pageIndex),new SqlParameter("@pagesize", pageSize)))
                {
                    while (dr.Read())
                    {
                        EmployeeEntity.IFCDeployment ifcdeployment = new EmployeeEntity.IFCDeployment();
                        ifcdeployment.DeploymentId = Convert.ToInt64(dr["DeploymentId"]);
                        ifcdeployment.Client = Convert.ToString(dr["Client"]);
                        ifcdeployment.DeployedOn = Convert.ToDateTime(dr["DeployedOn"]);
                        ifcdeployment.Version = Convert.ToString(dr["Version"]);
                        ifcdeployment.ClientContact = Convert.ToString(dr["ClientContact"]);
                        ifcdeployment.KPMGPartner = Convert.ToString(dr["KPMGPartner"]);
                        ifcdeployment.KPMGContact = Convert.ToString(dr["KPMGContact"]);

                        //Checking the condition for InvoiceRaisedOn to be Null

                        if (dr["InvoiceRaisedOn"].ToString() == "")
                        {
                            ifcdeployment.InvoiceRaisedOn = null;
                        }
                        else
                        {
                            ifcdeployment.InvoiceRaisedOn = Convert.ToDateTime(dr["InvoiceRaisedOn"]);
                        }

                        //Checking the condition for InvoiceClearedOn to be Null

                        if (dr["InvoiceClearedOn"].ToString() == "")
                        {
                            ifcdeployment.InvoiceClearedOn = null;
                        }
                        else
                        {
                            ifcdeployment.InvoiceClearedOn = Convert.ToDateTime(dr["InvoiceClearedOn"]);
                        }

                        //Checking the condition for PaymentDelays to be Null

                        if (dr["PaymentDelays"].ToString() == "")
                        {
                            ifcdeployment.PaymentDelays = null;
                        }
                        else
                        {
                            ifcdeployment.PaymentDelays = Convert.ToInt32(dr["PaymentDelays"]);
                        }
                        ifcdeployment.ClientAddress = Convert.ToString(dr["ClientAddress"]);

                        ifcdeploymentlist.Add(ifcdeployment);
                    }
                }
                return ifcdeploymentlist;
            }
        }

        #endregion

        #region AddIFCDeployment Function

        /// <summary>
        /// Define a Function to Add New Record Here
        /// </summary>
        public int AddIFCDeployment(EmployeeEntity.IFCDeployment ifcdeploymentData)
        {
            using (ADOExecution exec = new ADOExecution(DataAccess.SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_AddNewIFCDeployments",

                    new SqlParameter("@client", ifcdeploymentData.Client),
                    new SqlParameter("@deployedon", ifcdeploymentData.DeployedOn),
                    new SqlParameter("@version", ifcdeploymentData.Version),
                    new SqlParameter("@clientcontact", ifcdeploymentData.ClientContact),
                    new SqlParameter("@kpmgpartner", ifcdeploymentData.KPMGPartner),
                    new SqlParameter("@kpmgcontact", ifcdeploymentData.KPMGContact),
                    new SqlParameter("@invoiceraisedon", ifcdeploymentData.InvoiceRaisedOn),
                    new SqlParameter("@invoiceclearedon",ifcdeploymentData.InvoiceClearedOn),
                    new SqlParameter("@paymentdelays", ifcdeploymentData.PaymentDelays),
                    new SqlParameter("@clientaddress", ifcdeploymentData.ClientAddress)

                    ))
                    return 0;
            }
        }
        #endregion

        #region GetIFCDeploymentDetailsById Function

        /// <summary>
        /// Define a function to get IFCDeploymentDetails By Id Here
        /// </summary>
        public EmployeeEntity.IFCDeployment GetIFCDeploymentDetailsById(int IfcDeploymentId)
        {
            using (ADOExecution exec = new ADOExecution(DataAccess.SQLBase.GetConnectionString()))
            {
                EmployeeEntity.IFCDeployment ifcdeployment = new EmployeeEntity.IFCDeployment();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetIFCDeploymentsByDeploymentId",
                    new SqlParameter("@deploymentid", IfcDeploymentId)
                    ))
                {
                    while (dr.Read())
                    {
                        ifcdeployment.DeploymentId = Convert.ToInt64(dr["DeploymentId"]);
                        ifcdeployment.Client = Convert.ToString(dr["Client"]);
                        ifcdeployment.DeployedOn = Convert.ToDateTime(dr["DeployedOn"]); 
                        ifcdeployment.Version = Convert.ToString(dr["Version"]);
                        ifcdeployment.ClientContact = Convert.ToString(dr["ClientContact"]);
                        ifcdeployment.KPMGPartner = Convert.ToString(dr["KPMGPartner"]);
                        ifcdeployment.KPMGContact = Convert.ToString(dr["KPMGContact"]);

                        //Checking the condition for InvoiceRaisedOn to be Null
                        
                        if (dr["InvoiceRaisedOn"].ToString()=="")
                        {
                            ifcdeployment.InvoiceRaisedOn = null;
                        }
                        else
                        {
                            ifcdeployment.InvoiceRaisedOn = Convert.ToDateTime(dr["InvoiceRaisedOn"]);
                        }

                        //Checking the condition for InvoiceClearedOn to be Null
                        
                        if (dr["InvoiceClearedOn"].ToString()=="")
                        {
                            ifcdeployment.InvoiceClearedOn = null;
                        }
                        else
                        {
                            ifcdeployment.InvoiceClearedOn = Convert.ToDateTime(dr["InvoiceClearedOn"]);
                        }

                        //Checking the condition for PaymentDelays to be Null

                        if (dr["PaymentDelays"].ToString()=="")
                        {
                            ifcdeployment.PaymentDelays = null;
                        }
                        else
                        {
                            ifcdeployment.PaymentDelays = Convert.ToInt32(dr["PaymentDelays"]);
                        }
                        
                        ifcdeployment.ClientAddress = Convert.ToString(dr["ClientAddress"]);
                    }
                }
                return ifcdeployment;

            }
        }
        #endregion

        #region UpdateIFCDeploymentById Function

        /// <summary>
        /// Define a function to update IFCDeployment By Id Here
        /// </summary>
        public string UpdateIFCDeploymentById(EmployeeEntity.IFCDeployment ifcDeploymentData)
        {
            using (ADOExecution exec = new ADOExecution(DataAccess.SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_UpdateIFCDeploymentsByDeploymentId",

                new SqlParameter("@DeploymentId", ifcDeploymentData.DeploymentId),
                new SqlParameter("@client", ifcDeploymentData.Client),
                new SqlParameter("@deployedon", ifcDeploymentData.DeployedOn),
                new SqlParameter("@version", ifcDeploymentData.Version),
                new SqlParameter("@clientcontact", ifcDeploymentData.ClientContact),
                new SqlParameter("@kpmgpartner", ifcDeploymentData.KPMGPartner),
                new SqlParameter("@kpmgcontact", ifcDeploymentData.KPMGContact),
                new SqlParameter("@invoiceraisedon", ifcDeploymentData.InvoiceRaisedOn),
                new SqlParameter("@invoiceclearedon", ifcDeploymentData.InvoiceClearedOn),
                new SqlParameter("@paymentdelays", ifcDeploymentData.PaymentDelays),
                new SqlParameter("@clientaddress", ifcDeploymentData.ClientAddress)

                ))
                    return "Updated Successfully";
            }
        }
        #endregion

        #region DeleteIFCDeploymentById Function

        /// <summary>
        /// Define a function to delete IFCDeployment By Id Here
        /// </summary>
        public string DeleteIFCDeploymentById(int deploymentId)
        {
            using (ADOExecution exec = new ADOExecution(DataAccess.SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_DeleteIFCDeploymentsByDeploymentId",

                    new SqlParameter("@deploymentid", deploymentId)
                    ))
                {

                }
            }
            return "Deleted Successfully";
        }
        #endregion

        #region Function
        /// <summary>
        /// Function to Count Total Records
        /// </summary>
        /// <returns></returns>
        public int TotalRecord()
        {
            SqlDataAdapter adp = new SqlDataAdapter("sp_GetTotalRecords", DataAccess.IFCDeployment.GetConnectionString());
            DataTable datatable = new DataTable();
            adp.Fill(datatable);
            return Convert.ToInt32(datatable.Rows[0][0].ToString());
        }

        #endregion

        #endregion
    }
}
