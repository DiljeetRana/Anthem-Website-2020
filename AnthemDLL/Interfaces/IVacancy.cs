using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemDLL.Interfaces
{
    public interface IVacancy
    {
        List<AnthemEntites.Vacancy> GetAllActiveVacancies();
        int GetActiveVacanciesCount();
    }
}
