#region Name Spaces

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace AnthemDLL.DataAccess
{
    public partial class Categories
    {

        #region SQL operations

        public List<AnthemEntites.Categories> GetAllCategories()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "dbo.usp_GetAllCategoriesAndSubCategories",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.Name = Convert.ToString(dr["Categories"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
        
        #endregion
       
       
        public List<AnthemEntites.Categories> Responsive()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Responsive",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
        public List<AnthemEntites.Categories> ASPNetDevelopment()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "FilterASP",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
        public List<AnthemEntites.Categories> MVC()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "MVC",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
        public List<AnthemEntites.Categories> WordPress()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "FilterPHP",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
        public List<AnthemEntites.Categories> HTML5()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "HTML5",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
        public List<AnthemEntites.Categories> Mobile()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "Mobile",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
        public List<AnthemEntites.Categories> CSS()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "CSS",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
        public List<AnthemEntites.Categories> JQuery()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<AnthemEntites.Categories> categoriesList = new List<AnthemEntites.Categories>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "JQuery",
                    null))
                    while (dr.Read())
                    {
                        AnthemEntites.Categories ProjectData = new AnthemEntites.Categories();
                        ProjectData.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                        ProjectData.ProjectName = Convert.ToString(dr["ProjectName"]);
                        ProjectData.ProjectCategory = Convert.ToString(dr["ProjectCategories"]);
                        ProjectData.ProjectSubCategory = dr["SubCategories"].ToString();
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.EndDateofProject = Convert.ToDateTime(dr["ProjectEndDate"]);
                        ProjectData.Technolgies = Convert.ToString(dr["ProjectTechnologies"]);
                        ProjectData.DateofProject = Convert.ToDateTime(dr["DateofProject"]);
                        ProjectData.Description = Convert.ToString(dr["Description"]);
                        ProjectData.ProjectImage = Convert.ToString(dr["ProjectImage"]);
                        ProjectData.URL = Convert.ToString(dr["URL"]);
                        ProjectData.SmallDesciption = Convert.ToString(dr["smallDescription"]);
                        ProjectData.Priority = Convert.ToInt32(dr["Priority"]);
                        categoriesList.Add(ProjectData);
                    }
                return categoriesList;
            }
        }
    }
}
