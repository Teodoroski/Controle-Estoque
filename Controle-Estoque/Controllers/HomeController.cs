using Controle_Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Controle_Estoque.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string? nome = HttpContext.Session.GetString("NomeUsuario");

            ViewBag.nome = nome;
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
