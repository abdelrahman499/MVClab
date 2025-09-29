using Microsoft.EntityFrameworkCore;
using MVClab.Models;

namespace MVClab.Context
{
    public class CompanyContext :DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .\\SQLNEW ; database = tantamvcdb ; trusted_connection=true ; encrypt = false");
        }

    }
}
