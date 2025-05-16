using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;

namespace AppConcurso.Context;

public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options)
        : base(options) { }

    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Cargo> Cargos { get; set; }

    public DbSet<Inscricao> Inscricoes { get; set; }
}
