using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
    public interface ITechnologies
    {
        List<EmployeeEntity.Technologies> GetAllTechnologies();
        List<EmployeeEntity.Technologies> GetTechnolgiesListForAutoComplete(string prefix);
    }
}
