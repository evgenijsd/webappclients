using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppClients.MVC.Domain.Repositories.Abstract;

namespace WebAppClients.MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", _clientRepository.GetById(id));
            }

            return View("Clients", _clientRepository.GetAll());
        }
    }
}
