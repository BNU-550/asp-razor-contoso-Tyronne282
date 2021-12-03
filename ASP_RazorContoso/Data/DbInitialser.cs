using ASP_RazorContoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_RazorContoso.Data
{
    public class DbInitialiser
    {
        public static void Initialize(ApplicationDbContext context)
        {
            AddStudents(context);
            AddCourses(context);
            AddEnrollments(context);
        }

        private static void AddStudents(ApplicationDbContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="Xavier",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Student{FirstName="Harry",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Micheal",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstName="Roche",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Josh",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Dan",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Student{FirstName="Tyronne",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Student{FirstName="Vinny",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }

        public static void AddCourses(ApplicationDbContext context)
        {
            if (context.Modules.Any())
            {
                return;
            }

            Module co550 = new Module
            {
                ModuleID = "co550",
                Title = "Web Applications"
            };

            Module co588 = new Module
            {
                ModuleID = "BT2CTG2",
                Title = "Database Design"
            };

            Module co567 = new Module
            { 
                ModuleID = "BT3CTG3", 
                Title = "OO Systems Development" 
            };

            Module co566 = new Module
            { 
                ModuleID = "BT4CTG4", 
                Title = "Software Engeering" 
            };

            var modules = new Module[]
            {
                co550, co566, co567, co588
            };
            
            context.Modules.AddRange(modules);
            context.SaveChanges(true);

            if (context.Courses.Any())
            {
                return;
            }

            var courses = new Course[]
            {
                new Course
                {
                    CourseID = "BT1CTG1",
                    Title = "Computing",
                    Modules = new List<Module> { co550, co566, co567, co588 }
                },

                new Course
                {
                    CourseID = "BT2CTG2",
                    Title = "Computing and Web",
                    Modules =new List<Module> { co550, co566, co567, co588 }
                },
                new Course{CourseID = "BT3CTG3", Title = "Data Science"},
                new Course{CourseID = "BT4CTG4", Title = "Software Engineering"},
                new Course{CourseID = "BT5CTG5", Title = "Artificial Intelligence"},
                new Course{CourseID = "BT6CTG6", Title = "Cyber Secruity"},
                new Course{CourseID = "BT7CTG7", Title = "Games Development"},    
            };
        }

        public static void AddEnrollments(ApplicationDbContext context)
        {
            if (context.Enrollments.Any())
            {
                return;
            }

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID="BT1CTG1",Grade=Grades.A},
                new Enrollment{StudentID=2,CourseID="BT1CTG1",Grade=Grades.B},
                new Enrollment{StudentID=3,CourseID="BT1CTG1" },
                new Enrollment{StudentID=4,CourseID="BT1CTG1",Grade=Grades.F},
                new Enrollment{StudentID=5,CourseID="BT1CTG1",Grade=Grades.C},
                new Enrollment{StudentID=6,CourseID="BT1CTG1" },
                new Enrollment{StudentID=7,CourseID="BT1CTG1",Grade=Grades.A},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        } 
    }
}
