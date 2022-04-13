using System;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var test = new List<Number>() 
            {   new Number(1), 
                new Number(2), 
                new Number(3), 
                new Number(4) };

            Console.WriteLine($"Max value: {test.GetMax(item => item.Value)}");*/

            var manager = new FileManager(@"G:\TestProgram");
            manager.FileFound += Manager_FileFound;

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
