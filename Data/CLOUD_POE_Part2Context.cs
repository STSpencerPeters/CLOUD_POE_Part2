using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CLOUD_POE_Part2.Models;

namespace CLOUD_POE_Part2.Data
{
    public class CLOUD_POE_Part2Context : DbContext
    {
        public CLOUD_POE_Part2Context (DbContextOptions<CLOUD_POE_Part2Context> options)
            : base(options)
        {
        }

        public DbSet<CLOUD_POE_Part2.Models.Admin> Admin { get; set; } = default!;
        public DbSet<CLOUD_POE_Part2.Models.Customer> Customer { get; set; } = default!;
        public DbSet<CLOUD_POE_Part2.Models.Product> Product { get; set; } = default!;
        public DbSet<CLOUD_POE_Part2.Models.Order> Order { get; set; } = default!;
        public DbSet<CLOUD_POE_Part2.Models.OrderItem> OrderItem { get; set; } = default!;
    }
}
