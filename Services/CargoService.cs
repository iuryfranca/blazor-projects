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

    public async Task<Cargo> UpdateCargo(Cargo cargo)
    {
        if (cargo == null)
        {
            throw new ArgumentNullException(nameof(cargo));
        }

        try
        {
            bool cargoExiste = await _context.Cargos.AnyAsync(c => c.Id == cargo.Id);
            if (!cargoExiste)
            {
                throw new Exception($"Cargo com ID {cargo.Id} não encontrado");
            }

            _context.ChangeTracker.Clear();
            _context.Cargos.Update(cargo);
            await _context.SaveChangesAsync();
            
            return cargo;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro detalhado: {ex}");
            throw new Exception($"Erro ao atualizar cargo: {ex.Message}", ex);
        }
    }
}
