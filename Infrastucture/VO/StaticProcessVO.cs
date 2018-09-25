using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastucture.Common;

namespace Infrastucture.VO
{
    public class StaticProcessVO
    {
        public StaticProcessVO()
        {
            Staticlogger.LogInfo(this.GetType(), "Incidents Created");
        }

        public StaticProcessVO(string msg)
        {
            Staticlogger.LogInfo(this.GetType(), msg);
        }
    }
}
