using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionInfo.Logger
{
    /// <summary>
    /// Interface which any logger source should implement
    /// </summary>
    interface ILogger
    {
        /// <summary>
        /// General logging
        /// </summary>
        /// <param name="data">Message to log</param>
        void Log(string data);
        /// <summary>
        /// Exception logging
        /// </summary>
        /// <param name="ex">Exception description</param>
        /// <param name="stackTrace">Stack trace of exception</param>
        void LogException(string ex, string stackTrace);
    }
}
