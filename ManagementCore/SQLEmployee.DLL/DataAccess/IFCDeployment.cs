#region namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;

#endregion

namespace SQLEmployee.DLL.DataAccess
{
    #region DataAccess

    /// <summary>
    /// Declare Constructor Here
    /// </summary>
    public partial class IFCDeployment : SQLBase, IIFCDeployment
    {
        public IFCDeployment()
            : base()
        {

        }
    }

    #endregion
}
