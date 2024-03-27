using LearningBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Context;

public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options)
        : base(options) { }

    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Multa> Multas { get; set; }
}
