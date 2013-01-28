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

        public LoginForm()
        {
            InitializeComponent();
            if (Housekeeping.Core.Security.BanCheck.ban_check("volume_serial"))
            {
                button_login.Enabled = false;
                button_login.Text = "Banned from server";
            }

            label_servername.Text = "Server URL: " + Housekeeping.Environment.read_config().data["site.url"];
        }

        private void textbox_username_TextChanged(object sender, EventArgs e)
        {
            user_name = textbox_username.Text;
        }

        private void textbox_password_TextChanged(object sender, EventArgs e)
        {
            user_pass = textbox_password.Text;
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (user_name != null && user_pass != null)
            {
                Environment.do_login(user_name, user_pass);
            }
            else
            {
                if (user_name == null)
                {
                    MessageBox.Show("You must type in your username!", "Invalid Login");
                    this.textbox_username.Focus();
                }
                else if(user_pass == null)
                {
                    MessageBox.Show("You must type in your password!", "Invalid Login");
                    this.textbox_password.Focus();
                }
                else
                {
                    MessageBox.Show("You must type both your username & password!", "Error");
                    this.textbox_username.Focus();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
