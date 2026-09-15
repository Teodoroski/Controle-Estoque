using Controle_Estoque.Filters;
using Controle_Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Controle_Estoque.Controllers
{
    [LoginRequired]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string? nome = HttpContext.Session.GetString("NomeUsuario");

            ViewBag.nome = nome;
            return View();
        }

        [HttpGet]
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
