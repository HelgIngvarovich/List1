using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Serialize.Logic.Entity
{
    public class BinSerialize
    {
        public void Serialize(Repository rep, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, rep);
            }
            Console.WriteLine("--> Сохранение объекта в Binary format");
        }

        public Repository DeSerialize(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            Repository savedRep;
            using (Stream fStream = File.OpenRead(fileName))
            {
                savedRep = (Repository)binFormat.Deserialize(fStream);
            }
            return savedRep;
        }
    }
}
