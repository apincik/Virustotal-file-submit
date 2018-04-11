using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PVBPS_Project
{
    class Directory
    {
        private string path;
        private List<string> files = new List<string>();

        public Directory(string directoryPath)
        {
            this.path = directoryPath;
        }

        public List<string> GetFiles()
        {
            files.Clear();
            this.SearchDirectory(this.path);

            return this.files;
        }

        private void SearchDirectory(string dir)
        {
            try
            {
                foreach (string f in System.IO.Directory.GetFiles(dir))
                {
                    this.files.Add(f);
                }

                foreach (string d in System.IO.Directory.GetDirectories(dir))
                {
                    SearchDirectory(d);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception during listing directory... {0}", ex.Message);
            }
        }
    }
}
