using CQRSPractica.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSPractica.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }


    }
}
