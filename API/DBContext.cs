using Microsoft.EntityFrameworkCore;
using Escalator.Common.Models;

namespace Escalator.API
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {           
        }     

        public DbSet<Escalation> Escalations {get; set;}   
        public DbSet<Agent> Agents {get; set;}
        public DbSet<Jurisdiction> Jurisdictions {get; set;}

    }
}