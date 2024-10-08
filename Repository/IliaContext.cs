﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class IliaContext : DbContext
    {
        public IliaContext(DbContextOptions<IliaContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductMapping());
            ProductSeedData.Seed(modelBuilder);
        }

    }
}
    