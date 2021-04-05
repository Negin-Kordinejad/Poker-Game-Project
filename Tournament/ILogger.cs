using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament
{
   public interface ILogger
    {
        void LogException(Exception exception, string description);
    }
}
