using Contatos.Modelo;
using ContatosService.Controllers;
using ContatosServices.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ContatosServices.Controllers
{
    [ApiAuthorizeAttribute]
    public class PessoaApiController : ApiController
    {
        private ContatoContext db = new ContatoContext();

        // GET: api/PessoaApi
        [AllowAnonymous()]
        public IQueryable<Pessoa> Get()
        {
            return db.Pessoas;
        }

        public IQueryable<Pessoa> Get(string content)
        {
            // Obter o usuário autenticado
            var usuaut = this.ObterUsuarioAutenticado();

            // Filtrar os itens do usuário autenticado
            var itens = db.Pessoas.Where(r => r.IdUsuario == usuaut.Id);

            if (!string.IsNullOrEmpty(content))
            {
                itens = itens.Where(r => r.Nome.Contains(content));
            }

            return itens;
        }

        // GET: api/PessoaApi/5
        [ResponseType(typeof(Pessoa))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var item = await db.Pessoas.FindAsync(id);

            // Obter o usuário autenticado
            var usuaut = this.ObterUsuarioAutenticado();

            // Verificar se o ID do usuário confere
            if (item.IdUsuario != usuaut.Id)
            {
                return BadRequest(Constantes.ID_DIVERGENTE);
            }

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/PessoaApi
        [ResponseType(typeof(Pessoa))]
        public async Task<IHttpActionResult> Post(Pessoa item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Obter o usuário autenticado
            var usuaut = this.ObterUsuarioAutenticado();

            // Verificar se o ID do usuário confere
            if (item.IdUsuario != usuaut.Id)
            {
                return BadRequest(Constantes.ID_DIVERGENTE);
            }

            try
            {
                db.Pessoas.Add(item);
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PessoaExists(item.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", null, item);
        }

        // PUT: api/PessoaApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(Pessoa item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Obter o usuário autenticado
            var usuaut = this.ObterUsuarioAutenticado();

            // Verificar se o ID do usuário confere
            if (item.IdUsuario != usuaut.Id)
            {
                return BadRequest(Constantes.ID_DIVERGENTE);
            }

            try
            {
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PessoaExists(item.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/PessoaApi/5
        [ResponseType(typeof(Pessoa))]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var item = await db.Pessoas.FindAsync(id);

            // Obter o usuário autenticado
            var usuaut = this.ObterUsuarioAutenticado();

            // Verificar se o ID do usuário confere
            if (item.IdUsuario != usuaut.Id)
            {
                return BadRequest(Constantes.ID_DIVERGENTE);
            }

            db.Pessoas.Remove(item);
            await db.SaveChangesAsync();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PessoaExists(Guid id)
        {
            return db.Pessoas.Count(e => e.Id == id) > 0;
        }
    }
}