using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Enrollment
    {
        public string EnrollmentID { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public string Grade { get; set; }

        public Enrollment(string enrollmentID, Course course, Student student)
        {
            EnrollmentID = enrollmentID;
            Course = course;
            Student = student;
        }
    }

}
