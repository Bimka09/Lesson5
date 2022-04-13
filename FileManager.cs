using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson5
{
    public class FileManager
    {
        public event EventHandler FileFound;

        private DirectoryInfo _dirManager;

        List<string> existsFiles = new List<string>();

        public FileManager(string path)
        {
            _dirManager = new DirectoryInfo(path);
        }

        public void Start()
        {
            do
            {
                var files = _dirManager.GetFiles();

                foreach (var file in files)
                {
                    if(existsFiles.Contains(file.FullName) == false)
                    {
                        existsFiles.Add(file.FullName);
                        var fileArgs = new FileEventArgs();
                        fileArgs.FileName = file.FullName;
                        FileFound?.Invoke(this, fileArgs);
                    }
                }

            } while (true);
            
        }

        public void Stop()
        {
            Console.WriteLine("Нажмите клавишу для остановки программы");
            Console.ReadKey();
            Delegate[] subs = FileFound.GetInvocationList();
            FileFound = null;
        }
    }
}
