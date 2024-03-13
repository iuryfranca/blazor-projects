using LearningBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Context
{
    public class ContextBD : DbContext
    {
        public ContextBD(DbContextOptions<ContextBD> options)
            : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
