using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class LectureCourse : Course
    {
        public string LectureDays { get; set; }
        public string LectureTime { get; set; }

        public LectureCourse(string courseName, string courseCode, int credits, Instructor instructor, string lectureDays, string lectureTime)
            : base(courseName, courseCode, credits, instructor)
        {
            LectureDays = lectureDays;
            LectureTime = lectureTime;
        }
        //public LectureCourse(string courseName, string courseCode, int credits, string lectureDays, string lectureTime)
        //    : base(courseName, courseCode, credits)
        //{
        //    LectureDays = lectureDays;
        //    LectureTime = lectureTime;
        //}
    }
}
