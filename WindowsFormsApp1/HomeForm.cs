using ArchiveBackup;
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
        private string SelectedCustomer = null;

        public HomeForm()
        {
            ReadConfigSettings();
            InitializeComponent();
            PopulateCustomerList();
        }

        // populate customer list from root directory in config
        private void PopulateCustomerList()
        {
            listView_Customers.AutoArrange = true;
            
            

            // grab all the customer names from the selected root directory
            try
            {
                arrayOfCustomers = Directory.GetDirectories(RootCustomerDirPath);
                Array.Sort(arrayOfCustomers);
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Customer path not found, modify this in ArchiveBackup.Config.xml");
                System.Environment.Exit(0);
            }
            
            // get clean list of names for the front end
            for (int i = 0; i < arrayOfCustomers.Length; i++)
            {
                arrayOfCustomers[i] = arrayOfCustomers[i].Remove(0,RootCustomerDirPath.Length+1);
                listView_Customers.Items.Add(arrayOfCustomers[i]);
            }
        }

        // read config settings from ArchiveBackup.Config.xml
        private void ReadConfigSettings()
        {
            ConfigSettings settings = new ConfigSettings();
            RootCustomerDirPath = settings.GetRootCustomerDirPath();
            storagePath = settings.GetCustomerStoragePath();
        }

        // 
        private void SelectArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectArchiveFile();
        }

        // bring up diagloge to select a file
        private void selectArchiveFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in ofd.FileNames)
                {
                    try
                    {
                        ArchiveHandler archiveHandler = new ArchiveHandler(file);
                        StoreFile(archiveHandler);
                    }
                    catch (InvalidDataException ex)
                    {
                        return;
                    }
                }
                Console.WriteLine("Process completed successfully!");
            }
        }

        // Copy the archive into the target directory
        private void StoreFile(ArchiveHandler archiveHandler)
        {
            // build source and target directorys
            string srcFile = archiveHandler.getPathToArchive();
            string targetDir = RootCustomerDirPath +"\\"+ SelectedCustomer +"\\"+ storagePath +"\\" + archiveHandler.RobName + "\\" + archiveHandler.ArchiveDate;
            string targetFile = targetDir + "\\" + archiveHandler.FileName;

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(targetDir);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(targetDir));

            // Copy the archive into the target directory
            if(File.Exists(srcFile))
            {
                try{
                    File.Copy(srcFile, targetFile);
                    Console.WriteLine("The archive was coppied successfully at {0}.", Directory.GetCreationTime(targetFile));
                } catch (IOException e)
                {
                    Console.WriteLine(e);
                    MessageBox.Show(e.Message);
                    return;
                }
            }            
        }

        private void SetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            setupForm.Show();

            // update customer list
            setupForm.FormClosed += new FormClosedEventHandler(SetupFormClosed);
        }

        // update the customer list if setup form has been closed
        private void SetupFormClosed(object sender, FormClosedEventArgs e)
        {
            listView_Customers.Items.Clear();
            ReadConfigSettings();
            PopulateCustomerList();
        }

        // quit application
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void ListView_Customers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // update the selected cutomer when the user changes list collection
            string previouslySelectedCustomer;
            previouslySelectedCustomer = SelectedCustomer;
            SelectedCustomer = listView_Customers.FocusedItem.Text;
            if (previouslySelectedCustomer != SelectedCustomer)
            {
                Console.WriteLine("Selected Customer: " + listView_Customers.FocusedItem.Text);
            }

        }

        private void Btn_SelectArchive_Click(object sender, EventArgs e)
        {
            selectArchiveFile();
        }

        private void ListView_Customers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                selectArchiveFile();
            }
        }

        private void ListView_Customers_DoubleClick(object sender, EventArgs e)
        {
            selectArchiveFile();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
