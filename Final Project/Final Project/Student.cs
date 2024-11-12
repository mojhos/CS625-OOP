using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Project
{
    public class Student : Person
    {
        public string Major { get; set; }
        public double GPA { get; set; }
        public List<Enrollment> EnrollmentList { get; set; } = new List<Enrollment>();

        public Student(string name, string id, string email, string major)
            : base(name, id, email)
        {
            Major = major;
        }

        public override void Introduce()
        {
            Console.WriteLine($"Hello, I am {Name}, a student majoring in {Major} with a GPA of {GPA}.");
        }
    }
}
