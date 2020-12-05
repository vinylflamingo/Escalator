using Microsoft.EntityFrameworkCore;
using Escalator.Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Escalator.API
{
    public class DBContext: IdentityDbContext<IdentityUser>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {           
        }     

        public DbSet<Ticket> Tickets {get; set;}   
        public DbSet<Agent> Agents {get; set;}
        public DbSet<Jurisdiction> Jurisdictions {get; set;}
        public DbSet<TicketType> TicketType {get; set;}

    }
}