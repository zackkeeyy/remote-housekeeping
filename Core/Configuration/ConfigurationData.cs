using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Housekeeping.Core.Configuration
{
    internal class ConfigurationData
    {
        internal string line;
        internal Dictionary<string, string> data = new Dictionary<string, string>();

        internal ConfigurationData(string configuration_path)
        {
            try
            {
                if (File.Exists(configuration_path))
                {
                    using (StreamReader reader = new StreamReader(configuration_path))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if ((line.Length >= 1) && !line.StartsWith("#"))
                            {
                                int split = line.IndexOf('=');
                                if (split != -1)
                                {
                                    this.data.Add(line.Substring(0, split), line.Substring(split + 1));
                                }
                            }
                        }

                        reader.Close();
                    }
                }
                else
                {
                    using (StreamWriter file = new StreamWriter(configuration_path))
                    {
                        file.WriteLine("site.url=");
                        file.Dispose();
                    }

                    MessageBox.Show("Configuration file not found, a new one has been generated.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
