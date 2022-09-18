using Microsoft.EntityFrameworkCore;
using StockSuite.Models;

namespace StockSuite.SSContext
{
    public partial class SSDBContext : DbContext
    {
        public SSDBContext()
        {

        }
        public SSDBContext(DbContextOptions<SSDBContext> options): base(options)
        {
        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
