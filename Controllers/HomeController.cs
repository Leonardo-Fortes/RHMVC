using Microsoft.AspNetCore.Mvc;
using RHMVC.Models;
using System.Diagnostics;

namespace RHMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FolhaService _folhaService;


        public HomeController(ILogger<HomeController> logger, FolhaService folhaService)
        {
            _logger = logger;
            _folhaService = folhaService;
        }
        
        public IActionResult Index()
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