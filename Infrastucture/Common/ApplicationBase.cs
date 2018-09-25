using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Infrastucture.Common
{
    public class ApplicationBase
    {
        protected Logger Log { get; private set; }
        public ApplicationBase(Type declaringType)
        {
            Log = LogManager.GetLogger(declaringType.FullName);
        }
    }
}
