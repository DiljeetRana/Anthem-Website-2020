#region Name Spaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnthemDLL.Interfaces;

#endregion

namespace AnthemDLL.DataAccess
{
    public partial class Client : SQLBase,IClient
    {
        public Client() : base() { }
    }
}
