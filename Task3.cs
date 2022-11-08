using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Task3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки, которая будет очищена от файлов и папок, которые не использовались более 30 минут");
            DirectoryInfo path = new DirectoryInfo(Console.ReadLine());            

            TimeSpan data = DateTime.Now - path.LastWriteTime;
            int a = 30;
            
            try
            {
                if (path.Exists && data > TimeSpan.FromMinutes(a))
                {
                    Console.WriteLine("Папка существует");
                    Console.WriteLine("Дата последнего изменения папки " + data);
                    
                    Console.WriteLine("Так как последний раз папка изменялась более полу часа назад, то все файлы будут удалены");
                    Console.WriteLine($"Исходный размер папки {SizeDerectory(path)} байт");
                    Console.WriteLine($"Удалено {SizeDerectory(path)} байт");
                    foreach (var file in path.GetFiles())
                    {
                        file.Delete();
                    }
                    Console.WriteLine($"Псоле удаления папка весит {SizeDerectory(path)} байт");
                }
                if (!path.Exists)
                {
                    Console.WriteLine("Указан неверный путь");
                }
                if (data <= TimeSpan.FromMinutes(a))
                {
                    Console.WriteLine("Указанная директория не удалена, так как существует менее 30 минут");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Во время работы программы произошла ошибка " + e.Message);
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
            return size;
        }
    }
}
