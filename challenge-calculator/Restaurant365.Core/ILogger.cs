using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant365.Core
{
    /// <summary>
    /// Interface that all loggers will implement
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes message to the appropriate place
        /// </summary>
        /// <param name="message">The message to write</param>
        void WriteLine(string message);
    }
}
