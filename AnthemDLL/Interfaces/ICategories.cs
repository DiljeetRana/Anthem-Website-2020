using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemDLL.Interfaces
{
    public interface ICategories
    {
        List<AnthemEntites.Categories> GetAllCategories();
        List<AnthemEntites.Categories> Responsive();
        List<AnthemEntites.Categories> ASPNetDevelopment();
        List<AnthemEntites.Categories> MVC();
        List<AnthemEntites.Categories> WordPress();
        List<AnthemEntites.Categories> HTML5();
        List<AnthemEntites.Categories> Mobile();
        List<AnthemEntites.Categories> CSS();
        List<AnthemEntites.Categories> JQuery();
        
    }
}
