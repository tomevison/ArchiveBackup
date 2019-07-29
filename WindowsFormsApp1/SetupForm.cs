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
        }

        private void Button_SetCustomerRootDir_Click(object sender, EventArgs e)
        {
            ConfigSettings settings = new ConfigSettings();
            settings.setRootCustomerDirPath(textBox_RootCustomerDirPath.Text);
        }

        private void Button_SetStorageDir_Click(object sender, EventArgs e)
        {
            ConfigSettings settings = new ConfigSettings();
            settings.SetCustomerStoragePath(tb_CustomerStoragePath.Text);
        }
    }
}
