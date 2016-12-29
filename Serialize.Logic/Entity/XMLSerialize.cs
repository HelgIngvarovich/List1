using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serialize.Logic.Entity
{
    public class XMLSerialize
    {
        public void SaveInXmlFormat(Repository objGraph, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Repository), new Type[] { typeof(People) });
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("--> Сохранение объекта в XML-формат");
        }

        public Repository DeserializeObject(string filename)
        {
            Console.WriteLine("Reading with XmlReader");

            // Create an instance of the XmlSerializer specifying type and namespace.
            XmlSerializer serializer = new
            XmlSerializer(typeof(Repository), new Type[] { typeof(People) });

            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);

            // Declare an object variable of the type to be deserialized.
            Repository i;

            // Use the Deserialize method to restore the object's state.
            i = (Repository)serializer.Deserialize(reader);
            fs.Close();
            return i;
        }


    }
}
