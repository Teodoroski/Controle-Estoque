using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Controle_Estoque.Filters
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? nomeUsuario = context.HttpContext.Session.GetString("NomeUsuario");
            
            if (nomeUsuario == null)
            {
                context.Result = new RedirectToActionResult(
                    "Login",
                    "Login",
                    null);
            }
        }
    }
}
