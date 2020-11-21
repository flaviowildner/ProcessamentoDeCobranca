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
            
            // modelBuilder.Entity<Cliente>().HasData(randomClientes());

            base.OnModelCreating(modelBuilder);
        }

        public static IEnumerable<Cliente> randomClientes()
        {
            CPFFormatter cpfFormatter = new CPFFormatter();


            int nClientes = 10;
            List<Cliente> clientes = new List<Cliente>();
            for (int i = 0; i < nClientes; i++)
            {
                Cliente cliente = new Cliente();
                cliente.Cpf = cpfFormatter.ToLong(GerarCpf());
                cliente.Nome = "Nome_" + i;
                cliente.Estado = "Estado_" + i;

                clientes.Add(cliente);
            }

            return clientes;
        }

        public static String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }
    }
}