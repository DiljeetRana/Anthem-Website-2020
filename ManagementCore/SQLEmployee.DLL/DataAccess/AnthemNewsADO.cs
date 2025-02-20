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
    public partial class AnthemNewsSql
    {
        public List<EmployeeEntity.AnthemNewsEntity> GetAllAnthemNews()
              {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.AnthemNewsEntity> AnthemNewsList = new List<EmployeeEntity.AnthemNewsEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAnthemNews"))
                    while (dr.Read())
                    {

                        EmployeeEntity.AnthemNewsEntity Model = new EmployeeEntity.AnthemNewsEntity();
                        Model.MessageID = Convert.ToInt32(dr["MessageID"]);
                        Model.Message = dr["Message"].ToString();
                        //Model.StartDate1 = dr["StartDate"].ToString();
                        //Model.EndDate1 = dr["EndDate"].ToString();
                        Model.StartDate = !(dr["StartDate"] is DBNull) ? Convert.ToDateTime(dr["StartDate"]) : DateTime.Now;
                        Model.EndDate = !(dr["EndDate"] is DBNull) ? Convert.ToDateTime(dr["EndDate"]) : DateTime.Now;
                        Model.Color = dr["Color"].ToString();
                        Model.PublishDate = Convert.ToDateTime(dr["PublishDate"]);
                        Model.Continuous = Boolean.Parse(dr["Continuous"].ToString());
                        AnthemNewsList.Add(Model);
                    }
                return AnthemNewsList;
            }
        }
        public List<EmployeeEntity.AnthemNewsEntity> GetAllAnthemNewstopfive()
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                List<EmployeeEntity.AnthemNewsEntity> AnthemNewstopfiveList = new List<EmployeeEntity.AnthemNewsEntity>();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAnthemNewstopfive"))
                    while (dr.Read())
                    {

                        EmployeeEntity.AnthemNewsEntity Model = new EmployeeEntity.AnthemNewsEntity();
                        Model.MessageID = Convert.ToInt32(dr["MessageID"]);
                        Model.Message = dr["Message"].ToString();
                        //Model.StartDate1 = dr["StartDate"].ToString();
                        //Model.EndDate1 = dr["EndDate"].ToString();
                        Model.StartDate = Convert.ToDateTime(dr["StartDate"]);
                        Model.EndDate = Convert.ToDateTime(dr["EndDate"]);
                        Model.Color = dr["Color"].ToString();
                        Model.PublishDate = Convert.ToDateTime(dr["PublishDate"]);
                       // Model.Color = dr["Color"].ToString();
                        AnthemNewstopfiveList.Add(Model);
                    }
                return AnthemNewstopfiveList;
            }
        }
        public string AddAnthemNews(EmployeeEntity.AnthemNewsEntity Model)
        {
            string Result = string.Empty;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_InsertAnthemNews",
                new SqlParameter("@Message", Model.Message),
                //new SqlParameter("@EmployeeId", Model.EmployeeId),
                new SqlParameter("@StartDate", Model.StartDate),
                new SqlParameter("@EndDate", Model.EndDate),
                new SqlParameter("@Color", Model.Color),
                new SqlParameter("@Continuous", Model.Continuous)
                ))
                    while (dr.Read())
                    {
                        Result = (dr["Result"]).ToString();
                    }
            }
            return Result;

        }

        public EmployeeEntity.AnthemNewsEntity GetAnthemNews(int MessageId)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                EmployeeEntity.AnthemNewsEntity Model = new EmployeeEntity.AnthemNewsEntity();
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_GetAnthemNewsid",
                    new SqlParameter("@MessageID", MessageId)))
                    while (dr.Read())
                    {
                        //EmployeeEntity.AnthemNewsEntity Model = new EmployeeEntity.AnthemNewsEntity();
                        Model.MessageID = Convert.ToInt32(dr["MessageID"]);
                        Model.Message = dr["Message"].ToString();
                        //Model.StartDate1 = dr["StartDate"].ToString();
                        //Model.EndDate1 = dr["EndDate"].ToString();
                        Model.StartDate = !(dr["StartDate"] is DBNull) ? Convert.ToDateTime(dr["StartDate"]) : DateTime.Now;
                        Model.EndDate = !(dr["EndDate"] is DBNull) ? Convert.ToDateTime(dr["EndDate"]) : DateTime.Now;
                        Model.Color = dr["Color"].ToString();
                        Model.PublishDate = Convert.ToDateTime(dr["PublishDate"]);
                        Model.Continuous = Boolean.Parse(dr["Continuous"].ToString());
                        //Model.MessageID = Convert.ToInt32(dr["MessageID"]);
                        //Model.Message= dr["Message"].ToString();
                        //Model.StartDate = !(dr["StartDate"] is DBNull) ? Convert.ToDateTime(dr["StartDate"]) : DateTime.Now;
                        //Model.EndDate = !(dr["EndDate"] is DBNull) ? Convert.ToDateTime(dr["EndDate"]) : DateTime.Now;
                        //Model.Continuous=Boolean.Parse( dr["Continuous"].ToString());
                        //Model.Color = dr["Color"].ToString();
                    }
                return Model;
            }
        }

        public EmployeeEntity.AnthemNewsEntity UpdateAnthemNews(EmployeeEntity.AnthemNewsEntity Model)
        {

            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_UpdateAnthemNews",
                       new SqlParameter("@MessageID", Model.MessageID),
                       new SqlParameter("@Message", Model.Message),
                       
                        new SqlParameter("@StartDate", Model.StartDate),
                        new SqlParameter("@EndDate", Model.EndDate),
                        new SqlParameter("@Color", Model.Color),
                        new SqlParameter("@Continuous", Model.Continuous)
                //new SqlParameter("@ContactNumber", Model.ContactNumber)
                ))
                    return Model;

            }

        }

        public bool DeleteAnthemNews(int MessageId)
        {
            var result = false;
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDataReader dr = exec.ExecuteReader(CommandType.StoredProcedure, "sp_DeleteAnthemNews",
                new SqlParameter("@MessageID", MessageId)
                ))
                    while (dr.Read())
                    {
                        result = Convert.ToBoolean(dr["IsDeleted"]);
                    }
            }
            return result;

        }

    }
}
