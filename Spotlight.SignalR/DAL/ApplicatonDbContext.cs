using Microsoft.EntityFrameworkCore;
using Spotlight.SignalR.Entities;

namespace Spotlight.SignalR.DAL
{
  
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {

            }

            public DbSet<Message> Messages { get; set; }
        }
    }

