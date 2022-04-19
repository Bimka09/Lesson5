using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Lesson5
{
    public class FileManager
    {
        public event EventHandler FileFoundEventHandler;

        private DirectoryInfo _dirManager;

        List<string> existsFiles = new List<string>();
        private static bool _killAccepted;
        private static bool _pause;

        public FileManager(string path)
        {
            _dirManager = new DirectoryInfo(path);
        }

        public void Start()
        {
            do
            {
                var files = _dirManager.GetFiles();
                if(_pause == false)
                {
                    foreach (var file in files)
                    {
                        if (existsFiles.Contains(file.FullName) == false)
                        {
                            existsFiles.Add(file.FullName);
                            var fileArgs = new FileEventArgs();
                            fileArgs.FileName = file.FullName;
                            FileFoundEventHandler?.Invoke(this, fileArgs);
                        }
                    }
                }

            } while (true);
            
        }

        public void Stop()
        {
            Console.WriteLine("Нажмите клавишу для остановки программы");
            
            do
            {
                _pause = false;
                Console.ReadKey();
                _pause = true;
                Console.WriteLine("Подтвердите остановку программы в течение 5 секунд");
                Thread th = new Thread(ReadConsole);
                th.Start();
                Thread.Sleep(5000);
                if (_killAccepted)
                {
                    Kill();
                }
                else
                {
                    th.Interrupt();
                    Console.WriteLine("Время на подтверждение остановки истекло. Повторите действия");
                }

            } while (_killAccepted == false);


        }

        private static void ReadConsole()
        {
            _killAccepted = false;
            Console.ReadKey();
            _killAccepted = true;
        }

        private void Kill()
        {
            FileFoundEventHandler = null;
        }
    }
}
