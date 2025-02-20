using SQLEmployee.DLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BLL
{
    public class TechnologiesBLL
    {
        ITechnologies ITechnologoies;

        public TechnologiesBLL()
        {
            ITechnologoies = new SQLEmployee.DLL.DataAccess.Technologies();
        }

        public List<EmployeeEntity.Technologies> GetAlltechnologoies()
        {
            return ITechnologoies.GetAllTechnologies();
        }
        public List<EmployeeEntity.Technologies> GetTechnolgiesListForAutoComplete(string prefix)
        {
            return ITechnologoies.GetTechnolgiesListForAutoComplete(prefix);
        }
    }
}
