using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialize.Logic.Entity;
using System.IO;

namespace Serialize.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository rep = new Repository();
            rep = RestoreRepository();
            string choise = "0";
            while (choise != "7")
            {
                Console.WriteLine("Select operation: ");
                Console.WriteLine("1. Add Person");
                Console.WriteLine("2. Edit Person");
                Console.WriteLine("3. Delete Person");
                Console.WriteLine("4. Safe to XML");
                Console.WriteLine("5. Safe to BIN");
                Console.WriteLine("6. List People");
                Console.WriteLine("7. Exit");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter name: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter last name: ");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter age: ");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter subdivision: ");
                            string division = Console.ReadLine();
                            People newPeople = new People(name, lastName, age, division);
                            rep.AddPeople(newPeople);
                            Console.Clear();
                            break;
                        }
                    case "2":
                        {
                            rep.ListAllPeople();
                            Console.WriteLine("Select index: ");
                            int index = int.Parse(Console.ReadLine());
                            People people = rep.GetPeople(index);
                            Console.WriteLine("Enter name: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter last name: ");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter age: ");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter subdivision: ");
                            string division = Console.ReadLine();
                            people.DataUpdate(name, lastName, age, division);
                            Console.Clear();
                            break;
                        }
                    case "3":
                        {
                            rep.ListAllPeople();
                            Console.WriteLine("Select index: ");
                            int index = int.Parse(Console.ReadLine());
                            var peopleToRemove = rep.GetPeople(index);
                            rep.RemovePeople(peopleToRemove);
                            Console.Clear();
                            break;
                        }
                    case "4":
                        {
                            XMLSerialize xmlSerialize = new XMLSerialize();
                            xmlSerialize.SaveInXmlFormat(rep, "xmlSerialize.xml");
                            Console.Clear();
                            break;
                        }
                    case "5":
                        {
                            BinSerialize binSerialize = new BinSerialize();
                            binSerialize.Serialize(rep, "binSerialize.bin");
                            Console.Clear();
                            break;
                        }
                    case "6":
                        {
                            rep.ListAllPeople();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                }
            }
            SaveRepository(rep);
        }
        
        static Repository RestoreRepository()
        {
            StreamReader sr = new StreamReader("options.ini", System.Text.Encoding.Default);
            string line = sr.ReadLine();
            var path = line.Split(';');
            Repository rep = new Repository();
            if (path[0] == "bin")
            {
                try
                {
                    BinSerialize binSerialize = new BinSerialize();
                    rep = binSerialize.DeSerialize(path[1]);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found! Create new one");
                }
                catch (IOException)
                {
                    Console.WriteLine("File corrupted!");
                }
            }
            else
            {
                try
                {
                    XMLSerialize xml = new XMLSerialize();
                    rep = xml.DeserializeObject(path[1]);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found! Create new one");
                }
                catch (IOException)
                {
                    Console.WriteLine("File corrupted!");
                }
            }
            return rep;
        }

        static void SaveRepository(Repository rep)
        {
            StreamReader sr = new StreamReader("options.ini", System.Text.Encoding.Default);
            string line = sr.ReadLine();
            var path = line.Split(';');
            if (path[0] == "bin")
            {
                try
                {
                    BinSerialize binSerialize = new BinSerialize();
                    binSerialize.Serialize(rep, path[1]);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found! Create new one");
                }
                catch (IOException)
                {
                    Console.WriteLine("File corrupted!");
                }
            }
            else
            {
                try
                {
                    XMLSerialize xml = new XMLSerialize();
                    xml.SaveInXmlFormat(rep, path[1]);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found! Create new one");
                }
                catch (IOException)
                {
                    Console.WriteLine("File corrupted!");
                }
            }
        }
    }
}
