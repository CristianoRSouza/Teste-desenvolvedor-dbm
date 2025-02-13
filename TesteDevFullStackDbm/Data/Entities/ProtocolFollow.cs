using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDevFullStackDbm.Data.Entities
{
    public class ProtocolFollow
    {
        [Key]
        [Column("IdFollow")]
        public int IdFollow { get; set; }

        [ForeignKey("Protocol")]
        [Column("IdProtocolo")]
        public int ProtocolId { get; set; }
        public Protocol Protocol { get; set; }

        [Column(TypeName = "DATE")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAcao { get; set; }

        public string DescricaoAcao { get; set; }
    }
}
