using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLEmployee.DLL.Interface
{
    public interface IClientDetails
    {
        List<ClientDetails> GetClientDetails();
        ClientDetails GetClientById(int Id);
        bool DeleteClientDetails(int ID);       
        string InsertClient(EmployeeEntity.ClientDetails Model, int? ClientID, bool IsNew = false, string Contactnumber = "", string Email = "");
        List<EmployeeEntity.Projects> GetProjects();
        List<EmployeeEntity.ClientDetails> GetClientDetailsBySearch(string Search);
        List<EmployeeEntity.ClientDetails> GetClientForBirthday();
        List<EmployeeEntity.ClientDetails> GetClientNameAndId();
        List<EmployeeEntity.ClientDetails> GetAMCDetails();
        bool CheckTitleExist(string name, string clientid);
        int AddAMCDetail(EmployeeEntity.ClientDetails client);
        bool DeleteAMCDetails(int ID);
        EmployeeEntity.ClientDetails GetAMCById(int Id);
        int UpdateAMCDetails(EmployeeEntity.ClientDetails client);
        List<EmployeeEntity.ClientDetails> BindAMCdetails(int Id);
        int AddInvoiceDetail(EmployeeEntity.ClientDetails client);
        List<EmployeeEntity.ClientDetails> BindInvoiceGrid(int SrNo);
        bool DeleteInvoiceDetail(int InvoiceID);
        EmployeeEntity.ClientDetails GetInvoiceById(int InvoiceId);
        int UpdateInvoiceDetails(EmployeeEntity.ClientDetails client);
        bool CheckNameExist(string Clientname, string Organisation);
        bool CheckDispatchNo(string dispatchNo);
        bool CheckInvoiceNo(string invoiceno);
        List<EmployeeEntity.ClientDetails> CheckPaymentreceived();
        int updatePaymentDate(string invoiceid, string paymentdate);

        List<EmployeeEntity.ClientDetails> CheckInvoicenotSent();
        int updateInvoiceSentDate(string invoiceid, string InvoiceSentDate,string DispatchNo);
    }
}
