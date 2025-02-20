using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLEmployee.DLL.Interface;
namespace Employee.BLL
{
   public class AnthemNewsBLL
    {
        IAnthemNews ianthemNews;
        public AnthemNewsBLL()
        {
            ianthemNews = new SQLEmployee.DLL.DataAccess.AnthemNewsSql();
        }
        public List<EmployeeEntity.AnthemNewsEntity> GetAnthemNewses()
        {
            
            return ianthemNews.GetAllAnthemNews();
        }
        public List<EmployeeEntity.AnthemNewsEntity> GetAnthemNewsestopFive()
        {

            return ianthemNews.GetAllAnthemNewstopfive();
        }
        public string AddAnthemNews(EmployeeEntity.AnthemNewsEntity Model)
        {
            return ianthemNews.AddAnthemNews(Model);
        }
        public EmployeeEntity.AnthemNewsEntity GetAnthemNews(int AnthemNewsId)
        {
            return ianthemNews.GetAnthemNews(AnthemNewsId);
        }
        public EmployeeEntity.AnthemNewsEntity UpdateAnthemNews(EmployeeEntity.AnthemNewsEntity Model)
        {
            return ianthemNews.UpdateAnthemNews(Model);
        }
        public bool DeleteAnthemNews(int AnthemNewsId)
        {
            return ianthemNews.DeleteAnthemNews(AnthemNewsId);
        }
    }
}
