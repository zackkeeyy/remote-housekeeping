using Housekeeping;
using Housekeeping.Core.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Housekeeping
{
    public partial class LoginForm : Form
    {
        internal static string user_name;
        internal static string user_pass;
        internal static int process_login;

        public LoginForm()
        {
            InitializeComponent();

            label_username.Text = Properties.Settings.Default.login_username_label;
            label_password.Text = Properties.Settings.Default.login_password_label;
            label_servername.Text = Properties.Settings.Default.server_url_text + " " + Housekeeping.Environment.read_config().data["site.url"];
            button_login.Enabled = (Housekeeping.Core.Security.BanCheck.ban_check("volume_serial")) ? false : true;
            button_login.Text = (button_login.Enabled) ? Properties.Settings.Default.login_button_text_login : Properties.Settings.Default.login_button_text_banned;
            textbox_username.Focus();
        }

        private void textbox_username_TextChanged(object sender, EventArgs e)
        {
            user_name = (textbox_username.Text == null || textbox_username.Text == "") ? null : textbox_username.Text;
        }

        private void textbox_password_TextChanged(object sender, EventArgs e)
        {
            user_pass = (textbox_password.Text == null || textbox_password.Text == "") ? null : textbox_password.Text;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (user_name != null && user_pass != null)
            {
                process_login = Housekeeping.Core.Handlers.UserLogin.user_login(user_name, user_pass);
                switch (process_login)
                {
                    case 1: // Successful login
                        MessageBox.Show("Welcome " + user_name + "!", Properties.Settings.Default.login_title_success);
                        Application.OpenForms["LoginForm"].Close();
                        var home_form = new HomeForm();
                        home_form.Show();
                        break;
                    case 2: // Invalid username, password, or access level
                        MessageBox.Show(Properties.Settings.Default.error_login_failed, Properties.Settings.Default.login_title_invalid);
                        textbox_username.Text = null;
                        textbox_password.Text = null;
                        textbox_username.Focus();
                        break;
                    case 3: // Banned from server
                        MessageBox.Show(Properties.Settings.Default.serial_banned_message, Properties.Settings.Default.login_title_invalid);
                        System.Environment.Exit(0);
                        break;
                    default:
                        MessageBox.Show(Properties.Settings.Default.error_login_empty, Properties.Settings.Default.login_title_invalid);
                        textbox_username.Focus();
                        break;
                }
            }
            else
            {
                if (user_name == null && user_pass == null)
                {
                    MessageBox.Show(Properties.Settings.Default.error_login_empty, Properties.Settings.Default.login_title_invalid);
                    textbox_username.Focus();
                }
                else if (user_name == null)
                {
                    MessageBox.Show(Properties.Settings.Default.error_login_username, Properties.Settings.Default.login_title_invalid);
                    textbox_username.Focus();
                }
                else if (user_pass == null)
                {
                    MessageBox.Show(Properties.Settings.Default.error_login_password, Properties.Settings.Default.login_title_invalid);
                    textbox_password.Focus();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
