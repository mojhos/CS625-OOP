using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Project
{
    public class Instructor : Person
    {
        public string Department { get; set; }
        public List<Course> CoursesTaught { get; set; } = new List<Course>();

        public Instructor(string name, string id, string email, string department)
            : base(name, id, email)
        {
            Department = department;
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hello, I am {Name}, an instructor in the {Department} department.");
        }
    }
}
