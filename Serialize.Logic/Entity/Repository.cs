using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialize.Logic.Entity
{
    [Serializable]
    [XmlRoot]
    public class Repository
    {
        List<People> peopleList = new List<People>()
        {
            new People("Oleg","Osetinskiy",20,"C#"),
            new People("Andrey", "Olegov", 21, "C#"),
            new People("Masha", "Oximironova", 18, "C++")
        };

        public void AddPeople(People newPeople)
        {
            peopleList.Add(newPeople);
        }
        public void RemovePeople(People peopleToRemove)
        {
            peopleList.Remove(peopleToRemove);
        }

        //public void EditPeople(People peopleToEdit)
        //{
        //    var result = peopleList.Find(x => x.Equals(peopleToEdit));
        //}

        public People GetPeople(int index)
        {
            return peopleList[index];
        }

        public void ListAllPeople()
        {
            int i =0;
            foreach (People peop in peopleList)
            {
                Console.WriteLine(i + " " +peop.ToString());
                i++;
            }
        }
    }
}
