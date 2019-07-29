using System;
using System.IO;
using System.IO.Compression;

namespace WindowsFormsApp1
{
    class ArchiveHandler
    {

        private String archiveDate;
        private String RobName;
        private String IRSerialNr;
        private String pathToArchive;

        public string ArchiveDate { get => archiveDate; set => archiveDate = value; }

        public ArchiveHandler(String pathToArchive)
        {
            this.pathToArchive = pathToArchive;
            using (ZipArchive zip = ZipFile.OpenRead(pathToArchive))
            {
                // open am.ini file and grab the goodies
                foreach (ZipArchiveEntry entry in zip.Entries)
                    if (entry.Name == "am.ini")
                    {
                        using (var stream = entry.Open())
                        using (var reader = new StreamReader(stream))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                String[] tokens = line.Split('=');
                                // Process line, e.g.:
                                if (tokens[0] == "RobName") RobName = tokens[1];
                                if (tokens[0] == "Date") ArchiveDate = tokens[1];
                                if (tokens[0] == "IRSerialNr") IRSerialNr = tokens[1];
                            }
                        }                                                 
                    }
            }
        }

        public String GetRobName()
        {
            return this.RobName;
        }

        public String getPathToArchive()
        {
            return this.pathToArchive;
        }

        public String GetIRSerialNr()
        {
            return IRSerialNr;
        }

        public String getArchiveDate()
        {
            return this.archiveDate;
        }

        private Boolean createNewArchiveDirectory()
        {
            return true;
        }

        private String getNewArchiveDirectoryName()
        {
            return null;
        }

        
    }
}
