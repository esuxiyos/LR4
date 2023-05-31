using System;
using System.IO;
using System.Threading.Tasks;

namespace LR4
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            if (args.Length < 1)
            {
                Console.WriteLine("Використання: LR4.exe \"шлях до каталогу\"");
                return 1;
            }

            string folder = args[0];

            if (!Directory.Exists(folder))
            {
                Console.WriteLine($"Каталогу '{folder}' не існує.");
                return 1;
            }

            Console.WriteLine($"Вміст каталогу {folder}:");
            long totalSize = 0;
            Folders(folder, ref totalSize);

            Console.WriteLine();
            Console.WriteLine($"Обсяг файлів у каталозі {folder}:");
            Console.WriteLine($"{totalSize} байт");
            return 0;
        }

        static void Folders(string folder, ref long totalSize)
        {
            string[] files = Directory.GetFiles(folder);
            string[] subdirectories = Directory.GetDirectories(folder);

            foreach (string file in files)
            {
                Console.WriteLine(file);
                FileInfo fileInfo = new FileInfo(file);
                totalSize += fileInfo.Length;
            }

            foreach (string subdirectory in subdirectories)
            {
                Console.WriteLine(subdirectory);
                Folders(subdirectory, ref totalSize);
            }
        }
    }
}
