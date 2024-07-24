using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services;

public class InscricaoService
{
    private readonly ContextDB _context;

    public InscricaoService(ContextDB context)
    {
        _context = context;
    }

    public async Task UpdateRange(List<Inscricao> inscricoes)
    {
        _context.Inscricoes.UpdateRange(inscricoes);
    }

    public async Task<List<Inscricao>>? GetInscricoes()
    {
        return await _context.Inscricoes.ToListAsync();
    }

    public async Task<Inscricao>? GetInscricaoById(int id)
    {
        return await _context.Inscricoes.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new Exception("Inscrição não encontrada");
    }

    public async Task<Inscricao>? CreateInscricao(Inscricao inscricao)
    {
        await _context.Inscricoes.AddAsync(inscricao);
        await _context.SaveChangesAsync();
        return inscricao;
    }
}
