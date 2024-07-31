using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services;

public class CandidatoService
{
    private readonly ContextDB _context;

    public CandidatoService(ContextDB context)
    {
        _context = context;
    }

    public async Task<List<Candidato>>? GetCandidatos()
    {
        return await _context.Candidatos.ToListAsync();
    }

    public async Task<Candidato>? GetCandidatosById(int id)
    {
        return await _context.Candidatos.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new Exception("Candidato não encontrado");
    }

    public async Task<Candidato> GetCandidatosByCpf(string cpf)
    {
        return await _context.Candidatos.FirstOrDefaultAsync(p => p.Cpf == cpf)
            ?? throw new Exception("Candidato não encontrado");
    }

    public async Task<Candidato>? CreateCandidato(Candidato candidato)
    {
        await _context.Candidatos.AddAsync(candidato);
        await _context.SaveChangesAsync();
        return candidato;
    }
}
