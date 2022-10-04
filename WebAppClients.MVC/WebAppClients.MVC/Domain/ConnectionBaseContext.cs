using Microsoft.EntityFrameworkCore;
using System;
using WebAppClients.MVC.Domain.Entities;

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

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
            new Client[]
            {
                new Client
                {
                    Id= Guid.NewGuid(),
                    Name="john doe",
                    Gender="male",
                    Email="john@gmail.com",
                    Phone="1-570-236-7033",
                    City="kilcoole",
                    Birthday= DateTime.Parse("01/02/1989"),
                    Created=DateTime.Parse("03/02/2019"),
                    Comment="Comment1"
                },
                new Client
                {
                    Id= Guid.NewGuid(),
                    Name="david morrison",
                    Gender="male",
                    Email="morrison@gmail.com",
                    Phone="1-570-236-7033",
                    City="kilcoole",
                    Birthday= DateTime.Parse("01/03/1979"),
                    Created=DateTime.Parse("07/08/2017"),
                    Comment="Comment2"
                },
                new Client
                {
                    Id= Guid.NewGuid(),
                    Name="kevin ryan",
                    Gender="male",
                    Email="kevin@gmail.com",
                    Phone="1-567-094-1345",
                    City="Cullman",
                    Birthday= DateTime.Parse("04/05/1975"),
                    Created=DateTime.Parse("01/09/2018"),
                    Comment="Comment3"
                },
                new Client
                {
                    Id= Guid.NewGuid(),
                    Name="don romer",
                    Gender="male",
                    Email="don@gmail.com",
                    Phone="1-765-789-6734",
                    City="San Antonio",
                    Birthday=
                    DateTime.Parse("11/01/1985"),
                    Created=DateTime.Parse("01/11/2018"),
                    Comment="Comment4"
                },
                new Client
                {
                    Id= Guid.NewGuid(),
                    Name="derek powell",
                    Gender="male",
                    Email="derek@gmail.com",
                    Phone="1-956-001-1945",
                    City="san Antonio",
                    Birthday=
                    DateTime.Parse("12/05/1995"),
                    Created=DateTime.Parse("01/12/2020"),
                    Comment="Comment5"
                },
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
