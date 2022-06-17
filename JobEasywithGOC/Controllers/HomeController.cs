using JobEasyWithGOC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GoC.WebTemplate.Components.Core.Services;


namespace JobEasyWithGOC.Controllers
{
    public class HomeController : ExtendedBaseController
    {
    
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ModelAccessor modelAccessor) : base(modelAccessor)
        {
            _logger = logger;
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