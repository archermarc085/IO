using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "file.txt";
            if (File.Exists(path))
            {
                Console.WriteLine("File exists!");
                using (StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    writer.WriteLine("N");
                    writer.WriteLine("E");
                    writer.WriteLine("W");
                }
            }
            else
            {
                Console.WriteLine("Create new file");
                using (StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    writer.WriteLine("A");
                    writer.WriteLine("P");
                    writer.WriteLine("P");
                    writer.WriteLine("L");
                    writer.WriteLine("E");
                }
            }

            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.ReadLine();
        }
    }
}
