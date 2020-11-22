using Microsoft.EntityFrameworkCore;
using Models;

namespace Escalator.API
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {           
        }     

        public DbSet<Escalation> Escalations {get; set;}   
    }
}