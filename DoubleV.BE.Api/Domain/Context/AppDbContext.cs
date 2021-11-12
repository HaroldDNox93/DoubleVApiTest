
using DoubleV.BE.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DoubleV.BE.Api.Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
