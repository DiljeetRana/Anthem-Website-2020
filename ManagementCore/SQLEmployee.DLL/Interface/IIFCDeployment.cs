#region namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;

#endregion

namespace SQLEmployee.DLL.Interface
{
    public interface IIFCDeployment
    {
        
        #region methods
        /// <summary>
        /// Declare Methods Here
        /// </summary>
        /// <returns></returns>
        int AddIFCDeployment(IFCDeployment deployment);
        List<IFCDeployment> GetIFCDeployment(int pageIndex,int pageSize);
        string DeleteIFCDeploymentById(int deploymentId);
        IFCDeployment GetIFCDeploymentDetailsById(int deploymentId);
        string UpdateIFCDeploymentById(IFCDeployment deploymentId);
        int TotalRecord();

        #endregion

    }
}
