using AnthemDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemProjectBLL
{
    public class CategoriesBLL
    {
        #region Members

        ICategories iCategoires;

        #endregion

        #region Methods

        public CategoriesBLL()
        {
            iCategoires = new AnthemDLL.DataAccess.Categories();
        }

        public List<AnthemEntites.Categories> GetAllCategories()
        {
            return iCategoires.GetAllCategories();
        }
        public List<AnthemEntites.Categories> Responsive()
        {
            return iCategoires.Responsive();
        }
        public List<AnthemEntites.Categories> ASPNetDevelopment()
        {
            return iCategoires.ASPNetDevelopment();
        }
        public List<AnthemEntites.Categories> MVC()
        {
            return iCategoires.MVC();
        }
        public List<AnthemEntites.Categories> WordPress()
        {
            return iCategoires.WordPress();
        }
        public List<AnthemEntites.Categories> HTML5()
        {
            return iCategoires.HTML5();
        }
        public List<AnthemEntites.Categories> Mobile()
        {
            return iCategoires.Mobile();
        }
        public List<AnthemEntites.Categories> CSS()
        {
            return iCategoires.CSS();
        }
        public List<AnthemEntites.Categories> JQuery()
        {
            return iCategoires.JQuery();
        }
       


        #endregion
    }
}
