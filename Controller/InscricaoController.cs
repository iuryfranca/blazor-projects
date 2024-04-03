using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Controllers;

public class InscricaoController : Controller
{
    private readonly ContextDB contextDB;

    public InscricaoController(ContextDB contextDB)
    {
        this.contextDB = contextDB;
    }

    public async Task<List<Inscricao>> GetInscricoes()
    {
        return await contextDB
            .Inscricoes.Include(i => i.Cargo)
            .Include(i => i.Candidato)
            .ToListAsync();
    }

    public async Task<Inscricao> GetInscricao(int id)
    {
        return await contextDB
            .Inscricoes.Include(i => i.Cargo)
            .Include(i => i.Candidato)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Inscricao> CreateInscricao(Inscricao inscricao)
    {
        contextDB.Inscricoes.Add(inscricao);
        await contextDB.SaveChangesAsync();
        return inscricao;
    }
}
