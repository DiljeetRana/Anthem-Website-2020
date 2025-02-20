using AnthemDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemDLL.DataAccess
{
    public partial class SQLSlack : SQLBase, ISlack
    {
        public SQLSlack() : base() { }
    }
}
