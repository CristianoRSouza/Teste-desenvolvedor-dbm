using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.Data.Dtos
{
    public class ProtocolFollowDto
    {
        [Key]
        public int IdFollow { get; set; }

        [Required]
        [ForeignKey("Protocol")]
        public int ProtocolId { get; set; }
        public Protocol Protocol { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DataAcao { get; set; }

        public StatusProtocolDto StatusProtocol { get; set; }

        [Required]
        public string DescricaoAcao { get; set; }
    }
}
