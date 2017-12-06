using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using ContatosServices.Models;

namespace ContatosService.Controllers
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        private const string TOKEN = "token";
        private ContatoContext context = new ContatoContext();

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext))
                return;

            if (Authorize(actionContext))
            {
                return;
            }
            HandleUnauthorizedRequest(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Contains(TOKEN))
                {
                    bool tokenValido = false;

                    var token = actionContext.Request.Headers.GetValues(TOKEN).First();

                    if (!string.IsNullOrEmpty(token))
                    {
                        Guid guid = new Guid(token);
                        tokenValido = (context.Usuarios.Where(r => r.Token == guid).Count() > 0);
                    }

                    return tokenValido;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}