using Contatos.Modelo;
using ContatosServices.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace ContatosService.Controllers
{
    public static class AutenticacaoHelper
    {
        private const string TOKEN = "token";

        public static Guid ObterToken(this ApiController source)
        {
            Guid result = Guid.Empty;

            if (source.Request.Headers.Contains(TOKEN))
            {
                var token = source.Request.Headers.GetValues(TOKEN).First();
                result = new Guid(token);
            }

            return result;
        }

        public static Usuario ObterUsuarioAutenticado(this ApiController source)
        {
            Usuario resultado = null;

            Guid token = ObterToken(source);

            // Verificar se existe o token
            if (token == Guid.Empty)
            {
                return resultado;
            }

            ContatoContext db = new ContatoContext();

            // Selecionar o usuário
            resultado = db.Usuarios.Where(r => r.Token == token).FirstOrDefault();

            return resultado;
        }
    }
}