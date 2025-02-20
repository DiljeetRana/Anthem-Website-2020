using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;

namespace SQLEmployee.DLL.DataAccess
{
   public partial class Technologies: SQLBase,ITechnologies
    {
       public Technologies() : base() { }
    }
}
