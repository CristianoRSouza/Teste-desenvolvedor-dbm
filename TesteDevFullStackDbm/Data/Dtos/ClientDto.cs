using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.Data.Dtos
{
    public class ClientDto
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(255)]
        public string Endereco { get; set; }

        public ICollection<Protocol> Protocols { get; set; } = new List<Protocol>();
    }
}
