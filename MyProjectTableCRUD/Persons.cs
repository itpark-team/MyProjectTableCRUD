using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyProjectTableCRUD
{
    

    internal class Persons
    {
        #region Generate Persons Methods
        static private Person GeneratePerson(Random random, string[] nameStrings)
        {
            return new Person(nameStrings[random.Next(0, nameStrings.Length)], random.Next(10, 89));
        }

        static public Person[] GeneratePersonArray(int countPersons)
        {
            Random random = new Random();
            string[] nameStrings = new[] { "Vasya", "Kostya", "Dima", "Masha", "Olga", "Petya", "Glasha", "Sofiya" };

            Person[] personsArray = new Person[0];

            for (int i = 0; i < countPersons; i++)
            {
                Person person = GeneratePerson(random, nameStrings);
                AddPersonToArray(ref personsArray, ref person);
            }

            return personsArray;
        }
        #endregion

        static ref Person FindPersonByAge(Person[] personsArray, int age)
        {
            try
            {
                for (int i = 0; i < personsArray.Length; i++)
                {
                    if (personsArray[i].Age == age)
                    {
                        return ref personsArray[i];
                    }
                }

                throw new Exception($"Not find person by parameter age = {age}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



        }
        static void UpdateAgePerson(ref Person updatePerson, int newAgePerson)
        {
            updatePerson.Age = newAgePerson;
        }

        static public void UpdateNamePerson(ref Person updatePerson, string newNamePerson)
        {
            updatePerson.Name = newNamePerson;
        }

        static int IndexOf(Person[] personsArray, ref Person findPerson)
        {
            int index = -1;
            for (int i = 0; i < personsArray.Length; i++)
            {
                if (personsArray[i].Equals(findPerson))
                {
                    index = i;
                }
            }
            return index;
        }

        static void RemovePersonInArrayPersons(ref Person[] personsArray, ref Person removePerson)
        {
            int index = IndexOf(personsArray, ref removePerson);
            if (index > 0)
            {
                ResizeArrayPersonsToRemove(ref personsArray, index);
            }
            else
            {
                Console.WriteLine($"Person {removePerson} not find.");
            }
        }

        static public void RemovePersonInArrayByIndex(ref Person[] arrayPersons, int index)
        {
            ResizeArrayPersonsToRemove(ref arrayPersons, index);
        }

        static private void ResizeArrayPersonsToRemove(ref Person[] arrayPersons, int indexEmpty)
        {
            for (int i = indexEmpty; i < arrayPersons.Length - 1; i++)
            {

                arrayPersons[i] = arrayPersons[i + 1];
            }
            Array.Resize(ref arrayPersons, arrayPersons.Length - 1);
        }

        static private void ResizeArrayPersonToAdd(ref Person[] arrayPersons)
        {
            Array.Resize(ref arrayPersons, arrayPersons.Length + 1);
        }

        static private void AddPersonToArray(ref Person[] arrayPersonsToAdd, ref Person personAdd)
        {
            ResizeArrayPersonToAdd(ref arrayPersonsToAdd);
            arrayPersonsToAdd[arrayPersonsToAdd.Length - 1] = personAdd;
        }

        static private void PrintPerson(ref Person person)
        {
            Console.WriteLine(person);
        }
        static private void PrintPersons(ref Person[] persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

        }

        static public void SerializeFile(ref Person[] personsArrayItem)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //XmlSerializer serializer = new XmlSerializer(typeof(Person));

            using (FileStream fileStream = new FileStream("file", FileMode.Create))
            {
                formatter.Serialize(fileStream, personsArrayItem);
            }
        }

        static public void DeserializeFile(ref Person[] arrayPersons)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("file", FileMode.Open))
            {
                arrayPersons = (Person[])formatter.Deserialize(stream);
            }

        }

    }


}

