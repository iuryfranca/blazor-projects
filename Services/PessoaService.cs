using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services;

public class PessoaService
{
    private readonly ContextDB _context;

    public PessoaService(ContextDB context)
    {
        _context = context;
    }

    public async Task<List<Pessoa>>? GetPessoas()
    {
        return await _context.Pessoas.Include(p => p.Propriedades).ToListAsync();
    }

    public async Task<Pessoa>? GetPessoaById(int id)
    {
        return await _context
            .Pessoas.Include(p => p.Propriedades)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pessoa>? GetPessoaByCpf(string cpf)
    {
        return await _context
            .Pessoas.Include(p => p.Propriedades)
            .FirstOrDefaultAsync(p => p.Cpf == cpf);
    }

    public async Task<Pessoa>? CreatePessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();
        return pessoa;
    }
}
