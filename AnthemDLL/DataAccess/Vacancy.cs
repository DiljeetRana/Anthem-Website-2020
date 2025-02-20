using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnthemDLL.Interfaces;

namespace AnthemDLL.DataAccess
{
    public partial class Vacancy : SQLBase,IVacancy
    {
        public Vacancy() : base() { }
    }
}
