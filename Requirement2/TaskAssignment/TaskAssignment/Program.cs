using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using TaskAssignment;

namespace ThreadAssignment
{
    public class Program
    {
        public static System.Timers.Timer timer;
        static void Main(string[] args)
        {
            ProcessCreateFiles wps = new ProcessCreateFiles();
            // Initialize the timer
            timer = new System.Timers.Timer(10000); // 60,000 milliseconds = 1 minute
            timer.Elapsed += wps.WriteInputfileToDisk;
            timer.AutoReset = true;
            timer.Enabled = true;


            timer = new System.Timers.Timer(100000); // 60,000 milliseconds = 1 minute
            timer.Elapsed += wps.CallProcessAndWriteOutputFiles;
            timer.AutoReset = true;
            timer.Enabled = true;
      
            // Task task = Task.Run(() => wps.ProcessAndWriteOutputFiles());
           // wps.ProcessAndWriteOutputFiles();

            Console.WriteLine("Press [Enter] to exit the program.");
            Console.ReadLine();

        }      

    }
}