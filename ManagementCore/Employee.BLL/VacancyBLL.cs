#region Name Spaces

using SQLEmployee.DLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Employee.BLL
{

    #region Public Class

    public class VacancyBLL
    {

        #region Member

        IVacancy iVacancy;

        #endregion

        #region Methods

        public VacancyBLL()
        {
            iVacancy = new SQLEmployee.DLL.DataAccess.Vacancy();
        }

        public List<EmployeeEntity.Vacancy> GetAllVacancies()
        {
            return iVacancy.GetAllVacancies();
        }

        public string UpdateStatusByVacancyId(int vacancyId,Boolean status)
        {
            return iVacancy.UpdateStatusByVacancyId(vacancyId, status);
        }

        public string DeleteVacancyById(int vacancyId)
        {
            return iVacancy.DeleteVacancyById(vacancyId);
        }

        public EmployeeEntity.Vacancy GetVacancyById(int vacancyId)
        {
            return iVacancy.GetVacancyById(vacancyId);
        }

        public string AddNewVacancy(EmployeeEntity.Vacancy vacancy)
        {
            return iVacancy.AddNewVacancy(vacancy);
        }

        public string UpdateVacancyByVacancyId(EmployeeEntity.Vacancy vacancy)
        {
            return iVacancy.UpdateVacancyByVacancyId(vacancy);
        }

        #endregion

    }

    #endregion
}
