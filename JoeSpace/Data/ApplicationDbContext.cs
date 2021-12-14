using JoeSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace JoeSpace.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
    }
}
