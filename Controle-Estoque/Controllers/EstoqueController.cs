using Controle_Estoque.Context;
using Controle_Estoque.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Estoque.Controllers
{
    [LoginRequired]
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