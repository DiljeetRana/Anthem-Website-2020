using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
   public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string WebsiteAddress { get; set; }
        public string Logo1 { get; set; }
        public string Logo2 { get; set; }
        public DateTime CreatedOn { get; set; }
        public Boolean IsDeleted { get; set; }
        public int Priority { get; set; }
        public int GstId { get; set; }
        public string GstNo { get; set; }
        public string GstAddress { get; set; }
        public string VendorCode { get; set; }
        public string PONumber { get; set; }

        

    }
}
