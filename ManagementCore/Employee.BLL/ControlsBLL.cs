using SQLEmployee.DLL.DataAccess;
using SQLEmployee.DLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BLL
{
    public class ControlsBLL
    {
        IControls Icont;
        public ControlsBLL()
        {
            Icont = new Controls();
 
        }
        public EmployeeEntity.Controls GetIndividualCheckoutEmail()
        {
            return Icont.GetCheckoutIndividualEmails();
        }
        public EmployeeEntity.Controls GetCheckoutCombinedEmail()
        {
            return Icont.GetCheckoutCombinedEmails();
        }
        public bool SaveDetails(EmployeeEntity.Controls obj)
        {
            return Icont.SaveDetails(obj);
        }
        public EmployeeEntity.Controls GetActiveEmails()
        {
            return Icont.GetBirthdayEmails();
        }
        public EmployeeEntity.Controls GetMothlyAttendanceEmails()
        {
            return Icont.GetMonthlyattendanceEmails();
        }
        public EmployeeEntity.Controls GetAnniversaryEmails()
        {
            return Icont.GetAnniversaryEmails();
        }
    }
}
