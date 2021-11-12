using DoubleV.BE.Api.Domain.Context;
using DoubleV.BE.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DoubleV.BE.Api.Domain.Data
{
    public class FakeDataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                         serviceProvider
                        .GetRequiredService<DbContextOptions<AppDbContext>>()
                        );

            if (context.Tickets.Any()) { return; }

            var tickets = new List<Ticket>
            {
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now.AddDays(-1), FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = DateTime.Now, Status = false },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = DateTime.Now, Status = false },
                new Ticket{ Usuario = "user2", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user3", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user3", FechaCreacion = DateTime.Now.AddDays(-5), FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now.AddDays(-1), FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = DateTime.Now, Status = false },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = DateTime.Now, Status = false },
                new Ticket{ Usuario = "user2", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user3", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user1", FechaCreacion = DateTime.Now, FechaActualizacion = null, Status = true },
                new Ticket{ Usuario = "user3", FechaCreacion = DateTime.Now.AddDays(-5), FechaActualizacion = null, Status = true },
            };

            context.Tickets.AddRange(tickets);

            context.SaveChanges();
        }
    }
}
