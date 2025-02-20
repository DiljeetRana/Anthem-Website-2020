using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
   public class Page
    {
       public int PageId { get; set; }
       public string Page1Title { get; set; }
       public string Page1Content{ get; set; }
       public Boolean Page1Status { get; set; }
       public string Page2Title { get; set; }
       public string Page2Content { get; set; }
       public Boolean Page2Status { get; set; }
       public string Page3Title { get; set; }
       public string Page3Content { get; set; }
       public Boolean Page3Status { get; set; }
       public string Page4Title { get; set; }
       public string Page4Content { get; set; }
       public Boolean Page4Status { get; set; }
       public string Page5Title { get; set; }
       public string Page5Content { get; set; }
       public Boolean Page5Status { get; set; }
       public DateTime CreatedOn { get; set; }
       public Boolean IsDeleted { get; set; }
    }
}
