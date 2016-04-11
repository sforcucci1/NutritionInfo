using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NutritionInfo.Logger
{
    public static class LogHandler
    {
        private static ILogger _logger = null;

        public static void Log(string data)
        {
            if (_logger == null)
            {
                return;
            }
            else
            {
                _logger.Log(data);
            }
        }

        public static void LogException(string ex, string stackTrace)
        {
            if (_logger == null)
            {
                return;
            }
            else
            {
                _logger.LogException(ex, stackTrace);
            }
        }

        public static void CreateLogger(TextBox txt)
        {
            _logger = new UILogger(txt);
        }
    }
}
