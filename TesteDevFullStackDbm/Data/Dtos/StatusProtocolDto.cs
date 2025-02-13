using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.Data.Dtos
{
    public class StatusProtocolDto
    {
        [Key]
        public int IdStatus { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeStatus { get; set; }

        public ICollection<Protocol> Protocols { get; set; } = new List<Protocol>();
    }
}
