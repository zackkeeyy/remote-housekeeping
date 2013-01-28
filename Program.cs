using System;
using System.IO;
using System.Net;
using Housekeeping;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Housekeeping
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Program.start_environment();
        }

        internal static void start_environment()
        {
            if (!Environment.is_started)
            {
                Environment.initialize_environment();
            }
        }
    }
}
