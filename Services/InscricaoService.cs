using AppConcurso.Context;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppConcurso.Services;

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

    public async Task<List<Inscricao>> GetInscricoesByCargoId(int cargoId)
    {
        return await _context.Inscricoes.Where(p => p.CargoId == cargoId).ToListAsync();
    }

    public async Task<Inscricao>? CreateInscricao(Inscricao inscricao)
    {
        await _context.Inscricoes.AddAsync(inscricao);
        await _context.SaveChangesAsync();
        return inscricao;
    }

    public async Task DeleteInscricao(int id)
    {
        var inscricao = await GetInscricaoById(id);
        _context.Inscricoes.Remove(inscricao);
        await _context.SaveChangesAsync();
    }
}
