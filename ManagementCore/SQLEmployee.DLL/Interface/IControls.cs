using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
    public interface IControls
    {
         EmployeeEntity.Controls GetCheckoutIndividualEmails();
         EmployeeEntity.Controls GetCheckoutCombinedEmails();
         bool SaveDetails(EmployeeEntity.Controls obj);
         EmployeeEntity.Controls GetBirthdayEmails();
         EmployeeEntity.Controls GetMonthlyattendanceEmails();
         EmployeeEntity.Controls GetAnniversaryEmails();
    }
}
