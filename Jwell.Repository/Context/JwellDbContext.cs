using Jwell.Domain.Entities;
using Jwell.Domian.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jwell.Repository.Context
{
    public class JwellDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public JwellDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
