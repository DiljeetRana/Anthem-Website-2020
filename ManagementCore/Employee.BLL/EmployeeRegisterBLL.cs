using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;
using System.IO;

namespace Employee.BLL
{
   public class EmployeeRegisterBLL
    {
        IEmployeeWork iemployeework;
        public EmployeeRegisterBLL()
        {
            iemployeework = new SQLEmployee.DLL.DataAccess.SQLEmployeesWork();
        }

        public string RegisterEmployee(EmployeeEntity.EmployeeEntity employee)
        {
            return iemployeework.RegisterEmployee(employee);
        }
        public string ChangeImage(EmployeeEntity.EmployeeEntity employee)
        {
            return iemployeework.ChangeImage(employee);
        }

        public int GeneratePassword(EmployeeEntity.EmployeeEntity employee)
        {
            return iemployeework.GeneratePassword(employee);
        }

        public EmployeeEntity.EmployeeEntity SendUsernameAndPassword(long employeeid)
        {
            return iemployeework.SendUsernameAndPassword(employeeid);
        }

        public EmployeeEntity.EmployeeEntity CheckUsernameAndPassword(string username, string password)
        {
            return iemployeework.CheckUsernameAndPassword(username, password);
        }

        public int ChangePassword(EmployeeEntity.EmployeeEntity employee)
        {
            return iemployeework.ChangePassword(employee);
        }

        public EmployeeEntity.EmployeeEntity CheckIsVerified(long employeeid)
        {
            return iemployeework.CheckIsVerified(employeeid);
        }

        public EmployeeEntity.EmployeeEntity EmployeeProfile(string username)
        {
            return iemployeework.EmployeeProfile(username);
        }

        public int BlockEmployee(long employeeid)
        {
            return iemployeework.BlockEmployee(employeeid);
        }

        public int ActivateEmployee(long employeeid)
        {
            return iemployeework.ActivateEmployee(employeeid);
        }

        public int CheckFirstTimeProfile(string username)
        {
            return iemployeework.CheckFirstTimeProfile(username);
        }
      
    }
}
