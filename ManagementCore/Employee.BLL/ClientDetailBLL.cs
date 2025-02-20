using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;
using System.Security.Cryptography;
using Employee.BLL.Utility;
namespace Employee.BLL
{
    public class ClientDetailBLL
    {

        IClientDetails IClientDet;
        public ClientDetailBLL()
        {
            IClientDet = new SQLEmployee.DLL.DataAccess.ClientDetails();
        }

        public List<EmployeeEntity.ClientDetails> GetClientDetailsBLL()
        {
            return IClientDet.GetClientDetails();
        }

        public bool DeleteClientDetails(int ID)
        {
            return IClientDet.DeleteClientDetails(ID);
        }

        public EmployeeEntity.ClientDetails GetClientById(int Id)
        {
            return IClientDet.GetClientById(Id);
        }

        public string UpdateClient(EmployeeEntity.ClientDetails Model, int? ClientID, bool IsNew = false, string Contactnumber = "", string Email = "")
        {
            return IClientDet.InsertClient(Model, ClientID, IsNew, Contactnumber, Email);
        }

        public string InsertClient(EmployeeEntity.ClientDetails Model, string key, int? ClientID, bool IsNew = false, string Contactnumber = "", string Email = "")
        {
            return IClientDet.InsertClient(Model, null, true, SecurityProvider.Encrypt(Contactnumber, true, key), SecurityProvider.Encrypt(Email, true, key));
        }

        public List<EmployeeEntity.Projects> DropDownHelper(bool ProjectsDDL)
        {
            if (ProjectsDDL == true)
            {
                return IClientDet.GetProjects();
            }
            else 
            {
                return null;
            }
        }

        public List<EmployeeEntity.ClientDetails> GetClientDetailsBySearch(string Search)
        {
            return IClientDet.GetClientDetailsBySearch(Search);
        }

        public List<EmployeeEntity.ClientDetails> GetClientForBirthday()
        {
            return IClientDet.GetClientForBirthday();
        }

        public List<EmployeeEntity.ClientDetails> GetClientNameAndId()
        {
            return IClientDet.GetClientNameAndId();
        }
        
        public List<EmployeeEntity.ClientDetails> GetAMCDetails()
        {
            return IClientDet.GetAMCDetails();
        }
        public int AddAMCDetail(EmployeeEntity.ClientDetails client)
        {
            return IClientDet.AddAMCDetail(client);
        }
        public bool DeleteAMCDetails(int ID)
        {
            return IClientDet.DeleteAMCDetails(ID);
        }
        public EmployeeEntity.ClientDetails GetAMCById(int Id)
        {
            return IClientDet.GetAMCById(Id);
        }
        public int UpdateAMCDetails(EmployeeEntity.ClientDetails client)
        {
            return IClientDet.UpdateAMCDetails(client);
        }
        public List<EmployeeEntity.ClientDetails> BindAMCdetails(int Id)
        {
            return IClientDet.BindAMCdetails(Id);
        }
        public bool CheckTitleExist(string name, string clientid)
        {
            return IClientDet.CheckTitleExist(name, clientid);
        }
        public int AddInvoiceDetail(EmployeeEntity.ClientDetails client)
        {
            return IClientDet.AddInvoiceDetail(client);
        }
        public List<EmployeeEntity.ClientDetails> BindInvoiceGrid(int SrNo)
        {
            return IClientDet.BindInvoiceGrid(SrNo);
        }
        public bool DeleteInvoiceDetail(int InvoiceID)
        {
            return IClientDet.DeleteInvoiceDetail(InvoiceID);
        }
        public EmployeeEntity.ClientDetails GetInvoiceById(int InvoiceId)
        {
            return IClientDet.GetInvoiceById(InvoiceId);
        }
        public int UpdateInvoiceDetails(EmployeeEntity.ClientDetails client)
        {
            return IClientDet.UpdateInvoiceDetails(client);
        }
        public bool CheckNameExist(string Clientname, string Organisation)
        {
            return IClientDet.CheckNameExist(Clientname, Organisation);
        }
        public bool CheckDispatchNo(string dispatchNo)
        {
            return IClientDet.CheckDispatchNo(dispatchNo);
        }
        public bool CheckInvoiceNo(string invoiceno)
        {
            return IClientDet.CheckInvoiceNo(invoiceno);
        }
        public List<EmployeeEntity.ClientDetails> CheckPaymentreceived()
        {
            return IClientDet.CheckPaymentreceived();
        }
        public int updatePaymentDate(string invoiceid, string paymentdate)
        {
            return IClientDet.updatePaymentDate(invoiceid, paymentdate);
        }
        public List<EmployeeEntity.ClientDetails> CheckInvoicenotSent()
        {
            return IClientDet.CheckInvoicenotSent();
        }
        public int updateInvoiceSentDate(string invoiceid, string InvoiceSentDate,string DispatchNo)
        {
            return IClientDet.updateInvoiceSentDate(invoiceid, InvoiceSentDate, DispatchNo);
        }
    }
}
