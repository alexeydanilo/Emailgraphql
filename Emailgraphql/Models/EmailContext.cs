using Microsoft.EntityFrameworkCore;


namespace Emailgraphql.Models
{
    public class EmailContext : DbContext
    {
        public DbSet<EmailStatus> EmailsStatus { get; set; }
        public EmailContext(DbContextOptions<EmailContext> options)
            : base(options)
        {
          //  Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
