using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialize.Logic.Entity
{
    [Serializable]
    public class People
    {
        [XmlElement]
        public string FirstName { get; private set; }
        [XmlElement]
        public string LastName { get; private set; }
        [XmlElement]
        public int Age { get; private set; }
        [XmlElement]
        public string Subdivision { get; private set; }

        public People(string firstName, string lastName, int age, string subdivision)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Subdivision = subdivision;
        }

        public People()
        {
            FirstName = "peopleName";
            LastName = "lastName";
            Age = 0;
            Subdivision = "subdivision";
        }

        public void DataUpdate(string firstName, string lastName, int age, string subdivision)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Subdivision = subdivision;
        }

        public override string ToString()
        {
            return "First Name: " + FirstName + " Last Name: " + LastName + " Age: " + Age + " Subdivision: " + Subdivision +" ";
        }
    }
}
