using DoubleV.BE.Api.Domain.Context;
using DoubleV.BE.Api.Domain.Models;
using DoubleV.BE.Api.Helpers.Extensions;
using DoubleV.BE.Api.Helpers.Pagination;
using DoubleV.BE.Api.Helpers.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DoubleV.BE.Api.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<PagedModel<Ticket>> GetAllTicketsPagination(Pagination pagination, CancellationToken cancellationToken)
        {
            return await _context.Tickets
                        .AsNoTracking()
                        .PaginateAsync(pagination.Page, pagination.Limit, cancellationToken);
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await _context.Tickets
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ticket> CreateTicket(CreateTicketRequest request)
        {
            var ticket = new Ticket()
            {
                Usuario = request.Usuario,
                FechaCreacion = DateTime.Now,
                Status = request.Status
            };

            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task<Ticket> UpdateTicket(int id, CreateTicketRequest request)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket != null)
            {
                ticket.Usuario = request.Usuario;
                ticket.Status = request.Status;
                ticket.FechaActualizacion = DateTime.Now;

                _context.Entry(ticket).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return ticket;
        }

        public async Task<Ticket> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            return ticket;
        }
    }
}
