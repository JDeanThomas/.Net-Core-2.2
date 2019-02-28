using System;
using System.Collections.Generic;

namespace Test
{
    static class Program
    {

        static void Main(string[] args)
        {
            var test = new Student() { ID = 0, Name = "Test"};
            var students =  new List<Student>()
            {
                new Student{ID=1, Name="Tim"},
                new Student{ID=2, Name="Ellie"},
                new Student{ID=3, Name="Bjorn"},
                new Student{ID=4, Name="Agnes"},
            };

            Func<Student, string> func1 = GetStudentInfo;
            Func<Student, string> Func2 = s => $"ID:{s.ID} Name:{s.Name}";
            var infos1 = Select(students, s => $"ID:{s.ID} Name:{s.Name}");
            var infos2 = students.Select(s => $"ID:{s.ID} Name:{s.Name}");
            foreach (var info in infos2)
            {
                System.Console.WriteLine(info);
            }

        }

        static string GetStudentInfo(Student stu)
        {
            var info = $"ID:{stu.ID} Name:{stu.Name}";
            return info;
        }

        class Student
        {
            public int ID { get; set;}
            public string Name { get; set;}
        }
        public static IEnumerable<Tresult> Select<TSource, Tresult>(this IEnumerable<TSource> source, Func<TSource, Tresult> func)
        {
            var result = new List<Tresult>();
            foreach(var item in source)
            {
                result.Add(func(item));
            }
            return result;
        } 
    }
}
