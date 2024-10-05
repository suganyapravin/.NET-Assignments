using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ThreadAssignment
{
    public class FileOperatiosUsingTasks
    {
        public string inputFolderpath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\FileRepo";

        public string outputFolderpath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\OutputFileRepo\";
        public string[] fileslist;
        public string file="";
        public string processeddata="";
        public void ReadAllFilesNamesFromPath()
        {
            fileslist = Directory.GetFiles(inputFolderpath);

            foreach (string file in fileslist)
            {
                if (file.EndsWith(".ini")) continue; 
                else
                {
                    //ReadFileFromPath();
                    Task task1 = new Task(() => {
                        ReadFileFromPath(file);
                    });
                    task1.Start();
                }
            }
        }
        public void ReadFileFromPath(string file)
        {
            string filedata;
            char appendChar = '$';

            // Read all text from the input file
            if (file != null && file !="")
            {
                filedata = File.ReadAllText(file);

                // Split the text into words
                string[] words = filedata.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                // Append the character to each word
                for (int i = 0; i < words.Length; i++)
                {
                    words[i] += appendChar;
                }
                // Join the words back into a single string
                processeddata = string.Join(" ", words);

                //Console.WriteLine(modifiedText);
                WriteToFile(processeddata, file);
             
                //Task task2 = new Task(() => {
                //    WriteToFile(processeddata,file);
                //});
                //task2.Start();

            }
      
        }
        public void WriteToFile(string processeddata,string file)
        {
            if (!Directory.Exists(outputFolderpath))
            {
                Directory.CreateDirectory(outputFolderpath);
            }
            if (file != "" && file != null)
            {
                string fileName = Path.GetFileName(file);
                string outputFilepath = string.Concat(outputFolderpath, fileName);
                File.WriteAllText(outputFilepath, processeddata);
            }
        }
       

    }
}
