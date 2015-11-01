using SqlServer.Entity.Entities;
using System.Data.Entity;

namespace SqlServer.Entity
{
    public class SsmDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}