using AnthemDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnthemEntites;

namespace AnthemProjectBLL
{
    public class VacancyBLL
    {
         #region Members

        IVacancy iVacancy;

        #endregion

        #region Methods

        public VacancyBLL()
        {
            iVacancy = new AnthemDLL.DataAccess.Vacancy();
        }

        public List<AnthemEntites.Vacancy> GetAllActiveVacancies()
        {
            return iVacancy.GetAllActiveVacancies();
        }

        public int GetActiveVacanciesCount()
        {
            return iVacancy.GetActiveVacanciesCount();
        }

        #endregion
    }
}
