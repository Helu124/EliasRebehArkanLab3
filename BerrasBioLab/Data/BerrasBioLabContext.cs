using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BerrasBioLab.Models;

namespace BerrasBioLab.Data
{
    public class BerrasBioLabContext : DbContext
    {
        public BerrasBioLabContext(DbContextOptions<BerrasBioLabContext> options)
            : base(options)
        {
        }

        public DbSet<BerrasBioLab.Models.Customer>? Customer { get; set; }

        public DbSet<BerrasBioLab.Models.Movie>? Movie { get; set; }

        public DbSet<BerrasBioLab.Models.Showcase>? Showcase { get; set; }

        public DbSet<BerrasBioLab.Models.Salon>? Salon { get; set; }
    }
}
