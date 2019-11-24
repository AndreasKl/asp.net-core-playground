using System;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static async Task<bool> Initialize(SchoolContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (await HasAtLeastOneStudentEntry(context))
            {
                return false;
            }

            await context.Students.AddRangeAsync(DemoStudents());
            await context.SaveChangesAsync();

            await context.Courses.AddRangeAsync(DemoCourses());
            await context.SaveChangesAsync();

            await context.Enrollments.AddRangeAsync(DemoEnrollments());
            await context.SaveChangesAsync();
            return true;
        }

        private static Enrollment[] DemoEnrollments()
        {
            return new[]
            {
                new Enrollment {StudentID = 1, CourseID = 1050, Grade = Grade.A},
                new Enrollment {StudentID = 1, CourseID = 4022, Grade = Grade.C},
                new Enrollment {StudentID = 1, CourseID = 4041, Grade = Grade.B},
                new Enrollment {StudentID = 2, CourseID = 1045, Grade = Grade.B},
                new Enrollment {StudentID = 2, CourseID = 3141, Grade = Grade.F},
                new Enrollment {StudentID = 2, CourseID = 2021, Grade = Grade.F},
                new Enrollment {StudentID = 3, CourseID = 1050},
                new Enrollment {StudentID = 4, CourseID = 1050},
                new Enrollment {StudentID = 4, CourseID = 4022, Grade = Grade.F},
                new Enrollment {StudentID = 5, CourseID = 4041, Grade = Grade.C},
                new Enrollment {StudentID = 6, CourseID = 1045},
                new Enrollment {StudentID = 7, CourseID = 3141, Grade = Grade.A},
            };
        }

        private static Course[] DemoCourses()
        {
            return new[]
            {
                new Course {CourseID = 1050, Title = "Chemistry", Credits = 3},
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3},
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3},
                new Course {CourseID = 1045, Title = "Calculus", Credits = 4},
                new Course {CourseID = 3141, Title = "Trigonometry", Credits = 4},
                new Course {CourseID = 2021, Title = "Composition", Credits = 3},
                new Course {CourseID = 2042, Title = "Literature", Credits = 4}
            };
        }

        private static Student[] DemoStudents()
        {
            return new[]
            {
                new Student {FirstName = "Carson", LastName = "Alexander", EnrolledAt = DateTime.Parse("2019-09-01")},
                new Student {FirstName = "Meredith", LastName = "Alonso", EnrolledAt = DateTime.Parse("2017-09-01")},
                new Student {FirstName = "Arturo", LastName = "Anand", EnrolledAt = DateTime.Parse("2018-09-01")},
                new Student {FirstName = "Gytis", LastName = "Barzdukas", EnrolledAt = DateTime.Parse("2017-09-01")},
                new Student {FirstName = "Yan", LastName = "Li", EnrolledAt = DateTime.Parse("2017-09-01")},
                new Student {FirstName = "Peggy", LastName = "Justice", EnrolledAt = DateTime.Parse("2016-09-01")},
                new Student {FirstName = "Laura", LastName = "Norman", EnrolledAt = DateTime.Parse("2018-09-01")},
                new Student {FirstName = "Nino", LastName = "Olivetto", EnrolledAt = DateTime.Parse("2019-09-01")}
            };
        }

        private static Task<bool> HasAtLeastOneStudentEntry(SchoolContext context)
        {
            return context.Students.Take(1).AnyAsync();
        }
    }
}