using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services;

public class CargoService
{
    private readonly ContextDB _context;

    public CargoService(ContextDB context)
    {
        _context = context;
    }

    public async Task<List<Cargo>>? GetCargos()
    {
        return await _context.Cargos.ToListAsync();
    }

    public async Task<Cargo>? GetCargoById(int id)
    {
        return await _context.Cargos.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new Exception("Cargo não encontrado");
    }

    public async Task<Cargo>? CreateCandidato(Cargo cargo)
    {
        await _context.Cargos.AddAsync(cargo);
        await _context.SaveChangesAsync();
        return cargo;
    }
}
