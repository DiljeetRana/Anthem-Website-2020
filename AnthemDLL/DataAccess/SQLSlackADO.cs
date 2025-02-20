using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemDLL.DataAccess
{
    public partial class SQLSlack
    {
        public string InsertLeaveDetails(AnthemEntities.SlackEntity slackleave)
        {
            using (ADOExecution exec = new ADOExecution(SQLBase.GetConnectionString()))
            {
                using (IDbCommand dr = exec.ExecuteNonQuery(CommandType.StoredProcedure, "usp_SlackInsertLeaveDetails",
                  new SqlParameter("@email", slackleave.Email),
                  new SqlParameter("@startdate", slackleave.StartDate),
                  new SqlParameter("@enddate", slackleave.EndDate),
                  new SqlParameter("@reason", slackleave.Reason),
                  new SqlParameter("@reqdate", slackleave.Creation),
                  new SqlParameter("@noofdays", slackleave.NoOfDays)
                    ))
                    return null;
            }
        }

    }
}
