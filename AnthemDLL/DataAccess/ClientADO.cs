#region Name Spaces

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace AnthemDLL.DataAccess
{
    public partial class Client
    {

        #region SQL Operations

        public List<AnthemEntites.Client> GetAllClients()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Client> client1 = new List<AnthemEntites.Client>();

                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetClients",
                    null))
                {
                    while (dr.Read())
                    {

                        AnthemEntites.Client client = new AnthemEntites.Client();
                        client.ClientId = Convert.ToInt32(dr["ClientId"].ToString());
                        client.ClientName = dr["ClientName"].ToString();
                        client.Description = dr["Description"].ToString();
                        client.WebsiteAddress = dr["WebsiteAddress"].ToString();
                        client.Logo1 = dr["Logo1"].ToString();
                        client.Logo2 = dr["Logo2"].ToString();
                        client1.Add(client);

                    }
                    return client1;
                }
            }
        }

        #endregion

    }
}
