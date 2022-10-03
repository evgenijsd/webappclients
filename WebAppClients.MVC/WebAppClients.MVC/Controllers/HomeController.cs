using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppClients.MVC.Domain.Repositories.Abstract;
using WebAppClients.MVC.Domain.Repositories.EntityFramework;
using WebAppClients.MVC.Models;

namespace WebAppClients.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository _clientRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
            return View(_clientRepository.GetAll());
        }

        public IActionResult Clients()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
