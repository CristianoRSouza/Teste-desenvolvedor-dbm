using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDevFullStackDbm.Data.Entities
{
    public class Protocol
    {
        [Key]
        [Column("IdProtocolo")]
        public int IdProtocol { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAbertura { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataFechamento { get; set; }

        [ForeignKey("Client")]
        [Column("IdCliente")]
        public int ClienteId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("StatusProtocol")]
        [Column("IdStatus")]
        public int ProtocolStatusId { get; set; }
        public StatusProtocol StatusProtocol { get; set; }

        public ICollection<ProtocolFollow> Follows { get; set; }
    }
}
