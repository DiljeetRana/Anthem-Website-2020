#region namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using SQLEmployee.DLL.Interface;

#endregion

namespace Employee.BLL
{
    public class IFCDeploymentBLL
    {
        #region public class

        #region DataMember

        /// <summary>
        /// Declare a DataMember Here
        /// </summary>
        IIFCDeployment iifcdeployment;

        #endregion

        #region  Consturctor

        /// <summary>
        /// Define a Constructor Here
        /// </summary>
        public IFCDeploymentBLL()
        {
            iifcdeployment = new SQLEmployee.DLL.DataAccess.IFCDeployment();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves All Data From DataBase
        /// </summary>
        public List<IFCDeployment> GetIFCDeployment(int pageIndex,int pageSize)
        {
            return iifcdeployment.GetIFCDeployment(pageIndex,pageSize);
        }

        /// <summary>
        /// Adds A New IFCDeployment Record 
        /// </summary>
        public int AddNewIFCDeploymentRecord(IFCDeployment ifcDeployment)
        {
            return iifcdeployment.AddIFCDeployment(ifcDeployment);
        }

        /// <summary>
        /// Updates A Particular IFCDeployment Record
        /// </summary>
        public string UpdateIFCDeploymentById(IFCDeployment deploymentId)
        {
            return iifcdeployment.UpdateIFCDeploymentById(deploymentId);
        }

        /// <summary>
        /// Get Particular IFCDeploymentDetail
        /// </summary>
        public IFCDeployment GetIFCDeploymentDetailsByDeploymentId(int deploymentId)
        {
            return iifcdeployment.GetIFCDeploymentDetailsById(deploymentId);
        }

        /// <summary>
        /// Delete A Data From DataBase
        /// </summary>
        public string DeleteIFCDeploymentById(int deploymentId)
        {
            return iifcdeployment.DeleteIFCDeploymentById(deploymentId);
        }
        /// <summary>
        /// Count the total record from database
        /// </summary>
        /// <returns></returns>
        public int GetTotalRecordCount()
        {
            return iifcdeployment.TotalRecord();
        }

        #endregion

        #endregion
    }
}
