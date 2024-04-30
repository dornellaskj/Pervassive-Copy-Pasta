using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Pervassive_Copy_Pasta
{
    internal class XmlEditor
    {
        private string filePath;
        private XmlDocument xmlDoc;

        public XmlEditor(string filePath)
        {
            this.filePath = filePath;
            LoadXmlFile();
        }

        private void LoadXmlFile()
        {
            try
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading XML file: {ex.Message}");
            }
        }

        public void EditXml(string xpath, string newValue)
        {
            try
            {
                XmlNode node = xmlDoc.SelectSingleNode(xpath);
                if (node != null)
                {
                    node.InnerText = newValue;
                }
                else
                {
                    Console.WriteLine("Node not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while editing XML: {ex.Message}");
            }
        }

        public void EditXmlAttribute(string xpath, string attribute, string newValue)
        {
            try
            {
                XmlNodeList recordNodes = xmlDoc.SelectNodes(xpath);
                if (recordNodes.Count > 0)
                {
                    foreach (XmlNode recordNode in recordNodes)
                    {
                        XmlAttribute Attribute = recordNode.Attributes[attribute];
                        if (Attribute != null)
                        {
                            Attribute.Value = newValue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Node not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while editing XML: {ex.Message}");
            }
        }

        public void EditXmlReplaceAttribute(string xpath, string attribute, string oldValue, string newValue)
        {
            try
            {
                XmlNodeList recordNodes = xmlDoc.SelectNodes(xpath);
                if (recordNodes.Count > 0)
                {
                    foreach (XmlNode recordNode in recordNodes)
                    {
                        XmlAttribute Attribute = recordNode.Attributes[attribute];
                        if (Attribute != null)
                        {
                            string clean_oldValue = oldValue.Replace(@"\", "/");
                            string clean_newValue = newValue.Replace(@"\", "/");
                            string currentvalue = Attribute.Value;
                            Attribute.Value = currentvalue.Replace(clean_oldValue, clean_newValue);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Node not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while editing XML: {ex.Message}");
            }
        }        

        public void SaveChanges()
        {
            try
            {
                xmlDoc.Save(filePath);
                Console.WriteLine("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving changes: {ex.Message}");
            }
        }
    }
}
