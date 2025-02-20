using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SQLEmployee.DLL.DataAccess
{
   public abstract class SQLBase
    {
       public SQLBase()
       {
       }


       public static string GetConnectionString()
       {
           return "Data Source=rose.arvixe.com;Initial Catalog=anthemdb;User ID=anthemdbuser;Password=AnthemG4232017";
       }
    }
}
