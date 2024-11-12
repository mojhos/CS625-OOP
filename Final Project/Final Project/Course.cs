using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Course : IEnrollable
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int Credits { get; set; }
        public Instructor Instructor { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public Course(string courseName, string courseCode, int credits, Instructor instructor)
        {
            CourseName = courseName;
            CourseCode = courseCode;
            Credits = credits;
            Instructor = instructor;
        }

        public void Enroll(Student student)
        {
            EnrolledStudents.Add(student);
            Console.WriteLine($"{student.Name} has been enrolled in {CourseName}.");
        }
    }
}
