using Examination_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Data
{
    public class AppDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchSubject>()
                .HasOne(b => b.Branch)
                .WithMany(ba => ba.BranchSubjects)
                .HasForeignKey(bi => bi.BranchId);
            modelBuilder.Entity<BranchSubject>()
                .HasOne(b => b.Subject)
                .WithMany(ba => ba.BrancheSubjects)
                .HasForeignKey(bi => bi.SubjectId);
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchSubject> BranchSubjects { get; set; }

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
