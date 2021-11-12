using System;

namespace DoubleV.BE.Api.Domain.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public bool Status { get; set; }
    }
}
