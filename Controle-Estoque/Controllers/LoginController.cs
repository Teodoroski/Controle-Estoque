using Controle_Estoque.Context;
using Controle_Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Controle_Estoque.Controllers
{
    public class LoginController : Controller
    {
        private readonly PerfilContext _context;

        public LoginController(PerfilContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            // Procura o Nome e Senha do Usuário
            var usuarioBanco = _context.Usuarios.FirstOrDefault(
                u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);

            // Verifica se existe
            if (usuarioBanco == null)
            {
                ViewBag.Erro = "Usuário ou senha incorretos";
                return View();
            }
            HttpContext.Session.SetString("NomeUsuario", usuario.Nome);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Adicionando ao Banco de dados
                _context.Usuarios.Add(usuario);
                // Salvando as alterações
                _context.SaveChanges();
                // Retornando a página de Login
                return RedirectToAction(nameof(Login));
            }
            ViewBag.Erro = "Tem que preencher os espaços vazios";
            return View();
        }
    }
}