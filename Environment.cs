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

using Housekeeping;
using Housekeeping.Core.Configuration;
using Housekeeping.Core.Handlers;
using Housekeeping.Core.Security;
using Housekeeping.Utilities;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Housekeeping
{
    internal class Environment
    {
        public static bool is_started = false;
        internal static ConfigurationData configuration_manager = new ConfigurationData(Path.Combine(Application.StartupPath, "configuration.ini"));
        internal static RemoteCall remote_call = new RemoteCall();

        internal static ConfigurationData read_config()
        {
            return configuration_manager;
        }

        internal static RemoteCall do_call()
        {
            return remote_call;
        }

        internal static void initialize_environment()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var login_form = new LoginForm();
            login_form.Show();
            Application.Run();

            is_started = true;
        }
    }
}
