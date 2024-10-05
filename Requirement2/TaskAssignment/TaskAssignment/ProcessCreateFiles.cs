using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TaskAssignment
{
    public class ProcessCreateFiles
    {
          
        static async Task<string> CreateContent()
        {
            string filePath = @"C:\DOTNET\notes.txt";

            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                char[] buffer = new char[1024];
                int numRead;
                StringBuilder result = new StringBuilder();
                int randomindex = new Random().Next(500);

                if ((numRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    result.Append(buffer, 0, randomindex);
                }

                string fileContent = result.ToString();
               return fileContent;
            }
        }
        public  async void WriteInputfileToDisk(Object source, ElapsedEventArgs e)
        {
            string directoryPath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\FileRepo\";
            string fileName = $"File_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            // Ensure the directory exists
            Directory.CreateDirectory(directoryPath);

            var content = await CreateContent();

            // Create a new file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
               await writer.WriteLineAsync(content.ToString());
            }
            
        }
        public async void CallProcessAndWriteOutputFiles(Object source, ElapsedEventArgs e)
        {
            await ProcessAndWriteOutputFiles();
        }
        public async Task ProcessAndWriteOutputFiles()
        {
            try
            {
                StringBuilder result = new StringBuilder();
                string inputFolderPath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\FileRepo\";
                string outputFolderPath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\OutputFileRepo\";            
                                            
                while (Directory.GetFiles(inputFolderPath, "*").Any())      
                {
                    //get 4 files from input folder based on time and append into 1 file

                    var files = Directory.GetFiles(inputFolderPath, "*").OrderBy(d => new FileInfo(d).CreationTime).Take(3);
                    Parallel.ForEach(files, i =>
                    {
                        string content = ReadFileAsync(i).Result;
                        result.Append(content);
                        File.Delete(i);
                        Thread.Sleep(10000);
                    });

                    //foreach(var file in files)
                    //{
                    //    string content = await ReadFileAsync(file);
                    //    result.Append(content);
                    //    File.Delete(file);
                    //}
                    string outfileName = $"OutFile_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                    //name of the output file path 
                    string filePath = Path.Combine(outputFolderPath, outfileName);

                    // Ensure the directory exists
                    Directory.CreateDirectory(outputFolderPath);
                  
                    // Create a new file
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        await writer.WriteLineAsync(result.ToString());
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        public async Task<string> ProcessInputfiles()
        {
            StringBuilder result = new StringBuilder();
            string directoryPath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\FileRepo\";
           
            var randomFiles = GetRandomFiles(directoryPath, 4); // Get 4 random files

            foreach (var file in randomFiles)
            {
                string content = await ReadFileAsync(file);
                result.Append(content);               
               // Console.WriteLine($"Content of {file}:\n{content}\n");
               File.Delete(file);
            }
            return result.ToString();
        }

        static string[] GetRandomFiles(string folderPath, int count)
        {
            var files = Directory.GetFiles(folderPath, "*").OrderBy(d => new FileInfo(d).CreationTime).Take(count);
           // return files.OrderBy(x => Guid.NewGuid()).Take(count).ToArray();
             return files.ToArray();           
        }

        static async Task<string> ReadFileAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async void WriteProcessedFile(string content)
        {
            string directoryPath = @"C:\Users\sugan\source\.NET\.NET-Assignments\Requirement2\OutputFileRepo\";
            string fileName = $"OutFile_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(directoryPath, fileName);

            // Ensure the directory exists
            Directory.CreateDirectory(directoryPath);
          //  var content = await CreateContent();

            // Create a new file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteLineAsync(content.ToString());
            }
        }

        public async Task<string> CreateContent2()
        {
            string filePath = @"C:\DOTNET\notes.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                return await reader.ReadLineAsync();
            }
        }

    }
}
