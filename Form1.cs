using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace EnableProxy
{
    public partial class Form1 : Form
    {
        int status;
        public Form1()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
                status = (int)key.GetValue("ProxyEnable");
                key.Close();
                InitializeComponent((status == 0) ? false : true);
            }
            catch
            {
                
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
                if (status == 0)
                {
                    key.SetValue("ProxyEnable", 1, RegistryValueKind.DWord);
                    status = 1;
                }
                else
                {
                    key.SetValue("ProxyEnable", 0, RegistryValueKind.DWord);
                    status = 0;
                }
                key.Close();
            }
            catch
            {
            }
        }
    }
}
