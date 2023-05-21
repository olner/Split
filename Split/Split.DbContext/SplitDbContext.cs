using Microsoft.EntityFrameworkCore;
using Split.DbContexts.Tables;

namespace Split.DbContexts
{
    public class SplitDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupsMembers> GroupsMembers { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Debts> Debts { get; set; }
        public SplitDbContext(DbContextOptions<SplitDbContext> connection) : base(connection) { }
    }
}