using Housekeeping;
using Housekeeping.Core.Security;
using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Housekeeping.Utilities
{
    internal class RemoteCall
    {
        internal static string site_url = Environment.read_config().data["site.url"];
        internal static string volume_serial = VolumeSerial.get_serial();

        internal string remote_call(string call_type, string post_data)
        {
            try
            {
                WebRequest request = WebRequest.Create("http://" + site_url + "/housekeeping/" + call_type + ".php");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                ((HttpWebRequest)request).UserAgent = site_url + " Housekeeping Program";
                post_data = post_data + "&volume_serial=" + volume_serial;
                byte[] byteArray = Encoding.UTF8.GetBytes(post_data);
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                return reader.ReadToEnd();

            }

            catch (Exception e)
            {
                MessageBox.Show("Their was an error connecting to: " + site_url, "Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}
