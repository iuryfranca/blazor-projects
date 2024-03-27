using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services;

public class MultaController
{
    private readonly ContextDB _context;

    public MultaController(ContextDB context)
    {
        _context = context;
    }

    public async Task<List<Multa>> GetMultas()
    {
        return await _context.Multas.Include(m => m.Veiculo).ToListAsync();
    }

    public async Task<ActionResult<Multa>> GetMultaById(int id)
    {
        var multa = await _context
            .Multas.Include(m => m.Veiculo)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (multa == null)
        {
            return new NotFoundResult();
        }
        return multa;
    }

    public async Task<ActionResult<Multa>> CreateMulta(Multa multa)
    {
        try
        {
            _context.Multas.Add(multa);
            await _context.SaveChangesAsync();
            return multa;
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }

    public async Task AddRangeMultas(List<Multa> multas)
    {
        _context.Multas.AddRange(multas);
        await _context.SaveChangesAsync();
    }

    // FilterByValue
    // FilterByDescription
    // FilterByValueAndDescription

    public async Task<List<Multa>> FilterByValue(decimal value, int id)
    {
        return await _context
            .Multas.Where(m => m.ValorMulta >= value && m.IdVeiculo == id)
            .ToListAsync();
    }

    public async Task<List<Multa>> FilterByDescription(string description, int id)
    {
        return await _context
            .Multas.Where(m => m.Descricao.Contains(description) && m.IdVeiculo == id)
            .ToListAsync();
    }

    public async Task<List<Multa>> FilterByValueAndDescription(
        decimal value,
        string description,
        int id
    )
    {
        if (description.Length > 0)
        {
            return await _context
                .Multas.Where(m =>
                    m.ValorMulta == value && m.Descricao.Contains(description) && m.IdVeiculo == id
                )
                .ToListAsync();
        }
        else
        {
            return await _context
                .Multas.Where(m =>
                    m.ValorMulta >= value && m.Descricao.Contains(description) && m.IdVeiculo == id
                )
                .ToListAsync();
        }
    }
}
