using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDevFullStackDbm.Data.Entities
{
    public class Client
    {
        [Column("IdCliente")]
        [Key]
        public int IdCliente { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public ICollection<Protocol> Protocols { get; set; } = new List<Protocol>();
    }
}
