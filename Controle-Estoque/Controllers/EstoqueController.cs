using Controle_Estoque.Context;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Estoque.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly EstoqueContext _context;

        public EstoqueController(EstoqueContext context)
        {
            _context = context;
        }
        public IActionResult Listar()
        {
            return View();
        }
    }
}
