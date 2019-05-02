using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Logging
{
    public enum LoggingTarget : byte
    {
        FileSystem = 1,
        Database,
    }
}
