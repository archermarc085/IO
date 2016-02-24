using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "Log.txt";
            DirectoryInfo directory = new DirectoryInfo(@"D:\");

            FileInfo file = new FileInfo(fileName);
            SearchFileInCurrentDirectory(fileName);
            RecursionSearch(directory, fileName);

            string str = File.ReadAllText(fileName);
            CompressStringToFile(fileName, str);
            Console.ReadLine();
        }


        static void RecursionSearch(DirectoryInfo directory, string fileName)
        {
            DirectoryInfo[] directories = null;
            FileInfo[] files = directory.GetFiles(fileName);
            foreach (var item in files)
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] array = File.ReadAllBytes(fileName);
                    fileStream.Read(array, 0, array.Length);
                }
                Console.WriteLine(item.FullName);
            }
            try
            {
                directories = directory.GetDirectories();
                foreach (var item in directories)
                {
                    RecursionSearch(item, fileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void SearchFileInCurrentDirectory(string fileName)
        {
            string currentDirName = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(currentDirName, fileName);

            foreach (string s in files)
            {
                FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(s);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("{0} : {1}", fi.Name, fi.Directory);
            }
        }

        public static void CompressStringToFile(string fileName, string value)
        {
            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, value);
            byte[] b;
            using (FileStream f = new FileStream(temp, FileMode.Open))
            {
                b = new byte[f.Length];
                f.Read(b, 0, (int)f.Length);
            }

            using (FileStream f2 = new FileStream(fileName, FileMode.Create))
            using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
            {
                gz.Write(b, 0, b.Length);
            }
        }
    }
}
