#region Name Spaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace SQLEmployee.DLL.Interface
{

    #region Interface

    public interface IVacancy
    {
        List<EmployeeEntity.Vacancy> GetAllVacancies();
        string UpdateStatusByVacancyId(int vacancyId, Boolean status);
        string DeleteVacancyById(int vacancyId);
        EmployeeEntity.Vacancy GetVacancyById(int id);
        string UpdateVacancyByVacancyId(EmployeeEntity.Vacancy vacancy);
        string AddNewVacancy(EmployeeEntity.Vacancy vacancy);
    }

    #endregion

}
