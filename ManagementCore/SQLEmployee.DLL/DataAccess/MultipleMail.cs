using SQLEmployee.DLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.DataAccess
{
    public partial class MultipleMail : SQLBase, IMultipleMail
    {
        public MultipleMail() : base() {}
    }
}
