using Examination_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_System.Data
{
    public class AppDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranSub>().HasKey(am => new
            {
                am.BranchId,
                am.SubjectId
            });
            modelBuilder.Entity<BranSub>().HasOne(m => m.Branch).WithMany(am => am.BranSubs).HasForeignKey(m => m.BranchId);
            modelBuilder.Entity<BranSub>().HasOne(m => m.Subject).WithMany(am => am.BranSubs).HasForeignKey(m => m.SubjectId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranSub> BranSubs { get; set; }
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
