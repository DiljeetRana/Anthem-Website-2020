using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemEntities
{
    public class SlackEntity
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string NoOfDays { get; set; }
        public string Reason { get; set; }
        public DateTime Creation { get; set; }
        public string Email { get; set; }

    }
}
