using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UniversityBase.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext() : base("StudentContext") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
}