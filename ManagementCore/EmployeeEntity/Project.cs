using System;

namespace EmployeeEntity
{
    public class Project
    {

        #region Public Properties

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectImage { get; set; }
        public string Technolgies { get; set; }
        public string Description { get; set; }
        public string SmallDescription { get; set; }
        public string ProjectCategory { get; set; }
        public string ProjectSubCategory { get; set; }
        public string URL { get; set; }
        public DateTime DateofProject { get; set; }
        public DateTime EndDateofProject { get; set; }
        public string ProjectOrderType { get; set; }
        public DateTime CreatedOn { get; set; }
        public Boolean IsDeleted { get; set; }
        public int Priority { get; set; }
        public int Publish { get; set; }
        public string ProjectCode { get; set;}
        
        #endregion

    }
}
