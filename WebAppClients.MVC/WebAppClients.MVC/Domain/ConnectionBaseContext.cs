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
        }

        public DbSet<Client> Clients { get; set; }        
    }
}
