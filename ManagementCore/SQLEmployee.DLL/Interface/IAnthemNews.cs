using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
    public interface IAnthemNews
    {
        List<EmployeeEntity.AnthemNewsEntity> GetAllAnthemNews();
        List<EmployeeEntity.AnthemNewsEntity> GetAllAnthemNewstopfive();
        string AddAnthemNews(EmployeeEntity.AnthemNewsEntity Model);
        EmployeeEntity.AnthemNewsEntity GetAnthemNews(int AnthemNewsId);
        EmployeeEntity.AnthemNewsEntity UpdateAnthemNews(EmployeeEntity.AnthemNewsEntity MessageID);
        bool DeleteAnthemNews(int AnthemNewsId);
    }
}
