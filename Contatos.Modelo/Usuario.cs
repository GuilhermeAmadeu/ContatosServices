using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Modelo
{
    [Table(name: "Usuario")]
    public class Usuario
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Token { get; set; }
        [Required,StringLength(150)]
        public string Nome { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(10)]
        public string Senha { get; set; }
    }
}
