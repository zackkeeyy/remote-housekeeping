using Housekeeping;
using Housekeeping.Core.Configuration;
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
        internal static LanguageData language_manager = new LanguageData(Path.Combine(Application.StartupPath, "language.ini"));
        internal static RemoteCall remote_call = new RemoteCall();

        internal static ConfigurationData read_config()
        {
            return configuration_manager;
        }

        internal static LanguageData read_lang()
        {
            return language_manager;
        }

        internal static RemoteCall do_call()
        {
            return remote_call;
        }

        internal static void do_login(string user_name, string user_pass)
        {
            if (BanCheck.ban_check("volume_serial"))
            {
                MessageBox.Show(Properties.Settings.Default.serial_banned_message, "Invalid Login");
                System.Environment.Exit(0);
            }
            else if (user_name != null && user_pass != null)
            {
                if (do_call().remote_call("login.handler", "do=login&user_name=" + user_name + "&user_pass=" + user_pass) == "1")
                {
                    MessageBox.Show("Welcome " + user_name + "!", "Successful Login");
                    Application.OpenForms["LoginForm"].Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Invalid Login");
                }
            }
            else
            {
                MessageBox.Show("You must type both your username & password!", "Invalid Login");
            }
        }

        internal static void initialize_environment()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
