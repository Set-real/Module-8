using System;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class Test
{
    public static void Main()
    {
        Console.WriteLine("Введите путь к каталогу");
        DirectoryInfo Directory = new DirectoryInfo(Console.ReadLine());
        try
        {
            Console.WriteLine(SizeDerectory(Directory));
        }
        catch (Exception e)
        {

            Console.WriteLine($"Ошибка {e}");
        }
    }
    public static long SizeDerectory(DirectoryInfo directory)
    {
        FileInfo[] fs = directory.GetFiles();
        long size = 0;
        foreach (var с in fs)
        {
            size += fs.Length;
        }

        DirectoryInfo[] directoryInfo = directory.GetDirectories();
        foreach (var item in directoryInfo)
        {
            size += SizeDerectory(item);
        }
        return size;
    }
}
