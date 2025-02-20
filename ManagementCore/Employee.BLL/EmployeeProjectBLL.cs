using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeEntity;
using SQLEmployee.DLL.Interface;


namespace Employee.BLL
{
    public class EmployeeProjectBLL
    {
        IEmplopyeeProject iemployeeProject;
        public EmployeeProjectBLL()
        {           
            iemployeeProject = new SQLEmployee.DLL.DataAccess.EmployeeProjectSql();
        }
        public List<EmployeeEntity.EmployeeProjectEntity> GetEmployeeProjects(int EmployeeId)
        {
            //EmployeeId = 23;
            return iemployeeProject.GetEmployeeProjects(EmployeeId);
        }
        public string AddGetEmployeeProject(EmployeeEntity.EmployeeProjectEntity Model)
        {
            return iemployeeProject.AddGetEmployeeProject(Model);
        }
        public bool DeleteEmployeeProject(int EmployeeProjectId)
        {
            return iemployeeProject.DeleteEmployeeProject(EmployeeProjectId);
        }

        public EmployeeEntity.EmployeeProjectEntity GetEmployeeProject(int EmployeePid)
        {
            return iemployeeProject.GetEmployeeProject(EmployeePid);
        }

        public EmployeeEntity.EmployeeProjectEntity UpdateEmployeeProject(EmployeeEntity.EmployeeProjectEntity Model)
        {
            return iemployeeProject.UpdateEmployeeProject(Model);
        }



        public string AddGetWork(EmployeeEntity.EmployeeProjectEntity Model)
        {
            return iemployeeProject.AddGetWork(Model);
        }

        public string AddGetEducation(EmployeeEntity.EmployeeProjectEntity Model)
        {
            return iemployeeProject.AddGetEducation(Model);
        }

        public EmployeeEntity.EmployeeProjectEntity GetWorkInfomation(int CompanyId)
        {
            return iemployeeProject.GetWorkInfomation(CompanyId);
        }

        public EmployeeEntity.EmployeeProjectEntity UpdateWork(EmployeeEntity.EmployeeProjectEntity CompanyDetail)
        {
            return iemployeeProject.UpdateWork(CompanyDetail);
        }

        public List<EmployeeEntity.EmployeeProjectEntity> GetAllWorks(int EmployeeId)
        {     
            return iemployeeProject.GetAllWorks(EmployeeId);
        }
        public List<EmployeeEntity.EmployeeProjectEntity> GetEducationInformations(int EmployeeId)
        {
            return iemployeeProject.GetEducationInformations(EmployeeId);
        }
        public bool DeleteWork(int CompanyId)
        {
            return iemployeeProject.DeleteWork(CompanyId);
        }

        public EmployeeEntity.EmployeeProjectEntity GetEducation(int SchoolId)
        {
            return iemployeeProject.GetEducation(SchoolId);
        }

        public EmployeeEntity.EmployeeProjectEntity UpdateEducation(EmployeeEntity.EmployeeProjectEntity SchoolDetail)
        {
            return iemployeeProject.UpdateEducation(SchoolDetail);
        }

        public bool DeleteEducation(int SchoolId)
        {
            return iemployeeProject.DeleteEducation(SchoolId);
        }


        public string AddPage(EmployeeEntity.EmployeeProjectEntity Model)
        {
            return iemployeeProject.AddPage(Model);
        }
        public List<EmployeeEntity.EmployeeProjectEntity> GetPages()
        {
           
            return iemployeeProject.GetPages();
        }

        public bool DeletePage(int PageId)
        {
            return iemployeeProject.DeletePage(PageId);
        }

        public EmployeeEntity.EmployeeProjectEntity GetPage(int PageId)
        {
            return iemployeeProject.GetPage(PageId);
        }


        public string UpdatePage(EmployeeEntity.EmployeeProjectEntity PageI)
        {
            return iemployeeProject.UpdatePage(PageI);
        }
        public EmployeeEntity.EmployeeProjectEntity GetViewPage(string PageName)
        {
            return iemployeeProject.GetViewPage(PageName);
        }
        public List<EmployeeEntity.EmployeeCheckEntity> GetFestivalDetail()
        {
            return iemployeeProject.GetFestivalDetail();
        }

    }
}
