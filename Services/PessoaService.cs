using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningBlazor.Services;

public class PessoaService
{
    private readonly ContextDB _context;

    public PessoaService(ContextDB context)
    {
        _context = context;
    }

    public async Task<List<Pessoa>>? GetAllPessoas()
    {
        var pessoas = _context.Pessoas?.ToList();

        if (pessoas == null)
        {
            return new List<Pessoa>();
        }

        return pessoas;
    }

    public async Task<Pessoa>? GetPessoa(int id)
    {
        var pessoa = _context.Pessoas?.FirstOrDefault(p => p.Id == id);

        if (pessoa == null)
        {
            return new Pessoa();
        }

        return pessoa;
    }

    public async Task<Pessoa>? GetPessoaByCpf(string cpf)
    {
        var pessoa = _context.Pessoas?.FirstOrDefault(p => p.Cpf == cpf);

        if (pessoa == null)
        {
            return new Pessoa();
        }

        return pessoa;
    }

    public async Task<Pessoa>? CreatePessoa(Pessoa pessoa)
    {
        _context.Pessoas?.Add(pessoa);

        return pessoa;
    }
}
