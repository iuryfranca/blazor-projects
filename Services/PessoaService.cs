using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services
{
    public class PessoaService
    {
        private readonly ContextBD _context;

        public PessoaService(ContextBD context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetPessoas()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetPessoa(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task AddPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePessoa(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}
