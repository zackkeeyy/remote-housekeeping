using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Housekeeping.Core.Configuration
{
    internal class LanguageData
    {
        internal string line;
        internal Dictionary<string, string> data = new Dictionary<string, string>();

        internal LanguageData(string language_path)
        {
            try
            {
                if (File.Exists(language_path))
                {
                    using (StreamReader reader = new StreamReader(language_path))
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
                    using (StreamWriter file = new StreamWriter(language_path))
                    {
                        file.WriteLine();
                        file.Dispose();
                    }

                    MessageBox.Show("Language file not found, a new one has been generated.", "Language", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Language", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
