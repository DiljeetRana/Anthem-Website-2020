using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
    public class AnthemNewsEntity
    {
        #region Public Properties
        public int MessageID { get; set; }
        public string Message { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime  EndDate { get; set; }
        public string StartDate1 { get; set; }
        public string EndDate1 { get; set; }
        public string Color { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean Continuous { get; set; }
        public DateTime PublishDate { get; set; }

        #endregion
    }
}
