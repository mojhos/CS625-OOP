using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Program
    {

        static List<Course> courses = new List<Course>();
        static List<Student> students = new List<Student>();
        static List<Instructor> instructors = new List<Instructor>();
        static Admin admin;

        static void Main(string[] args)
        {
            // Initialize the admin
            admin = new Admin("Admin", "A001", "admin@university.edu", "System Administrator");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the University Management System");
                Console.WriteLine("1. Admin Menu");
                Console.WriteLine("2. Student Menu");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdminMenu();
                        break;
                    case "2":
                        StudentMenu();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AdminMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nAdmin Menu");
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. View Courses");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCourse();
                        break;
                    case "2":
                        AddInstructor();
                        break;
                    case "3":
                        ViewCourses();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddCourse()
        {
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();

            Console.Write("Enter Course Code: ");
            string courseCode = Console.ReadLine();

            Console.Write("Enter Credits: ");
            int credits = int.Parse(Console.ReadLine());

            Console.Write("Enter Department Name: ");
            string departmentName = Console.ReadLine();

            Instructor Teacher = new Instructor("name", "id", "email", "department");
            bool exit = false;
            while (!exit) {
                Console.WriteLine("\nPlease select or create an instructor:\n1. Add an Instructor\n2. Select an Instructor\n3. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddInstructor();
                        break;
                    case "2":
                        if (instructors.Count == 0)
                        {
                            Console.WriteLine("There is no Instructor in the list to select!!!!");
                            break;
                        }
                        Teacher = selectInstructors();
                        Console.WriteLine($"{Teacher.Name} is add to this course as an Instructor");
                        exit = true;
                        break;
                    case "3":
                        if (Teacher is null)
                        {
                            Console.WriteLine("You can not exit without selecting an instructor for this course!!!!!!!!!!!\n");
                            break;
                        }
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            
            
            
            // Create course and add to the list
            Course newCourse = new Course(courseName, courseCode, credits, Teacher);
            courses.Add(newCourse);
            Console.WriteLine($"Course {courseName} has been added to the {departmentName} department.");
        }

        static void AddInstructor()
        {
            Console.Write("Enter Instructor Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Instructor ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Instructor Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Department: ");
            string department = Console.ReadLine();

            Instructor newInstructor = new Instructor(name, id, email, department);
            instructors.Add(newInstructor);
            Console.WriteLine($"Instructor {name} has been added.");
        }

        static Instructor selectInstructors()
        {
            Console.WriteLine("please select your instructor from the list by selecting the number:\n");
            Instructor Teacher = new Instructor("name", "id", "email", "department");
            int Index = 1;
            foreach (var item in instructors)
            {
                Console.WriteLine($"{Index}. {item.Name}");
                Index++;
            }
            Console.Write("Select an option: ");
            string select = Console.ReadLine();
            switch (select)
            {
                case ("1"):
                    Teacher = instructors[0];
                    break;
                case ("2"):
                    Teacher = instructors[1];
                    break;
                case ("3"):
                    Teacher = instructors[2];
                    break;
                default:
                    break;
            }
            return Teacher;
        }

        static void ViewCourses()
        {
            Console.WriteLine("\nAvailable Courses:");
            Console.WriteLine("Course Name & ID - Credits - Instructor ");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].CourseName} ({courses[i].CourseCode}) - {courses[i].Credits} Credits - presented by {courses[i].Instructor.Name}");
            }
        }

        static void StudentMenu()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Student Email: ");
            string email = Console.ReadLine();

            Student student = new Student(name, id, email, "Undecided");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nStudent Menu");
                Console.WriteLine("1. View Courses");
                Console.WriteLine("2. Enroll in Course");
                Console.WriteLine("3. View Enrolled Courses");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewCourses();
                        break;
                    case "2":
                        EnrollInCourse(student);
                        break;
                    case "3":
                        ViewEnrolledCourses(student);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void EnrollInCourse(Student student)
        {
            Console.WriteLine("Select a course to enroll in:");
            ViewCourses();
            Console.Write("Enter course number: ");
            int courseNumber = int.Parse(Console.ReadLine());

            if (courseNumber > 0 && courseNumber <= courses.Count)
            {
                courses[courseNumber - 1].Enroll(student);
                student.EnrollmentList.Add(new Enrollment(Guid.NewGuid().ToString(), courses[courseNumber - 1], student));
                Console.WriteLine($"{student.Name} has been enrolled in {courses[courseNumber - 1].CourseName}.");
            }
            else
            {
                Console.WriteLine("Invalid course selection.");
            }
        }

        static void ViewEnrolledCourses(Student student)
        {
            Console.WriteLine($"Enrolled Courses for {student.Name}:");
            foreach (var enrollment in student.EnrollmentList)
            {
                Console.WriteLine($"{enrollment.Course.CourseName} ({enrollment.Course.CourseCode})");
            }
        }
    }

}

