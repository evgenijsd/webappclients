using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppClients.MVC.Domain.Entities;

namespace WebAppClients.MVC.Domain.Repositories.Abstract
{
    public interface IClientRepository
    {
        List<Client> GetAll();

        Client GetById(Guid id);
    }
}
