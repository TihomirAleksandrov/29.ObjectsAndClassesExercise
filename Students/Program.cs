using System;
using System.Linq;
using System.Collections.Generic;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int studentsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsNum; i++)
            {
                string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                double grade = double.Parse(studentInfo[2]);

                Student student = new Student(firstName, lastName, grade);

                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}
