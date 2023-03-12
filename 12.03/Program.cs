using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace _12._03hm
{
    internal class Program
    {
        static void AddElement(XmlTextWriter xmlwriter)
        {
            Console.Write("Enter product: ");
            string product = Console.ReadLine();
            Console.Write("Enter price: ");
            string price = Console.ReadLine();

            xmlwriter.WriteStartAttribute("name");
            xmlwriter.WriteString(product);
            xmlwriter.WriteEndAttribute();

            xmlwriter.WriteStartAttribute("price");
            xmlwriter.WriteString(price);
            xmlwriter.WriteEndAttribute();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter place fale");
            string l = Console.ReadLine();
            string link = "...../...../" + l;
            XmlTextWriter xmlwriter = new XmlTextWriter(link, Encoding.UTF8);
            xmlwriter.WriteStartElement("order");
            xmlwriter.WriteComment("12.03.2023");
            xmlwriter.WriteStartElement("Items");
            AddElement(xmlwriter);
            xmlwriter.WriteEndElement();
            xmlwriter.WriteEndElement();
            Console.WriteLine("Base save in XML-file");
            xmlwriter.Close();
            XmlTextReader reader = new XmlTextReader(link);
            string str = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    str += reader.Value + "\n";
                }

                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            str += reader.Value + "\n";
                        }
                    }
                }
            }
            Console.WriteLine(str);
            reader.Close();
        }
    }
}
