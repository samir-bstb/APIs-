using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Attemp1.Models;

namespace Attemp1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Human> Human { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}