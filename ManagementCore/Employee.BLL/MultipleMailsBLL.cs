using Employee.BLL.Utility;
using SQLEmployee.DLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BLL
{
    public class MultipleMailsBLL
    {
        IMultipleMail IMail;
        public MultipleMailsBLL()
        {
            IMail = new SQLEmployee.DLL.DataAccess.MultipleMail();
        }

        public List<EmployeeEntity.MultipleMails> GetEmployees()
        {
            return IMail.GetEmployess();
        }

        public List<EmployeeEntity.MultipleMails> GetClients()
        {
             var Result = IMail.GetClients();
            foreach(var data in Result)
            {
                data.Email = SecurityProvider.Decrypt(data.Email, true, "997deggs5eg8seg4s5s7se8h7s7sh4sehse5h781srehs4h8");
            }
            return Result;
        }

    }
}
