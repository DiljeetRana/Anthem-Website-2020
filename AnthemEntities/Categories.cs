using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemEntites
{
    public class Categories
    {

        #region Public properties

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectImage { get; set; }

        public string Technolgies { get; set; }
        public string Description { get; set; }
        public string ProjectCategory { get; set; }
        public string ProjectSubCategory { get; set; }
        public string URL { get; set; }
        public DateTime DateofProject { get; set; }
        public DateTime EndDateofProject { get; set; }
        public string ProjectOrderType { get; set; }
        public DateTime CreatedOn { get; set; }
        public Boolean IsDeleted { get; set; }
        public string SmallDesciption { get; set; }
        public int Priority { get; set; }
        public int EmployeeId { get; set; }
       
        public string Designation { get; set; }
        public object Picture { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; }
        //public string Description { get; set; }
        public Boolean IsPublic { get; set; }
        public string Image { get; set; }
        #endregion

    }
}
