using App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppClients.MVC.Domain.Entities;
using WebAppClients.MVC.Domain.Repositories.Abstract;

namespace WebAppClients.MVC.Domain.Repositories.EntityFramework
{
    public class EFClientRepository : IClientRepository
    {
        private readonly ConnectionBaseContext _context;

        public EFClientRepository(ConnectionBaseContext context)
        {
            _context = context;
        }

        public List<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client GetById(Guid id)
        {
            return _context.Clients.FirstOrDefault(x => x.Id == id);
        }
    }
}
