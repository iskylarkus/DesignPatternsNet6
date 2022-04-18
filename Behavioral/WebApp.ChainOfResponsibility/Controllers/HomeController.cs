using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.ChainOfResponsibility.ChainOfResponsibility;
using WebApp.ChainOfResponsibility.Models;

namespace WebApp.ChainOfResponsibility.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppIdentityDbContext _appIdentityDbContext;

        public HomeController(ILogger<HomeController> logger, AppIdentityDbContext appIdentityDbContext)
        {
            _logger = logger;
            _appIdentityDbContext = appIdentityDbContext;
        }

        public async Task<IActionResult> SendEmail()
        {
            var products = await _appIdentityDbContext.Products.ToListAsync();

            var excelProcessHandler = new ExcelProcessHandler<Product>();

            var zipProcessHandler = new ZipProcessHandler<Product>();

            var emailProcessHandler = new EmailProcessHandler("products.zip", "ilker@selvi.com");

            excelProcessHandler.SetNext(zipProcessHandler).SetNext(emailProcessHandler);

            excelProcessHandler.handle(products);

            return View(nameof(Index));
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