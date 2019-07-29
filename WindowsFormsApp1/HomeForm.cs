using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class HomeForm : Form
    {
        private string RootCustomerDirPath;
        private string storagePath;
        private string[] arrayOfCustomers;
        private string SelectedCustomer;

        public HomeForm()
        {
            ReadConfigSettings();
            InitializeComponent();
            PopulateCustomerList();

        }

        private void PopulateCustomerList()
        {
            listView_Customers.AutoArrange = true;

            // add customers to ListView
            try
            {
                arrayOfCustomers = Directory.GetDirectories(RootCustomerDirPath);
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
            for (int i = 0; i < arrayOfCustomers.Length; i++)
            {
                arrayOfCustomers[i] = arrayOfCustomers[i].Remove(0,RootCustomerDirPath.Length+1);
                listView_Customers.Items.Add(arrayOfCustomers[i]);
            }
        }

        private void ReadConfigSettings()
        {
            ConfigSettings settings = new ConfigSettings();
            RootCustomerDirPath = settings.GetRootCustomerDirPath();
            storagePath = settings.GetCustomerStoragePath();
        }

        private void SelectArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openArchive = new OpenFileDialog();
            if (openArchive.ShowDialog() == DialogResult.OK)
            {
                ArchiveHandler archiveHandler = new ArchiveHandler(openArchive.FileName);
                StoreFile(archiveHandler);
            }
        }

        private void StoreFile(ArchiveHandler archiveHandler)
        {
            // Copy the archive into the target directory
            string srcDir = archiveHandler.getPathToArchive();
            string targetDir = RootCustomerDirPath +"\\"+ SelectedCustomer +"\\"+ storagePath +"\\"+ archiveHandler.getArchiveDate();

            // Determine whether the directory exists.
            if (Directory.Exists(targetDir))
            {
                Console.WriteLine("That path exists already.");
                return;
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(targetDir);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(targetDir));


            System.IO.File.Copy(srcDir, targetDir) ;
        }

        private void SelectKRCDiagToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.Show();
        }

        // quit application
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void ListView_Customers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            SelectedCustomer = listView_Customers.FocusedItem.Text;
            Console.WriteLine("Selected Customer: " + listView_Customers.FocusedItem.Text);
        }
    }
}
