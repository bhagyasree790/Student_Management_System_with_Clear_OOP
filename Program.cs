using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    //Abstract Base Class
    public abstract class Person
    {
        public string Name {get; set;}
        public string Age {get; set;}
        public string Email {get; set;}

        public abstract void DisplayInfo();
    }

    //Department Class
    public class Department
    {
        public string DepartmentId {get; set;}
        public string DepartmentName {get; set;}
    }

    //Course Class
    public class Course
    {
        public string CourseId {get; set;}
        public string CourseName {get; set;}
        public string DepartmentName {get; set;}
    }

    //Student Class
    public class Student : Person
    {
        public string StudentId {get; set;}
        public string CourseName {get; set;}
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Student] ID: {StudentId}, Name: {Name}, Age: {Age}, Email: {Email}, Course: {CourseName}");
        }
    }

    //Teacher Class
    public class Teacher : Person
    {
        public string TeacherId {get; set;}
        public string CourseName {get; set;}
        public string DepartmentName {get; set;}

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Teacher] ID: {TeacherId}, Name: {Name}, Age: {Age}, Email: {Email}, Course: {CourseName}, Department: {DepartmentName}");
        }
    }

    //Repository
    public interface IRepository<P>
    {
        void Add(P entity);
        void Remove(string id);
        void DisplayAll();
    }

    //Student Repository
    public class StudentRepository : IRepository<Student>
    {
        private List<Student> students = new List<Student>();

        public void Add(Student student) => students.Add(student);

        public void Remove(string id) => students.RemoveAll(s => s.StudentId == id);

        public void DisplayAll()
        {
            foreach (var s in students) s.DisplayInfo();
        }

        public Student FindById(string id) => students.Find(s => s.StudentId == id);
    }

    //Teacher Repository
    public class TeacherRepository : IRepository<Teacher>
    {
        private List<Teacher> teachers = new List<Teacher>();

        public void Add(Teacher teacher) => teachers.Add(teacher);

        public void Remove(string id) => teachers.RemoveAll(t => t.TeacherId == id);

        public void DisplayAll()
        {
            foreach (var t in teachers) t.DisplayInfo();
        }

        public Teacher FindById(string id) => teachers.Find(t => t.TeacherId == id);
    }

    //Department Repository
    public class DepartmentRepository : IRepository<Department>
    {
        private List<Department> departments = new List<Department>();

        public void Add(Department dept) => departments.Add(dept);

        public void Remove(string id) => departments.RemoveAll(d => d.DepartmentId == id);

        public void DisplayAll()
        {
            foreach (var d in departments)
                Console.WriteLine($"[Department] ID: {d.DepartmentId}, Name: {d.DepartmentName}");
        }

        public Department FindById(string id) => departments.Find(d => d.DepartmentId == id);
    }

    //Course Repository
    public class CourseRepository : IRepository<Course>
    {
        private List<Course> courses = new List<Course>();

        public void Add(Course course) => courses.Add(course);

        public void Remove(string id) => courses.RemoveAll(c => c.CourseId == id);

        public void DisplayAll()
        {
            foreach (var c in courses)
                Console.WriteLine($"[Course] ID: {c.CourseId}, Name: {c.CourseName}, Department: {c.DepartmentName}");
        }

        public Course FindById(string id) => courses.Find(c => c.CourseId == id);
    }

    //Main Program
    class Program
    {
        static void Main()
        {
            var studentRepo = new StudentRepository();
            var teacherRepo = new TeacherRepository();
            var deptRepo = new DepartmentRepository();
            var courseRepo = new CourseRepository();

            while (true)
            {
                Console.WriteLine("\n=== Student Management System ===");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Add Course");
                Console.WriteLine("3. Add Student");
                Console.WriteLine("4. Add Teacher");
                Console.WriteLine("5. Update Department");
                Console.WriteLine("6. Update Course");
                Console.WriteLine("7. Update Student");
                Console.WriteLine("8. Update Teacher");
                Console.WriteLine("9. Delete Department");
                Console.WriteLine("10. Delete Course");
                Console.WriteLine("11. Delete Student");
                Console.WriteLine("12. Delete Teacher");
                Console.WriteLine("13. Show Departments");
                Console.WriteLine("14. Show Courses");
                Console.WriteLine("15. Show Students");
                Console.WriteLine("16. Show Teachers");
                Console.WriteLine("17. Exit");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Department ID: ");
                        string deptId = Console.ReadLine();
                        Console.Write("Department Name: ");
                        string deptName = Console.ReadLine();
                        deptRepo.Add(new Department { DepartmentId = deptId, DepartmentName = deptName });
                        Console.WriteLine("Department added successfully!");
                        break;

                    case "2":
                        Console.Write("Course ID: ");
                        string cId = Console.ReadLine();
                        Console.Write("Course Name: ");
                        string cName = Console.ReadLine();
                        Console.Write("Department Name: ");
                        string cDept = Console.ReadLine();
                        courseRepo.Add(new Course { CourseId = cId, CourseName = cName, DepartmentName = cDept });
                        Console.WriteLine("Course added successfully!");
                        break;

                    case "3":
                        Console.Write("Student ID: ");
                        string sId = Console.ReadLine();
                        Console.Write("Name: ");
                        string sName = Console.ReadLine();
                        Console.Write("Age: ");
                        string sAge = Console.ReadLine();
                        Console.Write("Email: ");
                        string sEmail = Console.ReadLine();
                        Console.Write("Course Name: ");
                        string sCourse = Console.ReadLine();
                        studentRepo.Add(new Student { StudentId = sId, Name = sName, Age = sAge, Email = sEmail, CourseName = sCourse });
                        Console.WriteLine("Student added successfully!");
                        break;

                    case "4":
                        Console.Write("Teacher ID: ");
                        string tId = Console.ReadLine();
                        Console.Write("Name: ");
                        string tName = Console.ReadLine();
                        Console.Write("Age: ");
                        string tAge = Console.ReadLine();
                        Console.Write("Email: ");
                        string tEmail = Console.ReadLine();
                        Console.Write("Course Name: ");
                        string tCourse = Console.ReadLine();
                        Console.Write("Department Name: ");
                        string tDept = Console.ReadLine();
                        teacherRepo.Add(new Teacher { TeacherId = tId, Name = tName, Age = tAge, Email = tEmail, CourseName = tCourse, DepartmentName = tDept });
                        Console.WriteLine("Teacher added successfully!");
                        break;

                    case "5":
                        Console.Write("Enter Department ID to update: ");
                        string updateDeptId = Console.ReadLine();
                        var deptToUpdate = deptRepo.FindById(updateDeptId);
                        if (deptToUpdate != null)
                        {
                            Console.Write("New Department Name: ");
                            deptToUpdate.DepartmentName = Console.ReadLine();
                            Console.WriteLine("Department updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Department not found!");
                        }
                        break;

                    case "6":
                        Console.Write("Enter Course ID to update: ");
                        string updateCourseId = Console.ReadLine();
                        var courseToUpdate = courseRepo.FindById(updateCourseId);
                        if (courseToUpdate != null)
                        {
                            Console.Write("New Course Name: ");
                            courseToUpdate.CourseName = Console.ReadLine();
                            Console.Write("New Department Name: ");
                            courseToUpdate.DepartmentName = Console.ReadLine();
                            Console.WriteLine("Course updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Course not found!");
                        }
                        break;

                    case "7":
                        Console.Write("Enter Student ID to update: ");
                        string updateStudentId = Console.ReadLine();
                        var studentToUpdate = studentRepo.FindById(updateStudentId);
                        if (studentToUpdate != null)
                        {
                            Console.Write("New Name: ");
                            studentToUpdate.Name = Console.ReadLine();
                            Console.Write("New Age: ");
                            studentToUpdate.Age = Console.ReadLine();
                            Console.Write("New Email: ");
                            studentToUpdate.Email = Console.ReadLine();
                            Console.Write("New Course Name: ");
                            studentToUpdate.CourseName = Console.ReadLine();
                            Console.WriteLine("Student updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;

                    case "8":
                        Console.Write("Enter Teacher ID to update: ");
                        string updateTeacherId = Console.ReadLine();
                        var teacherToUpdate = teacherRepo.FindById(updateTeacherId);
                        if (teacherToUpdate != null)
                        {
                            Console.Write("New Name: ");
                            teacherToUpdate.Name = Console.ReadLine();
                            Console.Write("New Age: ");
                            teacherToUpdate.Age = Console.ReadLine();
                            Console.Write("New Email: ");
                            teacherToUpdate.Email = Console.ReadLine();
                            Console.Write("New Course Name: ");
                            teacherToUpdate.CourseName = Console.ReadLine();
                            Console.Write("New Department Name: ");
                            teacherToUpdate.DepartmentName = Console.ReadLine();
                            Console.WriteLine("Teacher updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Teacher not found!");
                        }
                        break;

                    case "9":
                        Console.Write("Enter Department ID to delete: ");
                        string deleteDeptId = Console.ReadLine();
                        deptRepo.Remove(deleteDeptId);
                        Console.WriteLine("Department deleted successfully!");
                        break;

                    case "10":
                        Console.Write("Enter Course ID to delete: ");
                        string deleteCourseId = Console.ReadLine();
                        courseRepo.Remove(deleteCourseId);
                        Console.WriteLine("Course deleted successfully!");
                        break;

                    case "11":
                        Console.Write("Enter Student ID to delete: ");
                        string deleteStudentId = Console.ReadLine();
                        studentRepo.Remove(deleteStudentId);
                        Console.WriteLine("Student deleted successfully!");
                        break;

                    case "12":
                        Console.Write("Enter Teacher ID to delete: ");
                        string deleteTeacherId = Console.ReadLine();
                        teacherRepo.Remove(deleteTeacherId);
                        Console.WriteLine("Teacher deleted successfully!");
                        break;

                    case "13":
                        deptRepo.DisplayAll();
                        break;

                    case "14":
                        courseRepo.DisplayAll();
                        break;

                    case "15":
                        studentRepo.DisplayAll();
                        break;

                    case "16":
                        teacherRepo.DisplayAll();
                        break;

                    case "17":
                        return;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}