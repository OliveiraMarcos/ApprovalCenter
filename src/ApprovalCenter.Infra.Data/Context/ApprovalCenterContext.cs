﻿using ApprovalCenter.Domain.Approval.Entities;
using ApprovalCenter.Domain.Category.Entities;
using ApprovalCenter.Infra.Data.ContextConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ApprovalCenter.Infra.Data.Context
{
    public class ApprovalCenterContext : DbContext
    {
        public DbSet<ApprovalEntity> Approval { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        private readonly IHostEnvironment _env;

        public ApprovalCenterContext(IHostEnvironment env)
        {
            _env = env;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApprovalContextConfiguration()); 
            modelBuilder.ApplyConfiguration(new CategoryContextConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApprovalCenterContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
