using Microsoft.EntityFrameworkCore;
using SCM.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.Infrastructure.Data

{
    public class SCMContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Multa> Multas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BdSCM;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>().ToTable("TbVeiculo");

            modelBuilder.Entity<Multa>().ToTable("TbInfracao");


            #region           //Configurando a entidade Endereço com Fluent API

            modelBuilder.Entity<Endereco>()
                .Property(x => x.Rua)
                .HasColumnType("Varchar(200)");

            modelBuilder.Entity<Endereco>()
            .Property(x => x.CEP)
            .HasColumnType("Varchar(9)");

            modelBuilder.Entity<Endereco>()
            .Property(x => x.Logradouro)
            .HasColumnType("Varchar(400)");
            #endregion


        }
    }
}
