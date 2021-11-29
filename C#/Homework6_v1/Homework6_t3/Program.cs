using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Homework6_t3
{
    public class Student: IComparable<Student>
    {
        private string name;
        private string surname;
        private int age;
        private int cource;

        public Student(string name, string surname, int age, int cource)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.cource = cource;
        }

        public string GetName()
        {
            return name;
        }
        
        public string GetSurname()
        {
            return surname;
        }
        
        public int GetAge()
        {
            return age;
        }
        
        public int GetCource()
        {
            return cource;
        }


        public int CompareTo(Student other)
        {
            string fullName1 = surname + name;
            string fullName2 = other.surname + other.name;
            return String.Compare(fullName1, fullName2, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return surname + " " + name;
        }
    }

    public class SortStudentName : IComparer
    {
        public int Compare(object x, object y)
        {
            Student student1 = (Student) x;
            Student student2 = (Student) y;
            
 
            return student1.CompareTo(student2);
        }
    }
    
    
    public class SortStudentAge : IComparer
    {
        public int Compare(object x, object y)
        {
            Student student1 = (Student) x;
            Student student2 = (Student) y;
            if (student1.GetAge() > student2.GetAge())
            {
                return 1;
            }
            else  if (student1.GetAge() < student2.GetAge())
            {
                return -1;
            }
 
            return 0;
        }
    }
    
    public class SortStudentAgeCource : IComparer
    {
        public int Compare(object x, object y)
        {
            int result = 0;
            Student student1 = (Student) x;
            Student student2 = (Student) y;
            if (student1.GetCource() > student2.GetCource())
            {
                result = 1;
            }
            else  if (student1.GetCource() < student2.GetCource())
            {
                result = -1;
            }
            else
            {
                if (student1.GetAge() > student2.GetAge())
                {
                    result = 1;
                }
                else if (student1.GetAge() < student2.GetAge())
                {
                    result = -1;
                }
            }
 
            return result;
        }
    }
    
    class Program
    {
        
       
        static void Main(string[] args)
        {
            ArrayList studentsName = new ArrayList();
            StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "students.csv");
            
            int bakalavr = 0;
            while(!sr.EndOfStream)
            {
                try {
                    string[] s = sr.ReadLine().Split(';');
                    Student student = new Student(s[0], s[1], Convert.ToInt32(s[5]), Convert.ToInt32(s[6]));
                    studentsName.Add(student);
                    if (student.GetCource() < 5) bakalavr++; 
                }
                catch
                {
                }
            }
            sr.Close();
            studentsName.Sort(new SortStudentName()); 
            Console.WriteLine("Всего студентов:{0}", studentsName.Count);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            
            Console.WriteLine("\nСписок студентов по алфавиту: ");
            foreach (var v in studentsName) Console.WriteLine(v);
            
            Console.WriteLine("\nСписок студентов по возрасту: ");
            studentsName.Sort(new SortStudentAge()); 
            foreach (var v in studentsName) Console.WriteLine(v);
            
            Console.WriteLine("\nСписок студентов по курсу и возрасту: ");
            studentsName.Sort(new SortStudentAgeCource()); 
            
            foreach (var v in studentsName) Console.WriteLine(v);
            Console.ReadKey();
        }
    }

}