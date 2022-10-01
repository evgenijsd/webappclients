using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess
{
    public class ConnectionBaseContext : DbContext
    {
        public ConnectionBaseContext()
        {
        }

        public ConnectionBaseContext(DbContextOptions<ConnectionBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
