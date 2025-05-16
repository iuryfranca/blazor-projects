using AppConcurso.Context;
using AppConcurso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppConcurso.Services;

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

    public async Task<Cargo>? CreateCargo(Cargo cargo)
    {
        await _context.Cargos.AddAsync(cargo);
        await _context.SaveChangesAsync();
        return cargo;
    }

    public async Task DeleteCargo(int id)
    {
        var cargo = await GetCargoById(id);
        _context.Cargos.Remove(cargo);
        await _context.SaveChangesAsync();
    }
}
