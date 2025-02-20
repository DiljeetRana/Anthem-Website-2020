#region Name Spaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace AnthemDLL.Interfaces
{
    public interface IClient
    {
        List<AnthemEntites.Client> GetAllClients();
    }
}
