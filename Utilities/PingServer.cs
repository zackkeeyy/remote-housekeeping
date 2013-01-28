using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Housekeeping.Utilities
{
    internal class PingServer
    {
        internal static bool ping_server(string server_ip, int timeout = 5)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(server_ip, timeout);

                return (reply.Status == IPStatus.Success) ? true : false;
            }

            catch (Exception e)
            {
                MessageBox.Show("Their was an error connecting to: " + server_ip, "Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return false;
        }
    }
}
