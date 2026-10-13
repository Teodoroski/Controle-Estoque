using Controle_Estoque.Context;
using Controle_Estoque.Filters;
using Controle_Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Controle_Estoque.Controllers
{
    [LoginRequired]
    public class CategoriasController : Controller
    {
        private readonly EstoqueContext _context;

        public CategoriasController(EstoqueContext context)
        {
            _context = context;
        }
        public IActionResult Listar()
        {
            var categoria = _context.Categorias.ToList();
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                return View(categoria);
            }
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();

                return RedirectToAction("Listar");
            }

            return View(categoria);
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var categoria = _context.Produtos.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Listar");
        }
    }
}
