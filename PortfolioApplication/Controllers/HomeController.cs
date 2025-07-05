using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioApplication.Models;
using Domain.Interfaces.IServices;

namespace PortfolioApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }
        public IActionResult Indexs()
        {
            return View();
        }
        public IActionResult Education()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Certificates()
        {
            return View();
        }
        public IActionResult Experience()
        {
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            var infos = await _service.GetAllAsync();
            return View(infos);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
