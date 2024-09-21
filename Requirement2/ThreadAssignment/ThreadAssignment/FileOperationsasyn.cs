using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ThreadAssignment
{
    public class FileOperationsasyn
    {

        public async void ReadFile()
      
         {
             string inputFolderpath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\FileRepo\";

             string outputFolderpath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\OutputFileRepo\";
             string[] fileslist;

             fileslist = Directory.GetFiles(inputFolderpath);

            foreach (string file in fileslist)
            {
                if (file.EndsWith(".ini")) continue;
                else
                {
                    string fileName = Path.GetFileName(file);
                    string inputFilepath = string.Concat(inputFolderpath, fileName);
                    string content = await File.ReadAllTextAsync(inputFilepath);

                    // Process the content using a task
                    string processedContent = await Task.Run(() => ProcessContent(content));
                    Console.WriteLine("File processed successfully.");

                    string outputFilepath = string.Concat(outputFolderpath, fileName);

                    // Write the processed content back to a file asynchronously
                    await File.WriteAllTextAsync(outputFilepath, processedContent);
                    Console.WriteLine("Processed file written successfully.");
                }                
            }                   
               
          }

        
        public string ProcessContent(string content)
        {
            // Example processing: convert content to uppercase
            return content.ToUpper();
        }
    }
}
