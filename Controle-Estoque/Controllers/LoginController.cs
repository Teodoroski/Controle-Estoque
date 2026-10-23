using Controle_Estoque.Context;
using Controle_Estoque.Models;
using Microsoft.AspNetCore.Identity;
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
            var hasher = new PasswordHasher<Usuario>();

            // Buscar o nome do usuario
            var usuarioBanco = _context.Usuarios.FirstOrDefault(
                u => usuario.Nome == u.Nome);

            // Verifica se o nome do usuário existe
            if (usuarioBanco == null)
            {
                ViewBag.Error = "Usuário ou senha incorretos";
                return View();
            }

            var resultado = hasher.VerifyHashedPassword(
                usuarioBanco, // Usuario encontrado no banco de dados
                usuarioBanco.Senha, // o hash (senha criptografada) armazenada 
                usuario.Senha); // Senha informada no formulário     

            // Verifica se a senha digitada é a correta
            if (resultado == PasswordVerificationResult.Failed)
            {
                ViewBag.Error = "Usuário ou senha incorretos";
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
                // Verifica se o usuário já existe no banco
                var usuarioExistente = _context.Usuarios.Any(
                u => usuario.Nome.ToUpper() == u.Nome.ToUpper() || usuario.Email.ToUpper() == u.Email.ToUpper());

                if (usuarioExistente == true)
                {
                    ViewBag.Error = "Usuario já está cadastrado com esse nome ou email!";
                    return View();
                }

                // Cria um hasher para criptografar a senha criada
                var hasher = new PasswordHasher<Usuario>();
                usuario.Senha = hasher.HashPassword(usuario, usuario.Senha);

                // Adiciona ao Banco de dados
                _context.Usuarios.Add(usuario);
                // Salva no banco de dados
                _context.SaveChanges();
                // Retornando a página de Login
                return RedirectToAction(nameof(Login));
            }

            ViewBag.Error = "Tem que preencher os espaços vazios!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 

            return RedirectToAction("Login");
        }
    }
}