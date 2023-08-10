using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8_6_1
{
    static class DirectoryRemover
    {
        public static void Cleanup(string dirName) 
        {
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (dir.Exists)
            {
                try
                {
                    var files = dir.GetFiles();
                    foreach (var file in files)
                    {
                        file.Delete();
                    }
                    foreach (var di in dir.GetDirectories())
                    {
                        di.Delete(true);
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Ошибка: {ex}");
                }
                Console.WriteLine($"Все содержимое каталога {dirName} удалено");
            }
            else
                Console.WriteLine("Каталога не существует");
        }
        
    }
}
