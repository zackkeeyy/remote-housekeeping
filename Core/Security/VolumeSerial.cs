using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Housekeeping.Core.Security
{
    internal class VolumeSerial
    {
        internal static string drive_letter = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System).Substring(0, 1) + ":\\";

        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);

        internal static string get_serial()
        {
            uint serial_number = 0;
            uint max_comp_len = 0;
            StringBuilder volume_label = new StringBuilder(256);
            UInt32 volume_flags = new UInt32();
            StringBuilder file_system = new StringBuilder(256);
            long Ret = GetVolumeInformation(drive_letter, volume_label, (UInt32)volume_label.Capacity, ref serial_number, ref max_comp_len, ref volume_flags, file_system, (UInt32)file_system.Capacity);
            return Convert.ToString(serial_number);
            
        }
    }
}
