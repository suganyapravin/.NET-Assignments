using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThreadAssignment
{
    internal class Program
    {

        static void Main(string[] args)
        {
           FileOperationsasyn asynfileops = new FileOperationsasyn();
           asynfileops.ReadFile();

           FileOperatiosUsingTasks tsk = new FileOperatiosUsingTasks();
            tsk.ReadAllFilesNamesFromPath();

            //FileOperations fileOperations = new FileOperations();
            //fileOperations.ReadAllFilesNamesFromPath();
            Console.WriteLine("Job Done");
            Console.ReadLine();
        }

    }
}