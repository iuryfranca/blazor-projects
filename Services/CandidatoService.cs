using AppConcurso.Context;
using AppConcurso.Models;
using Microsoft.EntityFrameworkCore;

namespace AppConcurso.Services;

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

    public async Task<Candidato>? GetCandidatoById(int id)
    {
        return await _context.Candidatos.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new Exception("Candidato não encontrado");
    }

    public async Task<Candidato>? GetCandidatosByCpf(string cpf)
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

    public async Task DeleteCandidato(int id)
    {
        var candidato = await GetCandidatoById(id);
        _context.Candidatos.Remove(candidato);
        await _context.SaveChangesAsync();
    }

    public async Task<Candidato> UpdateCandidato(Candidato candidato)
    {
        if (candidato == null)
        {
            throw new ArgumentNullException(nameof(candidato));
        }

        try
        {
            // Verifica se o candidato existe
            bool candidatoExiste = await _context.Candidatos.AnyAsync(c => c.Id == candidato.Id);
            if (!candidatoExiste)
            {
                throw new Exception($"Candidato com ID {candidato.Id} não encontrado");
            }

            // Limpa qualquer entidade já rastreada e atualiza
            _context.ChangeTracker.Clear();
            _context.Candidatos.Update(candidato);
            await _context.SaveChangesAsync();
            
            return candidato;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro detalhado: {ex}");
            throw new Exception($"Erro ao atualizar candidato: {ex.Message}", ex);
        }
    }
}
