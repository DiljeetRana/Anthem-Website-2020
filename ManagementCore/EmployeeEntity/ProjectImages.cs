using System;

namespace EmployeeEntity
{
    public class ProjectImages
    {
        public int ImageId { get; set; }
        public string ImageURL { get; set; }
        public int ProjectId { get; set; }
        public DateTime createdOn { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
