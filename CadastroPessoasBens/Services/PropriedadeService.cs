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

    public async Task<List<Propriedade>>? FilterByValue(double value, int Id)
    {
        // Aqui eu faço a busca por valor, se o valor for maior ou igual ao que a pessoa digitou, ele retorna

        return await _context
            .Propriedades.Where(p => p.Valor >= value && p.IdPessoa == Id)
            .ToListAsync();
    }

    public async Task<List<Propriedade>>? FilterByDescription(string value, int Id)
    {
        // Aqui eu faço a busca por descrição, se a descrição contiver o valor que a pessoa digitou, ele retorna

        return await _context
            .Propriedades.Where(p => p.Descricao.Contains(value) && p.IdPessoa == Id)
            .ToListAsync();
    }

    public async Task<List<Propriedade>>? FilterByValueAndDescription(
        double value,
        string description,
        int Id
    )
    {
        // Aqui eu faço esse if para verificar se a descrição é maior que 0 por conta daquele &&
        // Se a pessoa nao colocar nenhum numero no input de numero, ele nao passa pela validação && "p.Valor >= value && p.Descricao
        // Então eu faço esse if para verificar se a descrição é maior que 0, se for, eu faço a busca com a descrição e o valor
        // Se não, eu faço a busca apenas pelo valor

        if (description.Length > 0)
        {
            return await _context
                .Propriedades.Where(p =>
                    p.Valor >= value && p.Descricao.Contains(description) && p.IdPessoa == Id
                )
                .ToListAsync();
        }
        else
        {
            return await _context
                .Propriedades.Where(p => p.Valor >= value && p.IdPessoa == Id)
                .ToListAsync();
        }
    }
}
