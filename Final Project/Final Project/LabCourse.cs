using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class LabCourse : Course
    {
        public string LabDays { get; set; }
        public string LabTime { get; set; }

        public LabCourse(string courseName, string courseCode, int credits, Instructor instructor, string labDays, string labTime)
            : base(courseName, courseCode, credits, instructor)
        {
            LabDays = labDays;
            LabTime = labTime;
        }

        public void Enroll(Student student)
        {
            base.Enroll(student); // some special method to check if a lecturecourse passed
                                  // then students can take the labcourse 
        }
    }

}
