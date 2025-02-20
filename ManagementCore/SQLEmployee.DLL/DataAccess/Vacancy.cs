#region Name Spaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;

#endregion

namespace SQLEmployee.DLL.DataAccess
{
    public partial class Vacancy:SQLBase,IVacancy
    {
        public Vacancy() : base() { }
    }
}
