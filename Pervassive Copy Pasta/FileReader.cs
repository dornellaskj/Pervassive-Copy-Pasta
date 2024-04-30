using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pervassive_Copy_Pasta
{
    public class FileReader
    {
        public void ReadFilesInFolder(string folderPath, string oldFolderPath, string newProcessName, string oldProcessName)
        {
            try
            {
                // Check if the directory exists
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Directory does not exist.");
                    return;
                }

                // Get all files in the folder
                string[] files = Directory.GetFiles(folderPath);

                if (files.Length == 0)
                {
                    Console.WriteLine("No files found in the directory.");
                    return;
                }

                // Iterate through each file and read its content
                foreach (string file in files)
                {
                    
                    if (file.Contains("Index_File.xml"))
                    {
                        Console.WriteLine($"updating: {file}");

                        //update author and last modified date
                        XmlEditor xmlEditor = new XmlEditor(file);

                        // Edit XML content
                        //xmlEditor.EditXml("//RECORD", "NewValue");
                        xmlEditor.EditXmlAttribute("//RECORD", "AUTHOR", Environment.UserName);
                        xmlEditor.EditXmlAttribute("//RECORD", "LASTMODIFIED", DateTime.Now.ToString());
                        xmlEditor.EditXmlReplaceAttribute("//RECORD", "DIRPATH", oldFolderPath, folderPath);
                        xmlEditor.EditXmlReplaceAttribute("//RECORD", "FILENAME", oldProcessName, newProcessName);


                        // Save changes
                        xmlEditor.SaveChanges();
                    }
                    if (file.Contains("tf.xml"))
                    {
                        Console.WriteLine($"updating: {file}");

                        //update author and last modified date
                        XmlEditor xmlEditor = new XmlEditor(file);

                        // Edit XML content
                        //xmlEditor.EditXml("//RECORD", "NewValue");
                        xmlEditor.EditXmlAttribute("//Transformation", "creator", Environment.UserName);
                        xmlEditor.EditXmlAttribute("//Transformation", "author", Environment.UserName);
                        xmlEditor.EditXmlAttribute("//Transformation", "datecreated", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                        xmlEditor.EditXmlAttribute("//Transformation", "datemodified", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                        xmlEditor.EditXmlReplaceAttribute("//Transformation/TransformationMap", "originallocation", oldFolderPath, folderPath);


                        // Save changes
                        xmlEditor.SaveChanges();
                    }
                    if (file.Contains("map.xml"))
                    {
                        Console.WriteLine($"updating: {file}");

                        //update author and last modified date
                        XmlEditor xmlEditor = new XmlEditor(file);

                        // Edit XML content
                        //xmlEditor.EditXml("//RECORD", "NewValue");
                        xmlEditor.EditXmlAttribute("//Map", "creator", Environment.UserName);
                        xmlEditor.EditXmlAttribute("//Map", "author", Environment.UserName);
                        xmlEditor.EditXmlAttribute("//Map", "datecreated", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                        xmlEditor.EditXmlAttribute("//Map", "datemodified", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                        xmlEditor.EditXmlReplaceAttribute("//Transformation/TransformationMap", "originallocation", oldFolderPath, folderPath);


                        // Save changes
                        xmlEditor.SaveChanges();
                    }
                    if (file.Contains("ip.xml"))
                    {
                        Console.WriteLine($"updating: {file}");

                        //update author and last modified date
                        XmlEditor xmlEditor = new XmlEditor(file);

                        // Edit XML content
                        //xmlEditor.EditXml("//RECORD", "NewValue");
                        xmlEditor.EditXmlAttribute("//Process", "creator", Environment.UserName);
                        xmlEditor.EditXmlAttribute("//Process", "author", Environment.UserName);
                        xmlEditor.EditXmlAttribute("//Process", "datecreated", DateTime.Now.ToString());
                        xmlEditor.EditXmlAttribute("//Process", "datemodified", DateTime.Now.ToString());
                        xmlEditor.EditXmlReplaceAttribute("//step", "location", oldFolderPath, folderPath);
                        //is main process?
                        if (file.Contains(newProcessName))
                        {
                            xmlEditor.EditXmlAttribute("//Process", "name", newProcessName);
                        }
                        // Save changes
                        xmlEditor.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
