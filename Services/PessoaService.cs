using LearningBlazor.Context;
using LearningBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazor.Services
{
    public class PessoaService
    {
        private readonly ContextBD _context;

        private List<Pessoa> pessoas = new List<Pessoa>();

        public PessoaService(ContextBD context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetPessoas()
        {
            // return await _context.Pessoas.ToListAsync();
            // Retorna a lista em memória em vez de buscar do banco de dados
            return Task.FromResult(pessoas).Result;
        }

        public async Task<Pessoa> GetPessoa(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task AddPessoa(Pessoa pessoa)
        {
            // Garante que cada pessoa tenha um ID único
            if (pessoas.Count > 0)
            {
                pessoa.Id = pessoas.Max(p => p.Id) + 1;
            }
            else
            {
                pessoa.Id = 1;
            }
            
            pessoas.Add(pessoa);
            // _context.Pessoas.Add(pessoa);
            // await _context.SaveChangesAsync();
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            var pessoaIndex = pessoas.FindIndex(p => p.Id == pessoa.Id);
            if (pessoaIndex != -1)
            {
                pessoas[pessoaIndex] = pessoa;
            }
            // _context.Entry(pessoa).State = EntityState.Modified;
            // await _context.SaveChangesAsync();
        }

        public async Task DeletePessoa(int id)
        {
            var pessoaIndex = pessoas.FindIndex(p => p.Id == id);
            if (pessoaIndex != -1)
            {
                pessoas.RemoveAt(pessoaIndex);
            }
            // _context.Pessoas.Remove(pessoa);
            // await _context.SaveChangesAsync();
        }
    }
}
