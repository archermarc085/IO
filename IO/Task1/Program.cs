using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Folder_";
            int count = 0;

            List<DirectoryInfo> Folder = new List<DirectoryInfo>();

            for (; count < 100; count++)
            {
                Folder.Add(Directory.CreateDirectory(path + count));
            }
            Console.WriteLine("The directories was created successfully.");

            foreach (DirectoryInfo dir in Folder)
            {
                dir.Delete();
            }
            Console.WriteLine("The directories was deleted successfully.");
            Console.ReadLine();
        }
    }
}
