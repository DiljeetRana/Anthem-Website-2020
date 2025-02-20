using AnthemDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthermBLL
{
    public class SlackBLL
    {
        #region Members

        ISlack iSlack;

        #endregion
        public SlackBLL()
        {
            iSlack = new AnthemDLL.DataAccess.SQLSlack();
        }
        public string InsertLeaveDetails(AnthemEntities.SlackEntity slackleave)
        {
            return iSlack.InsertLeaveDetails(slackleave);
        }
    }
}
