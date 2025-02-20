using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
    public class Categories
    {

        #region Public properties

        public int Id { get; set; }
        public string Name { get; set; }
        public int TemplateId { get; set; }
        public string TemplateType { get; set; }
        public string TemplatePath { get; set; }
        public string ImageMessage { get; set; }
        public string Greeting { get; set; }
        #endregion

    }
}
