using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastucture.Common;

namespace Infrastucture.VO
{
    public class ProcessVO : ApplicationBase
    {
        public ProcessVO() : base(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
        {
            Log.Trace("Trace--Instance Created");
        }
    }
}
