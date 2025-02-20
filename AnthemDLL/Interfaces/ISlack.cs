using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnthemDLL.Interfaces
{
    public interface ISlack
    {
        string InsertLeaveDetails(AnthemEntities.SlackEntity slackleave);
    }
}
