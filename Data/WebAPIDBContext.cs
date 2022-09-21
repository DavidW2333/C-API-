using CS335_A1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS335_A1.Data
{
    public class WebAPIDBContext : DbContext 
    { 
        public WebAPIDBContext(DbContextOptions<WebAPIDBContext> options) : base(options) { } 
        public DbSet<Staff> staff { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Comments> comments { get; set; }

    }
}
