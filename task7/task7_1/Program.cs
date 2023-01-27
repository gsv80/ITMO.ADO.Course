using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task7_1.Program;

namespace task7_1
{
    internal class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int Id { get; set; }
            public List<int> Scores;

        }

        static List<Student> students = new List<Student>
        {
           new Student {First="Svetlana", Last="Omelchenko", Id=111, Scores= new List<int> {97, 92, 81, 60}
        },
           new Student { First = "Claire", Last = "O’Donnell", Id = 112, Scores = new List<int> { 75, 84, 91, 39 } },
        };

    static void Main(string[] args)
            {
                IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores[0] > 90
                select student;

                foreach (Student student in studentQuery)
                {
                    Console.WriteLine("{0}, {1}", student.Last, student.First);
                }
            }
        }
    }
