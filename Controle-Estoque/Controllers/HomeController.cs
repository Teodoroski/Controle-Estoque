using Controle_Estoque.Context;
using Controle_Estoque.Filters;
using Controle_Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Controle_Estoque.Controllers
{
    [LoginRequired]
    public class HomeController : Controller
    {
        private readonly EstoqueContext _context;

        public HomeController(EstoqueContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int quantidadeProduto = _context.Produtos.Count();
            int quantidadeUnidade = _context.Produtos.Sum(q => q.Quantidade);
            int quantidadeEstoqueBaixo = _context.Produtos.Count(q => q.Quantidade <= 5);
            double valorTotalEstoque = _context.Produtos.Sum(v => v.Preco * v.Quantidade);

            ViewBag.Quant = quantidadeProduto;
            ViewBag.Unid = quantidadeUnidade;
            ViewBag.Baixo = quantidadeEstoqueBaixo;
            ViewBag.VTotal = valorTotalEstoque;
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
