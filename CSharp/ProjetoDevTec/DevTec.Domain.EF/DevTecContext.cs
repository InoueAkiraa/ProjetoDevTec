using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DevTec.Domain.EF
{
    public partial class DevTecContext : DbContext
    {
        public DbSet<Projeto> Projetos { get; set; } = null!;
        public DbSet<TipoPessoa> TiposPessoa { get; set; } = null!;
        public DbSet<TipoProjeto> TiposProjeto { get; set; } = null!;
        public DbSet<Empresa> Empresas { get; set; } = null!;
        public DbSet<StatusProjeto> StatusProjetos { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<Cidade> Cidades { get; set; } = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;
        public DbSet<Pessoa> Pessoas { get; set; } = null!;
        public DbSet<PessoaProjeto> PessoaProjetos { get; set; } = null!;
        public DbSet<EnderecoPessoa> EnderecoPessoas { get; set; } = null!;
        public DbSet<Profissao> Profissoes { get; set; } = null!;
        public DevTecContext()
        { }

        public DevTecContext(DbContextOptions<DevTecContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Profissao>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");
                entity.Property(e => e.DataInclusao).HasDefaultValueSql("(getdate())");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}