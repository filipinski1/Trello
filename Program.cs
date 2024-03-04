using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Trello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer("Data Source=MSI\\MSSQLSERVER01;Initial Catalog=Week19;Integrated Security=True");
            var options = optionsBuilder.Options;

            using (var context = new SchoolContext(options))
            {
            }
        }

        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public byte[] Photo { get; set; }
            public decimal Height { get; set; }
            public float Weight { get; set; }

            public Grade Grade { get; set; }
        }

        public class Grade
        {
            public int GradeId { get; set; }
            public string GradeName { get; set; }
            public string Section { get; set; }

            public ICollection<Student> Students { get; set; }
        }

        public class SchoolContext : DbContext
        {
            public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
            {
            }

            public DbSet<Student> Students { get; set; }

            public DbSet<Grade> Grades { get; set; }
        }
    }
}
