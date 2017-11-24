using Contatos.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContatosServices.Models
{
    public class ContatoContext:DbContext
    {
        public ContatoContext()
            : base(Properties.Settings.Default.connContatos)
        {          

        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}