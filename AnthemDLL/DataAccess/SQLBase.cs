using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace AnthemDLL
{
   public abstract class SQLBase
    {
       public SQLBase()
       {
       }

       public static string GetConnectionString()
       {
           return ConfigurationManager.ConnectionStrings["DBEmployees"].ConnectionString;
       }
    }
}
