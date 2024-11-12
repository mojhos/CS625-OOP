using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Course> CoursesOffered { get; set; } = new List<Course>();

        public Department(string departmentName)
        {
            DepartmentName = departmentName;
        }

        public void AddCourse(Course course)
        {
            CoursesOffered.Add(course);
            Console.WriteLine($"Course {course.CourseName} has been added to the {DepartmentName} department.");
        }
    }

}
