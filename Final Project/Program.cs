namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instructors
            Instructor instructor1 = new Instructor("Dr. Smith", "I001", "smith@university.edu", "Computer Science");
            Instructor instructor2 = new Instructor("Prof. Johnson", "I002", "johnson@university.edu", "Mathematics");

            // Create courses
            Course course1 = new Course("Data Structures", "CS101", 3, instructor1);
            Course course2 = new Course("Calculus", "MATH101", 4, instructor2);

            // Create students
            Student student1 = new Student("Alice", "S001", "alice@student.edu", "Computer Science");
            Student student2 = new Student("Bob", "S002", "bob@student.edu", "Mathematics");

            // Enroll students
            Enrollment enrollment1 = new Enrollment("E001", course1, student1);
            Enrollment enrollment2 = new Enrollment("E002", course2, student2);

            student1.EnrollmentList.Add(enrollment1);
            student2.EnrollmentList.Add(enrollment2);

            // Introduce students and instructors
            student1.Introduce();
            student2.Introduce();
            instructor1.Introduce();
            instructor2.Introduce();

            // Display course information
            Console.WriteLine($"{student1.Name} is enrolled in {course1.CourseName} taught by {instructor1.Name}.");
            Console.WriteLine($"{student2.Name} is enrolled in {course2.CourseName} taught by {instructor2.Name}.");
        }
    }
}

