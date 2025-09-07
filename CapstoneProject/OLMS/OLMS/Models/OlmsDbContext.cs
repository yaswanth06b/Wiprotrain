using Microsoft.EntityFrameworkCore;
using OLMS.Models;


namespace OLMS.Models
{
    public class OlmsDbContext :DbContext
    {
        public OlmsDbContext(DbContextOptions<OlmsDbContext> options) : base(options)
        {
        }
        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Cred>().ToTable("Cred");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Instructors>().ToTable("Instructors");
            modelBuilder.Entity<Admins>().ToTable("Admins");
            modelBuilder.Entity<Courses>().ToTable("Courses");
            modelBuilder.Entity<Enrolments>().ToTable("Enrolments");
            modelBuilder.Entity<Assignments>().ToTable("Assignments");
            modelBuilder.Entity<Questions>().ToTable("Questions");
            modelBuilder.Entity<Submissions>().ToTable("Submissions");
            modelBuilder.Entity<Payments>().ToTable("Payments");
            modelBuilder.Entity<Notifications>().ToTable("Notifications");
            modelBuilder.Entity<Quizzes>().ToTable("Quizzes");
        }

        public DbSet<Users> users { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrolments> Enrollments { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Submissions> Submissions { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Cred> Creds { get; set; }
        public DbSet<OLMS.Models.Quizzes> Quizzes { get; set; } = default!;
    }
}
