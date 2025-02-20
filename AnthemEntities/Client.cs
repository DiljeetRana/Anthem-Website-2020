using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemEntites
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

    }
}
