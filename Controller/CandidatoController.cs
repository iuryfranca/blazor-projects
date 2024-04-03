using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Controllers;

public class CandidatoController : Controller
{
    private readonly ContextDB contextDB;

    public CandidatoController(ContextDB contextDB)
    {
        this.contextDB = contextDB;
    }

    public async Task<List<Candidato>> GetCandidatos()
    {
        return await contextDB.Candidatos.Include(c => c.Inscricoes).ToListAsync();
    }
}
