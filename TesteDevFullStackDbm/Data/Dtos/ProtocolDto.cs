using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteDevFullStackDbm.Data.Entities;

namespace TesteDevFullStackDbm.Data.Dtos
{
    public class ProtocolDto
    {
        [Key]
        public int IdProtocol { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DataAbertura { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime? DataFechamento { get; set; }

        [Required]
        [ForeignKey("Client")]
        public int ClienteId { get; set; }

        [Required]
        [ForeignKey("StatusProtocol")]
        public int ProtocolStatusId { get; set; }

        public ICollection<StatusProtocolDto> Follows { get; set; } = new List<StatusProtocolDto>();
    }
}
