using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Controle_Estoque.Filters
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? nomeUsuario = context.HttpContext.Session.GetString("NomeUsuario");
            context.HttpContext.Response.Headers["Cache-Control"] = "no-store, no-cache";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";
            context.HttpContext.Response.Headers["Expires"] = "0";
            
            if (nomeUsuario == null)
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Login",
                    null
                    );
                return;

            }
            Controller controller = (Controller)context.Controller;
            controller.ViewBag.nome = nomeUsuario;

        }
    }
}