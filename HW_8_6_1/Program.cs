using System;
using System.IO;


namespace HW_8_6_1;
class Program
{
    public static void Main(string[]  args)
    {
        Console.WriteLine("Введите путь к каталогу");
        string path = Console.ReadLine();
        DirectoryRemover.Cleanup(path);

    }
}