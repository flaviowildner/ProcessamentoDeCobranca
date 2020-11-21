using System;
using System.Collections.Generic;
using ClienteAPI.Models.Entity;
using ClienteAPI.Util;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Persistence.Contexts
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("clientes");
            modelBuilder.Entity<Cliente>().HasKey(p => p.Cpf);
            modelBuilder.Entity<Cliente>().Property(m => m.Cpf)
                .ValueGeneratedNever();

            base.OnModelCreating(modelBuilder);
        }
    }
}