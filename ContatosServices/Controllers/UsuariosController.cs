
using Contatos.Modelo;
using ContatosServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ContatosServices.Controllers
{
    public class UsuariosController : ApiController
    {
        private ContatoContext db = new ContatoContext();
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            var lista = db.Usuarios;
            return lista;
        }
        
        // GET: api/Usuario/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Get(int id)
        {
            var item = db.Usuarios.FirstOrDefault(u => u.Id == id);
            if(item == null)
            {
                return NotFound(); //http 404
            }
            return Ok(item); //http 200 Ok
        }
        
        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
