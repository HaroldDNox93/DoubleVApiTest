using DoubleV.BE.Api.Domain.Models;
using DoubleV.BE.Api.Helpers.Pagination;
using DoubleV.BE.Api.Helpers.Request;
using System.Threading;
using System.Threading.Tasks;

namespace DoubleV.BE.Api.Repository
{
    public interface ITicketRepository
    {
        Task<PagedModel<Ticket>> GetAllTicketsPagination(Pagination pagination, CancellationToken cancellationToken);
        Task<Ticket> GetTicketById(int id);
        Task<Ticket> CreateTicket(CreateTicketRequest request);
        Task<Ticket> UpdateTicket(int id, CreateTicketRequest request);
        Task<Ticket> DeleteTicket(int id);
    }
}
