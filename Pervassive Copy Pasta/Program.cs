using Pervassive_Copy_Pasta;

class Program
{
    static void Main(string[] args)
    {
        string sourceFolderPath = GetFolderPath("Please enter the source folder path (ex: C:\\TDUSBC_CloseReturn_Report_Agency)");
        string destinationFolderPath = GetFolderPath("Please enter the destination folder path (ex: C:\\TDUSBC_CloseReturn_Report_Agency)");
        string oldProcessName = GetName("Please enter the old main process name (ex: old.ip.xml)");
        string newProcessName = GetName("Please enter the new process name (ex: new.ip.xml)");
        if (sourceFolderPath != destinationFolderPath)
        {
            FolderCopier folderCopier = new FolderCopier();
            folderCopier.CopyFiles(sourceFolderPath, destinationFolderPath, newProcessName, oldProcessName);
            Console.WriteLine("Files successfully copied to: " + destinationFolderPath);
            Console.WriteLine("Updating files in: " + destinationFolderPath);
            FileReader fileReader = new FileReader();
            fileReader.ReadFilesInFolder(destinationFolderPath, sourceFolderPath, newProcessName, oldProcessName);


            Console.WriteLine("Thanks for using the application. Press enter to exit.");
            Console.ReadLine().Trim();
        }
    }
    public static string GetFolderPath(string prompt)
    {
        string folderPath;
        do
        {
            Console.WriteLine(prompt);
            folderPath = Console.ReadLine().Trim();

            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder does not exist. Please enter a valid folder path.");
            }

        } while (!Directory.Exists(folderPath));

        return folderPath;
    }

    public static string GetName(string prompt)
    {
        string val;
        Console.WriteLine(prompt);
        val = Console.ReadLine().Trim(); 
        return val;
    }

}




