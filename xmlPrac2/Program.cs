using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xmlPrac2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Phone obj = new Phone("a10s", "Samsung", 4000, new DateTime(2020,10, 12));
            Add(obj);
            Print("phone.xml");
            Console.Read();
        }
        public static void Add(Phone obj)
        {
            XDocument doc = XDocument.Load("phone.xml");
            XElement root = doc.Root;
            if(root != null )
            {
                root.Add(new XElement("phone", new XAttribute("name", obj.Name), new XElement("producer", obj.Producer),new XElement("price", obj.Price.ToString())));
            }
            doc.Save("phone.xml");
        }
        public void Delete(string name, string path)
        {
            XDocument doc = XDocument.Load (path);
            XElement root = doc.Element("item");
            if(root != null)
            {
                var phone = root.Elements("phone").FirstOrDefault(obj => obj.Element("name")?.Value == name);
                if(phone != null)
                {
                    phone.Remove();
                    doc.Save (path);
                }
            }

        }
        public static Phone Search(string name, string path)
        {
            Phone res = new Phone();
            XDocument doc = XDocument.Load (path);
            var phone = doc.Element("item").Elements("phone").FirstOrDefault(obj => obj.Attribute("name")?.Value == name);
            if(phone != null)
            {
                res.Producer = phone.Element("producer")?.Value;
                res.Price = Convert.ToInt32(phone.Element("price")?.Value);
                res.Name = phone.Element("name")?.Value;
                return res;
            }
            return null;
        }
        public static void Edit(string name, string newName, string path)
        {
            XDocument doc = XDocument.Load (path);
            var phone = doc.Element("item")?.Elements("phone").FirstOrDefault(obj => obj.Attribute(name)?.Value == name);
            if(phone != null)
            {
                var temp = phone.Attribute("name");
                if(temp != null) { temp.Value = newName; }
                doc.Save (path);
            }
        }
        public static void Print(string path)
        {
            XDocument doc = XDocument.Load (path);
            Console.WriteLine(doc);
        }
    }
}
