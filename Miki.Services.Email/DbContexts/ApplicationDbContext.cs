using Microsoft.EntityFrameworkCore;
using Miki.Services.Email.Models;


namespace Miki.Services.Email.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<EmailLog> EmailLogs { get; set; }


    }
}
