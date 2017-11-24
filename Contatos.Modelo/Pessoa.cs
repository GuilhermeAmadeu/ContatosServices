using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Modelo
{
    public class Pessoa
    {
        [Key]
        public Guid Id { get; set; }    
        [Required]
        public int IdUsuario { get; set; }   
        [Required,StringLength(150)]
        public string Nome { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Telefone { get; set; }
        [StringLength(250)]
        public string Observacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [StringLength(9)]
        public string Cep { get; set; }
        [StringLength(150)]
        public string Endereco { get; set; }
        [StringLength(10)]
        public string Numero { get; set; }
        [StringLength(50)]
        public string Bairro { get; set; }
        [StringLength(150)]
        public string Cidade { get; set; }
        [StringLength(2)]
        public string Uf { get; set; }
        [ForeignKey (nameof(IdUsuario))]
        public Usuario UsuarioItem { get; set; }
    }
}
