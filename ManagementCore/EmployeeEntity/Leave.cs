using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
   public class Leave
    {
       public int Id { get; set; }
       public string StartDate { get; set; }
       public string EndDate { get; set; }
       public string IsHalf { get; set; }
       public string Reason { get; set; }
       public long EmployeeId { get; set; }
       public int IsDeleted { get; set; }
       public DateTime CreatedOn { get; set; }
    }
}
