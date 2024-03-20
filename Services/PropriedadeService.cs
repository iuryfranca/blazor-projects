using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services;

public class PropriedadeService
{
    private readonly ContextDB _context;

    public PropriedadeService(ContextDB context)
    {
        _context = context;
    }

    public async Task<Propriedade>? CreatePropriedade(Propriedade propriedade)
    {
        if (propriedade == null)
            return null;

        _context.Propriedades.Add(propriedade);
        await _context.SaveChangesAsync();
        return propriedade;
    }

    public async Task<List<Propriedade>>? CreatePropriedadeList(List<Propriedade> propriedade)
    {
        if (propriedade == null)
            return null;

        await _context.Propriedades.AddRangeAsync(propriedade);
        await _context.SaveChangesAsync();
        return propriedade;
    }
}
