using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVClab.Models;

namespace MVClab.Context
{
    public class CompanyContext : IdentityDbContext<ApplicationUser>
    {
        public CompanyContext(DbContextOptions<CompanyContext> options):base(options) { }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<CourseInstructor> CourseInstructors { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = .\\SQLNEW ; database = tantamvcdb ; trusted_connection=true ; encrypt = false");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.SSN, sc.Number });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc=>sc.Student)
                .WithMany(s=>s.StudentCourses)
                .HasForeignKey(sc=>sc.SSN);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc=>sc.Course)
                .WithMany(s=>s.StudentCourses)
                .HasForeignKey(sc=>sc.Number);

            modelBuilder.Entity<CourseInstructor>()
                .HasKey(ci=>new {ci.Number,ci.SSN});

            modelBuilder.Entity<CourseInstructor>()
                .HasOne(ci=>ci.Course)
                .WithMany(c=>c.CourseInstructors)
                .HasForeignKey(ci=>ci.Number);

            modelBuilder.Entity<CourseInstructor>()
                .HasOne(ci=>ci.Instructor)
                .WithMany(i=>i.CourseInstructors)
                .HasForeignKey(ci=>ci.SSN);

            modelBuilder.Entity<Department>()
                .HasMany(d=>d.Students)
                .WithOne(s=>s.Department)
                .HasForeignKey(s=>s.deptId);

            modelBuilder.Entity<Department>()
                .HasMany(d=>d.Instructors)
                .WithOne(i=>i.Department)
                .HasForeignKey(i=>i.deptId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
