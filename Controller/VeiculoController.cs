using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services;

public class VeiculoController
{
    private readonly ContextDB _context;

    public VeiculoController(ContextDB context)
    {
        _context = context;
    }

    public async Task<List<Veiculo>> GetVeiculos()
    {
        return await _context.Veiculos.Include(v => v.Multas).ToListAsync();
    }

    public async Task<ActionResult<Veiculo>> GetVeiculoByPlaca(string placa)
    {
        var veiculo = await _context
            .Veiculos.Include(v => v.Multas)
            .FirstOrDefaultAsync(v => v.Placa == placa);
        if (veiculo == null)
        {
            return new NotFoundResult();
        }
        return veiculo;
    }

    public async Task<ActionResult<Veiculo>> CreateVeiculo(Veiculo veiculo)
    {
        try
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return veiculo;
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult(e.Message);
        }
    }
}
