using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeEntity
{
    public class ClientDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Project { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Date_OfBirth { get; set; }
        public string Anniversary { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Timezone { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string IconBinder { get; set; }
        public string Contact { get; set; }
        public string Facebook_Link { get; set; }
        public string Twitter_Link { get; set; }
        public string LinkdIn_Link { get; set; }
        public string Website { get; set; }
        public string Photo { get; set; }
        public string Remarks { get; set; }
        public string Organisation { get; set; }

        public int Clientid { get; set; }
        public string AMCTitle { get; set; }
        public DateTime AMCStartDate { get; set; }
        public DateTime AMCEndDate { get; set; }
        public string PaymentMode { get; set; }
        public string InvoiceSent { get; set; }
        public string InvoiceDispatchNo { get; set; }
        public string PaymentReceived { get; set; }
        public string PaymentReceivedDate { get; set; }
        public string InvoiceSentDate { get; set; }
        public int SrNo { get; set; }
        public string StartEnddate { get; set; }
        public string Description { get; set; }
        public int InvoiceId { get; set; }
        public string  InvoiceNo { get; set; }
        public string  InvoiceGeneratedate { get; set; }

        public string PaymentType { get; set; }
    }

    public class Projects
    {
        public string AllProjects { get; set; }
    }
    public class Message
    {
        private string clients;
        public string Clients { get { return clients; } }
    }
}
