using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
    public class EmployeeCheckEntity
    {
        public int CheckId { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string WorkReport { get; set; }
        public int EmployeeId { get; set; }
        public string Dated { get; set; }  //Dated is a startLeaveDate.
        public string OnLeave { get; set; }
        public string Reason { get; set; }
        public string EndLeaveDate { get; set; }
        public string Color { get; set; }
        public string Title { get; set; }
        public string CreatedOn { get; set; }
        public string Name { get; set; }
        public int WorkingHour { get; set; }
        public string CheckInDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EmployeeMail { get; set; }
        public string TodayDate { get; set; }
        public string Today { get; set; }
        public string FestivalDate { get; set; }
        public int HolidayId { get; set; }

    }
}
