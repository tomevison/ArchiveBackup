using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace ArchiveBackup
{
    // given the Archive path, 
    class ArchiveHandler
    {
        //private String RobName;
        private string pathToArchive;
        private string fileName;
        private string archiveDate;
        private string iRSerialNr;
        private string robName;
        private enum archiveTypes { krc_archive, krc_diag, sunrise_archive, sunrise_diag};
        private archiveTypes thisArchiveType;

        // getters and setters
        public string ArchiveDate { get => archiveDate; set => archiveDate = value; }
        public string IRSerialNr { get => iRSerialNr; set => iRSerialNr = value; }
        public string RobName { get => robName; private set => robName = value; }
        public string FileName { get => fileName; set => fileName = value; }

        public ArchiveHandler(string pathToArchive)
        {
            this.pathToArchive = pathToArchive; // full path to archive
            this.fileName = Path.GetFileName(pathToArchive);

            // open the archive
            try
            {
                using (ZipArchive zip = ZipFile.OpenRead(pathToArchive))
                {
                    // open am.ini file and grab the goodies
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        // Handle standard KRC archives
                        if (entry.Name == "am.ini")
                        {
                            thisArchiveType = archiveTypes.krc_archive;
                            Console.WriteLine("File Loaded: Archive");
                            using (var stream = entry.Open())
                            using (var reader = new StreamReader(stream))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    string[] tokens = line.Split('=');
                                    // Process line, e.g.:
                                    if (tokens[0] == "RobName") this.robName = tokens[1];
                                    if (tokens[0] == "Date") this.archiveDate = tokens[1];
                                    if (tokens[0] == "IRSerialNr") this.iRSerialNr = tokens[1];
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch (InvalidDataException e)
            {
                Console.WriteLine(e);
                MessageBox.Show("Invalid Data: " + pathToArchive + " is not a valid archive");
                throw e;
            }

            // handle KRCDiags
            if (this.fileName.Split('_')[0] == "KRCDiag") // if the filename starts with KRCDiag
            {
                Console.WriteLine("File Loaded: KRCDiag");
                thisArchiveType = archiveTypes.krc_diag;

                // split up the filename
                string[] splitFileName = this.fileName.Split('_');
                int lengthOfSplitString = splitFileName.Length;

                // set this.archiveDate to format YYYY-MM-DD_hh-mm-ss
                this.archiveDate = splitFileName[lengthOfSplitString - 3].Split('T')[0] + "_" // date
                    + splitFileName[lengthOfSplitString - 3].Split('T')[1] + "-"             // hours
                    + splitFileName[lengthOfSplitString - 2] + "-"                           // minutes
                    + splitFileName[lengthOfSplitString - 1].Split('.')[0];                       // seconds

                // set this.robName
                this.robName += splitFileName[1];
                for (int i = 2; i < lengthOfSplitString - 3; i++)
                {
                    this.robName += "_" + splitFileName[i];
                }

                // set this.iRSerialNr, this is stored as a $KR_SERIALNO in KRCDiag.log
                using (ZipArchive zip = ZipFile.OpenRead(pathToArchive))
                {
                    // open am.ini file and grab the goodies
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        // Handle standard KRC archives
                        if (entry.Name == "KRCDiag.log")
                        {
                            using (var stream = entry.Open())
                            using (var reader = new StreamReader(stream))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    string[] tokens = line.Split(' ');
                                    if (tokens.Length > 1)
                                    {
                                        if (tokens[1] == "$KR_SERIALNO")
                                        {
                                            this.iRSerialNr = tokens[2];
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
            }

        }

        public string getPathToArchive()
        {
            return pathToArchive;
        }

        private bool createNewArchiveDirectory()
        {
            return true;
        }

        private string getNewArchiveDirectoryName()
        {
            return null;
        }


    }
}
