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
                        if (AccsessTime(file))
                            file.Delete();
                    }
                    foreach (var di in dir.GetDirectories())
                    {
                        if (AccsessTime(di))
                            di.Delete(true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}");
                }
            }
            else
                Console.WriteLine("Каталога не существует");
        }
        public static bool AccsessTime(FileInfo fi)
        {
            bool old;
            DateTime time1 = DateTime.Now;
            DateTime time2 = fi.LastAccessTime;
            TimeSpan timeInterval = TimeSpan.FromMinutes(1);
            TimeSpan dif = time1.Subtract(time2);
            if (dif > timeInterval)
                old = true;
            else
                old = false;
            return old;
        }
        public static bool AccsessTime(DirectoryInfo d)
        {
            bool old;
            DateTime time1 = DateTime.Now;
            DateTime time2 = d.LastAccessTime;
            TimeSpan timeInterval = TimeSpan.FromMinutes(1);
            TimeSpan dif = time1.Subtract(time2);
            if (dif.Minutes > timeInterval.Minutes)
                old = true;
            else
                old = false;
            return old;
        }
    }
}
