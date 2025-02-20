using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
    public interface IEmployeeWork
    {
        string RegisterEmployee(EmployeeEntity.EmployeeEntity employee);
        string ChangeImage(EmployeeEntity.EmployeeEntity employee);
        int GeneratePassword(EmployeeEntity.EmployeeEntity employee);
        EmployeeEntity.EmployeeEntity SendUsernameAndPassword(long employeeid);
        EmployeeEntity.EmployeeEntity CheckUsernameAndPassword(string username, string password);
        int ChangePassword(EmployeeEntity.EmployeeEntity employee);
        EmployeeEntity.EmployeeEntity CheckIsVerified(long employeeid);
        EmployeeEntity.EmployeeEntity EmployeeProfile(string username);
        int BlockEmployee(long employeeid);
        int ActivateEmployee(long employeeid);
        int CheckFirstTimeProfile(string username);
    }
}
