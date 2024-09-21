using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.PortableExecutable;

namespace ThreadAssignment
{
    public class FileOperations
    {
        public string inputFolderpath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\FileRepo";
        public string outputFolderpath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\OutputFileRepo\";
        public void ReadAllFilesNamesFromPath()
        {            
            string[] files = Directory.GetFiles(inputFolderpath);

            foreach (string file in files)
            {
                if (file.EndsWith(".ini")) continue; else ReadFileFromPath(file);
            }
        }
        public void ReadFileFromPath(string inputfilepath)
        {
            string filedata;
            char appendChar = '$';

            //var filestream = new System.IO.FileStream(filepath,System.IO.FileMode.Open, System.IO.FileAccess.Read);                                          
            //var file = new System.IO.StreamReader(filestream, System.Text.Encoding.UTF8, true, 128);
            //while ((filedata = file.ReadLine()) != null)
            //{}

            // Read all text from the input file
            filedata = File.ReadAllText(inputfilepath);

            // Split the text into words
            string[] words = filedata.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Append the character to each word
            for (int i = 0; i < words.Length; i++)
            {
                words[i] += appendChar;
            }
            // Join the words back into a single string
            string modifiedText = string.Join(" ", words);
            //Console.WriteLine(modifiedText);
            WriteToFile(modifiedText, inputfilepath);

        }
        public void WriteToFile(string newFileData,string inputfilepath)
        {
            if (!Directory.Exists(outputFolderpath))
            {
                Directory.CreateDirectory(outputFolderpath);
            }
           string fileName = Path.GetFileName(inputfilepath);           
           string outputFilepath = string.Concat(outputFolderpath, fileName);
           File.WriteAllText(outputFilepath, newFileData);
        }
    }
}
