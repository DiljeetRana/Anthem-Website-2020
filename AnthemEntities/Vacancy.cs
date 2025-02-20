using System;

namespace AnthemEntites
{
    public class Vacancy
    {

        #region Pubpic Properties

        public int id { get; set; }
        public string JobTitle { get; set; }
        public string Content { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDelete { get; set; }
        public DateTime CreatedOn { get; set; }

        public int VacnaciesCount { get; set; }
        
        #endregion

    }
}
