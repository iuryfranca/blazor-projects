using LearningBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Context;

public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options)
        : base(options) { }

    public DbSet<Pessoa>? Pessoas { get; set; }
    public DbSet<Propriedade>? Propriedades { get; set; }
}
