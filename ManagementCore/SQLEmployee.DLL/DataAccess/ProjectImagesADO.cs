using SQLEmployee.DLL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEmployee.DLL.DataAccess
{
    public partial class ProjectImages
    {

        // <summary>
        /// Add New Employee Record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string AddNewImageToPortfolio(EmployeeEntity.ProjectImages imageData)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Output;
                parameter.ParameterName = "@status";
                parameter.Size = 50;

                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_AddNewImageForPortfolio",
                    new SqlParameter("@imageURL", imageData.ImageURL),
                    new SqlParameter("@projectId", imageData.ProjectId)
                    , parameter))
                    return parameter.Value.ToString();
            }
        }

        /// <summary>
        /// Add New Employee Record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string DeleteImageByImageId(int imageId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_DeleteImageByImageId",
                    new SqlParameter("@imageId", imageId)))
                    return "success";
            }
        }

        public List<EmployeeEntity.ProjectImages> GetAllProjectImagesByProjectId(int projectId)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.ProjectImages> projectsList = new List<EmployeeEntity.ProjectImages>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "usp_GetAllImagesByProjectId",
                    new SqlParameter("@projectId", projectId)))
                    while (dr.Read())
                    {
                        EmployeeEntity.ProjectImages ProjectData = new EmployeeEntity.ProjectImages();
                        ProjectData.ProjectId = Convert.ToInt32(dr["ProjectId"]);
                        ProjectData.ImageId = Convert.ToInt32(dr["ImageId"]);
                        ProjectData.ImageURL = Convert.ToString(dr["ImageURL"]);
                        projectsList.Add(ProjectData);
                    }
                return projectsList;
            }
        }
    }
}
