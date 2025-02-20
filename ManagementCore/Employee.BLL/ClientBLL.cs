using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;
using System.Data;
using System.IO;

namespace Employee.BLL
{
   public class ClientBLL
    {
       IClient IClient;
       public ClientBLL()
       {
           IClient = new SQLEmployee.DLL.DataAccess.SQLClient();
       }
      
       public int AddClient(EmployeeEntity.Client client)
       {
           return IClient.AddClient(client);
       }

       public List<EmployeeEntity.Client>  GetClients()
       {
           return IClient. GetClients();
       }
       public List<EmployeeEntity.Client>  GetClientsById(int ClientId)
       {
           return IClient.GetClientsById(ClientId);
       }

       public string UpdateClient(EmployeeEntity.Client ClientName)
       {
           return IClient.UpdateClient(ClientName);
       }
       public int DeleteClient(int ClientId)
       {
           return IClient.DeleteClient(ClientId);
       }

       public int AddGstDetail(EmployeeEntity.Client clientsGst)
       {
            return IClient.AddGstDetail(clientsGst);
       }

       public List<EmployeeEntity.Client> GetAllGstRecords(int clientId)
       {
            return IClient.GetAllGstRecords(clientId);
       }

       public string UpdateGstDetail(EmployeeEntity.Client clientsGst)
       {
            return IClient.UpdateGstDetail(clientsGst);
       }

       public EmployeeEntity.Client GetClientGstById(int gstId)
       {
            return IClient.GetClientGstById(gstId);
       }

       public int DeleteClientGstDetail(int GstId)
       {
            return IClient.DeleteClientGstDetail(GstId);
       }
        
    }
}


   

    

       