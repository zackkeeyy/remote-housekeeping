using Housekeeping;
using Housekeeping.Utilities;
using Housekeeping.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Housekeeping.Core.Handlers
{
    internal class UserLogin
    {
        internal static int user_login(string user_name, string user_pass)
        {
            if (user_name != null && user_pass != null)
            {
                if (!BanCheck.ban_check("volume_serial"))
                {
                    if (Environment.do_call().remote_call("authenticate_login", "type=login&user_name=" + user_name + "&user_pass=" + user_pass) == "1")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 4;
            }
        }
    }
}
