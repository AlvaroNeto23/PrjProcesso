using Microsoft.EntityFrameworkCore;
using PrjProcesso.Data;
using PrjProcesso.Models;
using PrjProcesso.Repositories.Interfaces;

namespace PrjProcesso.Repositories
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProcessoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Processo>> GetAllAsync()
        {
            return await _context.Processos.ToListAsync();
        }

        public async Task<Processo> GetByIdAsync(Guid id)
        {
            return await _context.Processos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Processo processo)
        {
            await _context.Processos.AddAsync(processo);
        }

        public void Update(Processo processo)
        {
            _context.Processos.Update(processo);
        }

        public async Task DeleteAsync(Guid id)
        {
            var processo = await GetByIdAsync(id);
            if (processo != null)
            {
                _context.Processos.Remove(processo);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
