using DoubleV.BE.Api.Domain.Models;
using System.Collections.Generic;

namespace DoubleV.BE.Api.Helpers.Response
{
    public record GetAllTicketResponseDto
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<Ticket> Items { get; init; }
    }
}
