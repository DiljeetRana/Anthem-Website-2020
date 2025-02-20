using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
   public class Attendance
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string MarkOnLeave { get; set; }
        public DateTime CreatedOn { get; set; }
        public int IsDelete { get; set; }
        public long EmployeeId { get; set; }
        public int Check { get; set; }
    }
}
