using Examination_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<MarksObt> MarksObts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TempMark> TempMarks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Examination;");
        }
    }
}
