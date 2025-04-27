using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMS.Models;

    public class NeondbContext : DbContext
    {
        public NeondbContext (DbContextOptions<NeondbContext> options)
            : base(options)
        {
        }

        public DbSet<SMS.Models.Item> Item { get; set; } = default!;

public DbSet<SMS.Models.Founder> Founder { get; set; } = default!;

public DbSet<SMS.Models.Claimant> Claimant { get; set; } = default!;
    }
