using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Controllers;

public class CargoController : Controller
{
    private readonly ContextDB contextDB;

    public CargoController(ContextDB contextDB)
    {
        this.contextDB = contextDB;
    }

    public async Task<List<Cargo>> GetCargos()
    {
        return await contextDB.Cargos.Include(c => c.Inscricoes).ToListAsync();
    }
}
