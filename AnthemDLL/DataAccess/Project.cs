#region NameSpaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnthemDLL.Interfaces;

#endregion

namespace AnthemDLL.DataAccess
{
    public partial class Project :SQLBase,IProjects
    {
        public Project() : base() { }
    }
}
