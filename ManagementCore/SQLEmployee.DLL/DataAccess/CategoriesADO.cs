#region Name Spaces

using SQLEmployee.DLL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace SQLEmployee.DLL.DataAccess
{
   public partial class Catrgoires
   {

       #region SQL Opeartion

       public List<EmployeeEntity.Categories> GetAllCategories()
      {
          using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
          {
              List<EmployeeEntity.Categories> categoriesList = new List<EmployeeEntity.Categories>();
              using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAllCategories",
                  null))
                  while (dr.Read())
                  {
                      EmployeeEntity.Categories catrgoryData = new EmployeeEntity.Categories();
                      catrgoryData.Id = Convert.ToInt32(dr["Id"]);
                      catrgoryData.Name = Convert.ToString(dr["Name"]);
                      categoriesList.Add(catrgoryData);
                  }
              return categoriesList;
          }
      }

       public List<EmployeeEntity.Categories> GetAllSubCategories()
       {
           using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
           {
               List<EmployeeEntity.Categories> subcategorylist = new List<EmployeeEntity.Categories>();
               using(IDataReader dr=exec.ExecuteReader(CommandType.StoredProcedure,"usp_GetSubcategories",null))
                   while (dr.Read())
                   {
                       EmployeeEntity.Categories categories = new EmployeeEntity.Categories();
                       categories.Id = (int)dr["Id"];
                       categories.Name = dr["Name"].ToString();
                       subcategorylist.Add(categories);
                   }
               return subcategorylist;
           }
       }

        public List<EmployeeEntity.Categories> getTemplates(string occ)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.Categories> subcategorylist = new List<EmployeeEntity.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetTemplates", 
                      new SqlParameter("@occ", occ)
                    ))
                    while (dr.Read())
                    {
                        EmployeeEntity.Categories categories = new EmployeeEntity.Categories();
                        categories.TemplateId = Convert.ToInt32(dr["TemplateId"]);
                        categories.TemplatePath = (dr["TemplatePath"]).ToString();
                        categories.ImageMessage= (dr["ImageMessage"]).ToString();
                        categories.Greeting= (dr["Greeting"]).ToString();
                        subcategorylist.Add(categories);
                    }
                return subcategorylist;
            }
        }

        public bool insertUsedTemplate(int TempId, string occ, string MediaType)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_InsertUsedTemplate",
                    new SqlParameter("@TempId", TempId),
                    new SqlParameter("@occ", occ),
                    new SqlParameter("@MediaType", MediaType)
                ))
                    
                return true;
            }
        }



        #endregion


    }
}
