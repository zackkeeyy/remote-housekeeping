/*=========================================================
| remote-housekeeping
| #########################################################
| remote-housekepeing developed by Bill Gilson
| Visit billsonnn.com/projects
| #########################################################
| Developed with stability & security in mind and uses
| api calls to remote-housekeeping-api
| #########################################################
\=========================================================*/

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
        [STAThread]
        internal static void Main()
        {
            if (!Environment.is_started)
            {
                Environment.initialize_environment();
            }
        }
    }
}
