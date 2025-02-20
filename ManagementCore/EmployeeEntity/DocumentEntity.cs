using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
   public class DocumentEntity
    {
        public int DocId { get; set; }
        public byte[] Name { get; set; }
        public string DocName { get; set; }
        public string DateUploaded { get; set; }
        public string CreatedOn{ get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
       
    }
}
