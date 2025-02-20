using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EmployeeEntity;
using System.IO;

namespace SQLEmployee.DLL.Interface
{
    public interface IClient
    {
        int AddClient(EmployeeEntity.Client client);
        List<EmployeeEntity.Client> GetClients();
         string UpdateClient(EmployeeEntity.Client ClientName);
         int DeleteClient(int ClientId);
         List<EmployeeEntity.Client> GetClientsById(int ClientId);
        int AddGstDetail(EmployeeEntity.Client clientsGst);
        string UpdateGstDetail(EmployeeEntity.Client clientsGst);
        List<EmployeeEntity.Client> GetAllGstRecords(int clientId);
        EmployeeEntity.Client GetClientGstById(int gstId);
        
        int DeleteClientGstDetail(int GstId);
        //Stream DisplayLogo1(int ClientId);
        //Stream DisplayLogo2(int ClientId);
        
    }
}


