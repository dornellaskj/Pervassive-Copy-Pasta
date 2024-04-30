using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pervassive_Copy_Pasta
{
    public class FolderCopier
    {
        public void CopyFiles(string sourceFolderPath, string destinationFolderPath, string newProcessName, string oldProcessName)
        {
            try
            {
                // Check if the source directory exists
                if (!Directory.Exists(sourceFolderPath))
                {
                    Console.WriteLine("Source directory does not exist.");
                    return;
                }

                // Check if the destination directory exists, if not, create it
                if (!Directory.Exists(destinationFolderPath))
                {
                    Directory.CreateDirectory(destinationFolderPath);
                }

                // Get all files in the source directory
                string[] files = Directory.GetFiles(sourceFolderPath);

                // Copy each file to the destination directory
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationFilePath = Path.Combine(destinationFolderPath, fileName);
                    if(fileName.Contains(oldProcessName)) {
                        destinationFilePath = Path.Combine(destinationFolderPath, newProcessName);
                    }
                    File.Copy(file, destinationFilePath, true);
                    Console.WriteLine($"File '{fileName}' copied successfully.");
                }

                Console.WriteLine("All files copied successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
