using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(callMethod);
            task.Start();
            task.Wait();
            Console.ReadLine();
        }

        private static async void callMethod()
        {
            string filePath = "D:\\loremipsum.txt";
            Task<int> task = ReadFile(filePath);

            Console.WriteLine("Other Work 1");
            Console.WriteLine("Other Work 2");
            Console.WriteLine("Other Work 3");

            int length = await task;

            Console.WriteLine("Total lenght: " + length);
            Console.WriteLine("After Work 1");
            Console.WriteLine("After Work 2");
        }

        private static async Task<int> ReadFile(string filePath)
        {
            int length = 0;
            Console.WriteLine("File reading is starting");
            using( StreamReader reader = new StreamReader(filePath))
            {
                string s = await reader.ReadToEndAsync();
                length = s.Length;
            }
            Console.WriteLine("File reading is completed");
            return length;
        }
    }
}
