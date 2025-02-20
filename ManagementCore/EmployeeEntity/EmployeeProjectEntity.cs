using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
   public class EmployeeProjectEntity
    {

        #region Public Properties
        public int EmployeeProjectId { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public string ProjectName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string RoleDescriptions { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }


        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string TimePeriod { get; set; }


        public int SchoolId { get; set; }
        public string SchoolName  { get; set; }
        public string Education { get; set; }

        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PublicUrl { get; set; }
        //public string Description { get; set; }
        public Boolean IsPublic { get; set; }


        #endregion
    }
}
