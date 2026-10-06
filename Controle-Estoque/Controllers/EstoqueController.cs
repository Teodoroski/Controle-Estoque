using Controle_Estoque.Context;
using Controle_Estoque.Filters;
using Controle_Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

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

        // Listar os produtos
        [HttpGet]
        public IActionResult Listar()
        {
            var produto = _context.Produtos
                .Include(p => p.Categoria)
                .ToList();
            
            return View(produto);
        }

        // Adicionar produtos ao banco de dados
        [HttpGet]
        public IActionResult Adicionar()
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Listar");
            }
            ViewBag.Categorias = _context.Categorias.ToList();

            return View(produto);
        }

        // Editar/Atualizar o Produto ja existente
        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound();
            }
            ViewBag.Categorias = _context.Categorias.ToList();

            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();

                return RedirectToAction("Listar");
            }

            ViewBag.Categorias = _context.Categorias.ToList();

            return View(produto);
        }

        // Deletar o Produto
        public IActionResult Deletar(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return RedirectToAction("Listar");
        }
    }
}