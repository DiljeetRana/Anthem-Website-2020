using EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.Interface
{
  public interface IEmplopyeeProject
    {
        List<EmployeeEntity.EmployeeProjectEntity> GetEmployeeProjects(int EmployeeId);
        string AddGetEmployeeProject(EmployeeEntity.EmployeeProjectEntity Model);
        bool DeleteEmployeeProject(int EmployeeProjectId);
        EmployeeEntity.EmployeeProjectEntity UpdateEmployeeProject(EmployeeEntity.EmployeeProjectEntity EmployeeProjectId);
        EmployeeEntity.EmployeeProjectEntity GetEmployeeProject(int EmployeeProjectId);


        string AddGetWork(EmployeeEntity.EmployeeProjectEntity Model);
        string AddGetEducation(EmployeeEntity.EmployeeProjectEntity Model);
        EmployeeEntity.EmployeeProjectEntity GetWorkInfomation(int CompanyId);
        EmployeeEntity.EmployeeProjectEntity UpdateWork(EmployeeEntity.EmployeeProjectEntity CompanyDetail );
        List<EmployeeEntity.EmployeeProjectEntity> GetAllWorks(int EmployeeId);
        List<EmployeeEntity.EmployeeProjectEntity> GetEducationInformations(int EmployeeId);
        bool DeleteWork(int CompanyId);

        EmployeeEntity.EmployeeProjectEntity GetEducation(int SchoolId);
        EmployeeEntity.EmployeeProjectEntity UpdateEducation(EmployeeEntity.EmployeeProjectEntity SchoolDetail);
        bool DeleteEducation(int SchoolId);

        string AddPage(EmployeeEntity.EmployeeProjectEntity Model);
        List<EmployeeEntity.EmployeeProjectEntity> GetPages();
        bool DeletePage(int PageId);
        EmployeeEntity.EmployeeProjectEntity GetPage(int PageId);

        string UpdatePage(EmployeeEntity.EmployeeProjectEntity PageI);
        EmployeeEntity.EmployeeProjectEntity GetViewPage(string PageName);
        List<EmployeeEntity.EmployeeCheckEntity> GetFestivalDetail();

    }
}
