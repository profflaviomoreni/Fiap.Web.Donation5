using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fiap.Web.Donation5.Controllers.Filters
{
    public class AutenticadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            if (session != null)
            {
                var usuario = session.GetString("usuarioLogado");
                if (string.IsNullOrEmpty(usuario))
                {
                    context.Result = new RedirectToActionResult("Index", "Login",null);
                }
            } else
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
