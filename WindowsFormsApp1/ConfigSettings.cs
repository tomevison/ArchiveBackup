using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp1
{

    class ConfigSettings
    {
        private XDocument xmlFile;

        public ConfigSettings()
        {
            
        }

        public String GetRootCustomerDirPath()
        {
            xmlFile = XDocument.Load(@"./ArchiveBackup.Config.xml");
            var query = from c in xmlFile.Root.Descendants("Configuration") select c.Element("RootCustomerDirPath").Value;
            xmlFile.Save(@"./ArchiveBackup.Config.xml");
            return query.First();
        }

        public Boolean setRootCustomerDirPath(String newDir)
        {
            xmlFile = XDocument.Load(@"./ArchiveBackup.Config.xml");
            var existing = xmlFile.Descendants("Configuration").FirstOrDefault();
            existing.Element("RootCustomerDirPath").Value = newDir;
            xmlFile.Save(@"./ArchiveBackup.Config.xml");
            return true;
        }

        public String GetCustomerStoragePath()
        {
            xmlFile = XDocument.Load(@"./ArchiveBackup.Config.xml");
            var query = from c in xmlFile.Root.Descendants("Configuration") select c.Element("CustomerStoragePath").Value;
            xmlFile.Save(@"./ArchiveBackup.Config.xml");
            return query.First();
        }

        public Boolean SetCustomerStoragePath(String newDir)
        {
            xmlFile = XDocument.Load(@"./ArchiveBackup.Config.xml");
            var existing = xmlFile.Descendants("Configuration").FirstOrDefault();
            existing.Element("CustomerStoragePath").Value = newDir;
            xmlFile.Save(@"./ArchiveBackup.Config.xml");
            return true;
        }
    }
}
