using Dapper;
using DapperWeb.Models;
using DapperWeb.ORM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DapperWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISqlConnectionFactory dbFactory;

        public HomeController(ILogger<HomeController> logger,ISqlConnectionFactory dbFactory)
        {
            _logger = logger;
            this.dbFactory = dbFactory;
        }

        public IActionResult Index()
        {
            using var con=dbFactory.CreateConnection();
            try
            {
                var res = con.QuerySingle("select * from weather");
                ViewBag.Dbquery = res.ToString();


                return View();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());
                return View("Error");
            }
            
         
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