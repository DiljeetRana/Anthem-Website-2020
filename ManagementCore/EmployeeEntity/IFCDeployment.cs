#region namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace EmployeeEntity
{
    public partial class IFCDeployment
    {

        #region Public Properties

        /// <summary>
        /// Declare Properties Here
        /// </summary> 
        public Int64 DeploymentId { get; set; }
        public string Client { get; set; }
        public DateTime DeployedOn { get; set; }
        public string Version { get; set; }
        public string ClientContact { get; set; }
        public string KPMGPartner { get; set; }
        public string KPMGContact { get; set; }
        public DateTime? InvoiceRaisedOn { get; set; }
        public DateTime? InvoiceClearedOn { get; set; }
        public int? PaymentDelays { get; set; }
        public string ClientAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public char IsDeleted { get; set; }

        #endregion

    }
}
