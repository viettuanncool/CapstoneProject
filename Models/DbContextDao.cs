using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Models
{
    public class DbContextDao : DbContext
    {
        public DbContextDao() { }
        public DbContextDao(DbContextOptions<DbContextDao> options) : base(options) { }
        public DbSet<Listing> Listings { get; set; }
    }
}
