#region Name Spaces

using AnthemDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace AnthemProjectBLL
{
    public class ClientBLL
    {

        #region Members

        IClient iClient;

        #endregion

        #region Methods

        public ClientBLL()
        {
            iClient = new AnthemDLL.DataAccess.Client();
        }

        public List<AnthemEntites.Client> GetAllClients()
        {
            return iClient.GetAllClients();
        }

        #endregion

    }
}
