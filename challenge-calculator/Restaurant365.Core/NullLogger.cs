using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant365.Core
{
    /// <summary>
    /// Logger that doesn't write to anywhere. 
    /// </summary>
    public class NullLogger : ILogger
    {
        public void WriteLine(string message)
        {
            // Do nothing
        }
    }
}
