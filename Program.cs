using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new List<int>()
            {   1,
                2,
                3,
                4 };
            Console.WriteLine($"Max value: {test.GetMax(item => new Number(item.Value))}");

            var manager = new FileManager(@"G:\TestProgram");
            manager.FileFoundEventHandler += Manager_FileFound;

           var task = new Task(() =>
            {
                manager.Start();
            });
            task.Start();
            var task2 = new Task(() =>
            {
                manager.Stop();
            });
            task2.Start();
            task2.Wait();

        }

        private static void Manager_FileFound(object sender, EventArgs e)
        {
            Console.WriteLine(((FileEventArgs)e).FileName); 
        }
    }
}
