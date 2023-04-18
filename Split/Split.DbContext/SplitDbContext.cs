using Microsoft.EntityFrameworkCore;
namespace Split.DbContexts
{
    public class SplitDbContext : DbContext
    {

        public SplitDbContext(DbContextOptions<SplitDbContext> connection) : base(connection) { }
    }
}