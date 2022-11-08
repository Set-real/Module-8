using System;
using System.Data;
using System.IO;
using System.Text;

class Test
{
    public static void Main()
    {
        Console.WriteLine("Введите путь до папки, которая будет очищена от файлов и папок, которые не использовались более 30 минут");
        DirectoryInfo path = new DirectoryInfo(Console.ReadLine());

        TimeSpan data = DateTime.Now - path.LastWriteTime;
        int a = 30;
        Console.WriteLine(data);
        try
        {
            if (path.Exists && data > TimeSpan.FromMinutes(a))
            {
                Console.WriteLine("Директория существует");
                path.Delete(true);
                Console.WriteLine("Указанная директория удалена");
            }
           
            if (!path.Exists)
            {
                Console.WriteLine("Указан неверный путь");
            }
            if (data <= TimeSpan.FromMinutes(a))
            {
                Console.WriteLine("Указанная директория не удалена");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Во время работы программы произошла ошибка " + e.Message);
        }
    }   
}