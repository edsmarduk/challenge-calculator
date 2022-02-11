using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant365.Core
{
    /// <summary>
    /// Logging class that outputs logs to the console
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        public void WriteLine(string message)
        {
           Console.WriteLine(message);
        }
    }
}
