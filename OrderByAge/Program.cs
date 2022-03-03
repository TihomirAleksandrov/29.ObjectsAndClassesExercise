using System;
using System.Linq;
using System.Collections.Generic;

namespace OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personalInfo = input.Split().ToArray();

                string name = personalInfo[0];
                string id = personalInfo[1];
                int age = int.Parse(personalInfo[2]);

                Person selectedPerson = people.FirstOrDefault(x => x.ID == id);

                if (selectedPerson != null)
                {
                    selectedPerson.Age = age;
                    selectedPerson.Name = name;
                    continue;
                }

                Person person = new Person(name, id, age);
                people.Add(person);
            }

            people = people.OrderBy(x => x.Age).ToList();

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
