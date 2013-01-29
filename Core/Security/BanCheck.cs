using Housekeeping;
using Housekeeping.Utilities;
using Housekeeping.Core.Security;
using System.Windows.Forms;

namespace Housekeeping.Core.Security
{
    internal class BanCheck
    {
        internal static bool ban_check(string ban_type, string extra_data = null)
        {
            return (Environment.do_call().remote_call("ban_check", "type=volume_serial" + extra_data) == "1") ? true : false;
        }
    }
}
