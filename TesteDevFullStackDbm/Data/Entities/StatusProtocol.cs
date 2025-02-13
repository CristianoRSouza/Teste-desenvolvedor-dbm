using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDevFullStackDbm.Data.Entities
{
    public class StatusProtocol
    {
        [Column("IdStatus")]
        [Key]
        public int IdStatus { get; set; }

        public string NomeStatus { get; set; }

        public ICollection<Protocol> Protocols { get; set; } = new List<Protocol>();
    }
}
