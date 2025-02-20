using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using System.Data;
using SQLEmployee.DLL.ADO;
using System.Data.SqlClient;
using System.IO;

namespace SQLEmployee.DLL.DataAccess
{
   
   public partial class SQLClient
    {
        #region Clients
        public int AddClient(EmployeeEntity.Client client)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertClient",
                    new SqlParameter("@clientname", client.ClientName),
                    new SqlParameter("@description", client.Description),
                    new SqlParameter("@websiteaddress",client.WebsiteAddress),
                    new SqlParameter("@logo1",client.Logo1),
                    new SqlParameter("@Logo2",client.Logo2),
                    new SqlParameter("@priority",client.Priority)
                    ))
                  
                    return 0;
            }

        }

        
        public List<EmployeeEntity.Client> GetClients()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Client> client1 = new List<EmployeeEntity.Client>();
               
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetClients",
                    null))
                {
                    while (dr.Read())
                    {                        
                        Client client = new Client();
                        client.ClientId = Convert.ToInt32(dr["ClientId"].ToString());
                        client.ClientName= dr["ClientName"].ToString();
                        client.Description = dr["Description"].ToString();
                        client.WebsiteAddress = dr["WebsiteAddress"].ToString();
                        client.Logo1 = dr["Logo1"].ToString();
                        client.Logo2 = dr["Logo2"].ToString();
                        client.Priority = Convert.ToInt32(dr["Priority"].ToString());
                        client1.Add(client);
                     
                    } 
                    return client1;
                }
            }
        }

        public List<EmployeeEntity.Client> GetClientsById(int ClientId)
           
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              List<EmployeeEntity.Client> client1 = new List<EmployeeEntity.Client>();
              using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "[anthemdbuser].[usp_GetClientsById]", 
                  new SqlParameter("@clientId", ClientId)))
              {
                  if (dr.Read())
                  { 
                      Client client = new Client();
                      client.ClientId = Convert.ToInt32(dr["ClientId"].ToString());
                        client.ClientName= dr["ClientName"].ToString();
                        client.Description = dr["Description"].ToString();
                        client.WebsiteAddress = dr["WebsiteAddress"].ToString();
                        client.Logo1 = dr["Logo1"].ToString();
                        client.Logo2 = dr["Logo2"].ToString();
                        client.Priority= Convert.ToInt32(dr["Priority"].ToString());
                        //client.Logo1 = Convert.ToByte(dr["Logo1"].ToString());
                        client1.Add(client);
                     
                  }
                  return client1;
              }
              
          }
        
      }

        public string UpdateClient(EmployeeEntity.Client ClientName)
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              string message;
             
              using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_UpdateClients",
                  new SqlParameter("@clientid", ClientName.ClientId),
                  new SqlParameter("@clientname", ClientName.ClientName),
                  new SqlParameter("@description", ClientName.Description),
                 new SqlParameter("@websiteaddress", ClientName.WebsiteAddress),
                  new SqlParameter("@logo1", ClientName.Logo1),
                  new SqlParameter("@logo2", ClientName.Logo2),
                  new SqlParameter("@priority", ClientName.Priority)
                  ))
                
              return "";
                 
          }
      }

        public int DeleteClient(int ClientId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_DeleteClient",
                    new SqlParameter("@clientid", ClientId)))
                    return 0;
            }
        }

        #endregion

        #region Clients GSt Detail
        public int AddGstDetail(EmployeeEntity.Client clientsGst)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_InsertNewGstDetail",
                    new SqlParameter("@cid", clientsGst.ClientId),
                    new SqlParameter("@cname", clientsGst.ClientName),
                    new SqlParameter("@gstno", clientsGst.GstNo),
                    new SqlParameter("@address", clientsGst.GstAddress),
                    new SqlParameter("@vendorcode", clientsGst.VendorCode),
                    new SqlParameter("@ponumber", clientsGst.PONumber)
                    ))

                    return 0;
            }

        }
        public string UpdateGstDetail(EmployeeEntity.Client clientsGst)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_UpdateGSTDetail",
                    new SqlParameter("@gstid", clientsGst.GstId),
                    new SqlParameter("@cid", clientsGst.ClientId),
                    new SqlParameter("@cname", clientsGst.ClientName),
                    new SqlParameter("@gstno", clientsGst.GstNo),
                    new SqlParameter("@address", clientsGst.GstAddress),
                    new SqlParameter("@vendorcode", clientsGst.VendorCode),
                    new SqlParameter("@ponumber", clientsGst.PONumber)
                    ))

                    return "";

            }
        }
        public List<EmployeeEntity.Client> GetAllGstRecords(int clientId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Client> clients = new List<EmployeeEntity.Client>();

                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAllGSTRecords",
                    new SqlParameter("@cid", clientId)))
                {
                    while (dr.Read())
                    {
                        Client client = new Client();
                        client.GstId = Convert.ToInt32(dr["GstId"]);
                        client.ClientId = Convert.ToInt32(dr["ClientId"]);
                        client.ClientName = dr["ClientName"].ToString();
                        client.GstNo = dr["GstNo"].ToString();
                        client.GstAddress = dr["Address"].ToString();
                        client.VendorCode = dr["VendorCode"].ToString();
                        client.PONumber = dr["PONumber"].ToString();
                        clients.Add(client);

                    }
                    return clients;
                }
            }
        }
       

        public EmployeeEntity.Client GetClientGstById(int gstId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.Client client = new EmployeeEntity.Client();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetClientGstById",
                   new SqlParameter("@gstid", gstId)))
                {
                    while (dr.Read())
                    {
                        client.GstId = Convert.ToInt32(dr["GstId"]);
                        client.ClientId = Convert.ToInt32(dr["ClientId"]);
                        client.ClientName = dr["ClientName"].ToString();
                        client.GstNo = dr["GstNo"].ToString();
                        client.GstAddress = dr["GstAddress"].ToString();
                        client.VendorCode = dr["VendorCode"].ToString();
                        client.PONumber = dr["PONumber"].ToString();

                    }
                    return client;
                }
            }
        }

        public int DeleteClientGstDetail(int GstId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "sp_DeleteClientGstDetail",
                    new SqlParameter("@gstid", GstId)))
                    return 0;
            }
        }

        #endregion

        
    }
}

  

    
    