using ArchiveBackup;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class HomeForm : Form
    {
        private Boolean ShowConsole;
        private string[] arrayOfCustomers;
        private string SelectedCustomer, storagePath, RootCustomerDirPath = null;
        [DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int AllocConsole();
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;

        public HomeForm()
        {
            ReadConfigSettings();
            showConsole();
            InitializeComponent();
            PopulateCustomerList();
        }

        private void showConsole()
        {
            if (ShowConsole)
            {
                AllocConsole();
                IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
                Microsoft.Win32.SafeHandles.SafeFileHandle safeFileHandle = new Microsoft.Win32.SafeHandles.SafeFileHandle(stdHandle, true);
                FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
                StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);
            }
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
            ShowConsole = settings.GetShowConsole();
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
                        Console.WriteLine(archiveHandler);
                        StoreFile(archiveHandler);
                    }
                    catch (InvalidDataException ex)
                    {
                        return;
                    }
                }
                Console.WriteLine("Process Complete.");
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

            // Copy the archive into the target directory
            if(File.Exists(srcFile))
            {
                try{
                    File.Copy(srcFile, targetFile);
                    Console.WriteLine("The archive was coppied successfully at " + Directory.GetCreationTime(targetFile) + Environment.NewLine);
                } catch (IOException e)
                {
                    Console.WriteLine(e);
                    MessageBox.Show(e.Message);
                    return;
                }
            }
            Fin();
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
            showConsole();
        }

        // quit application
        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        // update the selected cutomer when the user changes list collection
        private void ListView_Customers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            string previouslySelectedCustomer;
            previouslySelectedCustomer = SelectedCustomer;
            SelectedCustomer = listView_Customers.FocusedItem.Text;
            if (previouslySelectedCustomer != SelectedCustomer)
            {
                Console.WriteLine("Selected Customer: " + listView_Customers.FocusedItem.Text);
            }

        }

        // open select achive window
        private void Btn_SelectArchive_Click(object sender, EventArgs e)
        {
            selectArchiveFile();
        }

        // select achive if enter is pressed while customer selected
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

        private void Panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (listView_Customers.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Select Customer first.");
                    return;
                }

                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string file in filePaths)
                {
                    try
                    {
                        ArchiveHandler archiveHandler = new ArchiveHandler(file);
                        Console.WriteLine(archiveHandler);
                        StoreFile(archiveHandler);
                    }
                    catch (InvalidDataException ex)
                    {
                        return;
                    }
                }
                Fin();
            }
        }

        private void Panel1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void Fin()
        {
            Console.WriteLine("Process Complete.");
        }


    }
}
