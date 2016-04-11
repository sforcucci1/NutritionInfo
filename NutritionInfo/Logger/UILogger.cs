using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutritionInfo.Logger
{
    /// <summary>
    /// Logs to the windows form UI
    /// </summary>
    public class UILogger : ILogger
    {
        // Text box to output logs to
        private TextBox _txtLogOutput;

        /// <summary>
        /// Creates a logger which will output to a specific text box
        /// </summary>
        /// <param name="output">The text box to log to</param>
        public UILogger(TextBox output)
        {
            _txtLogOutput = output;
        }

        public void Log(string data)
        {
            _txtLogOutput.Text += data + Environment.NewLine + Environment.NewLine;
        }

        public void LogException(string ex, string stackTrace)
        {
            _txtLogOutput.Text += "Exception: " + ex + Environment.NewLine + Environment.NewLine + stackTrace + Environment.NewLine + Environment.NewLine;
        }
    }
}
