using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Infrastucture.Common
{
    public static class Staticlogger
    {
        public static void LogInfo(Type declaringType, string text)
        {
            LogManager.GetLogger(declaringType.FullName).Trace(text);
        }
    }
}
