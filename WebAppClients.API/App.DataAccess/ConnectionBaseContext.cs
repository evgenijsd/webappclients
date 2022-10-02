using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.DataAccess
{
    public partial class ConnectionBaseContext : DbContext
    {
        public ConnectionBaseContext()
        {            
        }

        public ConnectionBaseContext(DbContextOptions<ConnectionBaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
            new Client[]
            {
                new Client { Id= Guid.NewGuid(), Name="Client1", Email="c1@c1.c1", Phone="0122311", City="City1", Birthday= DateTime.Parse("01/01/1999"), Created=DateTime.Parse("01/01/2009"), Comment="Comment1" },
                new Client { Id= Guid.NewGuid(), Name="Client2", Email="c2@c2.c2", Phone="0122311", City="City1", Birthday= DateTime.Parse("01/01/1999"), Created=DateTime.Parse("01/01/2009"), Comment="Comment2" },
                new Client { Id= Guid.NewGuid(), Name="Client3", Email="c3@c3.c3", Phone="0122311", City="City1", Birthday= DateTime.Parse("01/01/1999"), Created=DateTime.Parse("01/01/2009"), Comment="Comment3" }
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
