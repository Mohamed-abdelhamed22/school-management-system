namespace task5
{
    internal class Program
    {

        public class Student
        {
            public int StudentId;
            public string Name;
            public int Age;
            public List<Course> Courses;

            public Student(int studentId, string name, int age)
            {
                StudentId = studentId;
                Name = name;
                Age = age;
                Courses = new List<Course>();
            }

            public bool Enroll(Course course)
            {
                if (course == null) return false;

                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].CourseId == course.CourseId)
                        return false;
                }

                Courses.Add(course);
                return true;
            }

            public class Student
            {
                public int StudentId;
                public string Name;
                public int Age;
                public List<Course> Courses = new List<Course>();

                public Student(int studentId, string name, int age)
                {
                    StudentId = studentId;
                    Name = name;
                    Age = age;
                }

                public string PrintDetails()
                {
                    string details = "Student #" + StudentId + "\n" +
                                     "Name: " + Name + "\n" +
                                     "Age : " + Age + "\n" +
                                     "Courses:";
                    if (Courses.Count == 0)
                    {
                        details += " None";
                    }
                    else
                    {
                        for (int i = 0; i < Courses.Count; i++)
                        {
                            details += "\n - " + Courses[i].Title + " (#" + Courses[i].CourseId + ")";
                        }
                    }
                    return details;
                }
            }

            public class Instructor
            {
                public int InstructorId;
                public string Name;
                public string Specialization;

                public Instructor(int instructorId, string name, string specialization)
                {
                    InstructorId = instructorId;
                    Name = name;
                    Specialization = specialization;
                }

                public string PrintDetails()
                {
                    return "[Instructor] #" + InstructorId + " | " + Name + " | " + Specialization;
                }
            }

            public class Course
            {
                public int CourseId;
                public string Title;
                public Instructor Instructor;

                public Course(int courseId, string title, Instructor instructor)
                {
                    CourseId = courseId;
                    Title = title;
                    Instructor = instructor;
                }

                public string PrintDetails()
                {
                    string instName = (Instructor != null) ? Instructor.Name : "TBD";
                    return "[Course] #" + CourseId + " | " + Title + " | Instructor: " + instName;
                }
            }

            public class SchoolStudentManager
            {
                public List<Student> Students;
                public List<Course> Courses;
                public List<Instructor> Instructors;

                public SchoolStudentManager()
                {
                    Students = new List<Student>();
                    Courses = new List<Course>();
                    Instructors = new List<Instructor>();
                }

                public bool AddStudent(Student student)
                {
                    if (student == null) return false;
                    if (FindStudent(student.StudentId) != null) return false;
                    Students.Add(student);
                    return true;
                }

                public bool AddCourse(Course course)
                {
                    if (course == null) return false;
                    if (FindCourse(course.CourseId) != null) return false;
                    if (course.Instructor == null) return false;
                    Instructor foundInst = FindInstructor(course.Instructor.InstructorId);
                    if (foundInst == null) return false;
                    course.Instructor = foundInst;
                    Courses.Add(course);
                    return true;
                }

                public bool AddInstructor(Instructor instructor)
                {
                    if (instructor == null) return false;
                    if (FindInstructor(instructor.InstructorId) != null) return false;
                    Instructors.Add(instructor);
                    return true;
                }

                public Student FindStudent(int studentId)
                {
                    for (int i = 0; i < Students.Count; i++)
                        if (Students[i].StudentId == studentId)
                            return Students[i];
                    return null;
                }

                public Student FindStudentByName(string name)
                {
                    for (int i = 0; i < Students.Count; i++)
                        if (Students[i].Name != null &&
                            Students[i].Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                            return Students[i];
                    return null;
                }

                public Course FindCourse(int courseId)
                {
                    for (int i = 0; i < Courses.Count; i++)
                        if (Courses[i].CourseId == courseId)
                            return Courses[i];
                    return null;
                }

                public Course FindCourseByName(string title)
                {
                    for (int i = 0; i < Courses.Count; i++)
                        if (Courses[i].Title != null &&
                            Courses[i].Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                            return Courses[i];
                    return null;
                }

                public Instructor FindInstructor(int instructorId)
                {
                    for (int i = 0; i < Instructors.Count; i++)
                        if (Instructors[i].InstructorId == instructorId)
                            return Instructors[i];
                    return null;
                }

                public bool EnrollStudentInCourse(int studentId, int courseId)
                {
                    Student s = FindStudent(studentId);
                    Course c = FindCourse(courseId);
                    if (s == null || c == null) return false;
                    return s.Enroll(c);
                }

                public bool UpdateStudent(int studentId, string newName, int newAge)
                {
                    Student s = FindStudent(studentId);
                    if (s == null) return false;
                    s.Name = newName;
                    s.Age = newAge;
                    return true;
                }

                public bool DeleteStudent(int studentId)
                {
                    for (int i = 0; i < Students.Count; i++)
                    {
                        if (Students[i].StudentId == studentId)
                        {
                            Students.RemoveAt(i);
                            return true;
                        }
                    }
                    return false;
                }

                public bool IsStudentEnrolledInCourse(int studentId, int courseId)
                {
                    Student s = FindStudent(studentId);
                    if (s == null) return false;
                    for (int i = 0; i < s.Courses.Count; i++)
                        if (s.Courses[i].CourseId == courseId)
                            return true;
                    return false;
                }

                /*public string GetInstructorNameByCourseName(string courseName)
                {
                    for (int i = 0; i < Courses.Count; i++)
                    {
                        if (Courses[i].Title != null &&
                            Courses[i].Title.Equals(courseName, StringComparison.OrdinalIgnoreCase))
                        {
                            return (Courses[i].Instructor != null) ? Courses[i].Instructor.Name : null;
                        }
                    }
                    for (int i = 0; i < Courses.Count; i++)
                    {
                        if (Courses[i].Title != null &&
                            Courses[i].Title.IndexOf(courseName, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            return (Courses[i].Instructor != null) ? Courses[i].Instructor.Name : null;
                        }
                    }
                    return null;
                }
            }*/
                public class Program
                {
                    public static void Main()
                    {
                        SchoolStudentManager manager = new SchoolStudentManager();
                        bool running = true;

                        while (running)
                        {
                            Console.WriteLine("\n===== Student Management System =====");
                            Console.WriteLine("1. Add Student");
                            Console.WriteLine("2. Add Instructor");
                            Console.WriteLine("3. Add Course (select instructor by id)");
                            Console.WriteLine("4. Enroll Student in Course");
                            Console.WriteLine("5. Show All Students");
                            Console.WriteLine("6. Show All Courses");
                            Console.WriteLine("7. Show All Instructors");
                            Console.WriteLine("8. Find Student (id or name)");
                            Console.WriteLine("9. Find Course (id or name)");
                            Console.WriteLine("10. Update Student");
                            Console.WriteLine("11. Delete Student");
                            Console.WriteLine("12. Is student enrolled in course?");
                            // Console.WriteLine("13. Instructor name by course name") msh kmala lsa msh 3aref a3mlha;
                            Console.WriteLine("13. Exit");
                            Console.Write("==> ");

                            string choice = (Console.ReadLine() ?? "").Trim();

                            switch (choice)
                            {
                                case "1":
                                    {
                                        int id = ReadInt("Student Id: ");
                                        Console.Write("Name: ");
                                        string name = Console.ReadLine() ?? "";
                                        int age = ReadInt("Age: ");
                                        bool ok = manager.AddStudent(new Student(id, name, age));
                                        Print(ok ? "Student added." : "Student with same id exists.", ok);
                                        break;
                                    }

                                case "2":
                                    {
                                        int id = ReadInt("Instructor Id: ");
                                        Console.Write("Name: ");
                                        string name = Console.ReadLine() ?? "";
                                        Console.Write("Specialization: ");
                                        string spec = Console.ReadLine() ?? "";
                                        bool ok = manager.AddInstructor(new Instructor(id, name, spec));
                                        Print(ok ? "Instructor added." : "Instructor with same id exists.", ok);
                                        break;
                                    }

                                case "3":
                                    {
                                        int id = ReadInt("Course Id: ");
                                        Console.Write("Course Title: ");
                                        string title = Console.ReadLine() ?? "";
                                        int instId = ReadInt("Instructor Id for this course: ");
                                        Instructor inst = manager.FindInstructor(instId);
                                        if (inst == null)
                                        {
                                            Print("Instructor not found.", false);
                                        }
                                        else
                                        {
                                            bool ok = manager.AddCourse(new Course(id, title, inst));
                                            Print(ok ? "Course added." : "Course not added (duplicate id or invalid instructor).", ok);
                                        }
                                        break;
                                    }

                                case "4":
                                    {
                                        int sid = ReadInt("Student Id: ");
                                        int cid = ReadInt("Course Id: ");
                                        bool ok = manager.EnrollStudentInCourse(sid, cid);
                                        Print(ok ? "Enrolled successfully." : "Failed to enroll.", ok);
                                        break;
                                    }

                                case "5":
                                    {
                                        if (manager.Students.Count == 0) { Console.WriteLine("No students."); break; }
                                        for (int i = 0; i < manager.Students.Count; i++)
                                            Console.WriteLine(manager.Students[i].PrintDetails());
                                        break;
                                    }

                                case "6":
                                    {
                                        if (manager.Courses.Count == 0) { Console.WriteLine("No courses."); break; }
                                        for (int i = 0; i < manager.Courses.Count; i++)
                                            Console.WriteLine(manager.Courses[i].PrintDetails());
                                        break;
                                    }

                                case "7":
                                    {
                                        if (manager.Instructors.Count == 0) { Console.WriteLine("No instructors."); break; }
                                        for (int i = 0; i < manager.Instructors.Count; i++)
                                            Console.WriteLine(manager.Instructors[i].PrintDetails());
                                        break;
                                    }

                                case "8":
                                    {
                                        Console.Write("Enter student id or name: ");
                                        string q = Console.ReadLine() ?? "";
                                        Student s = null;
                                        int id;
                                        if (int.TryParse(q, out id)) s = manager.FindStudent(id);
                                        else s = manager.FindStudentByName(q);
                                        Console.WriteLine(s == null ? "Not found." : s.PrintDetails());
                                        break;
                                    }

                                case "9":
                                    {
                                        Console.Write("Enter course id or name: ");
                                        string q = Console.ReadLine() ?? "";
                                        Course c = null;
                                        int id;
                                        if (int.TryParse(q, out id)) c = manager.FindCourse(id);
                                        else c = manager.FindCourseByName(q);
                                        Console.WriteLine(c == null ? "Not found." : c.PrintDetails());
                                        break;
                                    }

                                case "10":
                                    {
                                        int id = ReadInt("Student Id to update: ");
                                        Console.Write("New Name: ");
                                        string name = Console.ReadLine() ?? "";
                                        int age = ReadInt("New Age: ");
                                        bool ok = manager.UpdateStudent(id, name, age);
                                        Print(ok ? "Student updated." : "Student not found.", ok);
                                        break;
                                    }

                                case "11":
                                    {
                                        int id = ReadInt("Student Id to delete: ");
                                        bool ok = manager.DeleteStudent(id);
                                        Print(ok ? "Student deleted." : "Student not found.", ok);
                                        break;
                                    }

                                case "12":
                                    {
                                        int sid = ReadInt("Student Id: ");
                                        int cid = ReadInt("Course Id: ");
                                        bool ok = manager.IsStudentEnrolledInCourse(sid, cid);
                                        Console.WriteLine(ok ? "Yes, enrolled." : "No, not enrolled.");
                                        break;
                                    }
                                case "13":
                                    running = false;
                                    break;

                                default:
                                    Print("Invalid choice.", false);
                                    break;
                            }
                        }
                    }

                    static int ReadInt(string prompt)
                    {
                        while (true)
                        {
                            Console.Write(prompt);
                            string s = Console.ReadLine();
                            int v;
                            if (int.TryParse(s, out v)) return v;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid integer.");
                            Console.ResetColor();
                        }
                    }

                    static void Print(string msg, bool success)
                    {
                        Console.ForegroundColor = success ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.WriteLine(msg);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}

