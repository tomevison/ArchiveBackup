using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
            ConfigSettings settings = new ConfigSettings();
            textBox_RootCustomerDirPath.Text = settings.GetRootCustomerDirPath();
            tb_CustomerStoragePath.Text = settings.GetCustomerStoragePath();
            checkBox_ShowConsole.Checked = settings.GetShowConsole();
        }

        private void Button_SaveStorageDir_Click(object sender, EventArgs e)
        {
            ConfigSettings settings = new ConfigSettings();
            settings.SetCustomerStoragePath(tb_CustomerStoragePath.Text);
            settings.setRootCustomerDirPath(textBox_RootCustomerDirPath.Text);
            settings.SetShowConsole(checkBox_ShowConsole.Checked);
        }
    }
}
