using PrjProcesso.Models;

namespace PrjProcesso.Repositories.Interfaces
{
    public interface IProcessoRepository
    {
        Task<IEnumerable<Processo>> GetAllAsync();
        Task<Processo> GetByIdAsync(Guid id);
        Task AddAsync(Processo processo);
        void Update(Processo processo);
        Task DeleteAsync(Guid id);
        Task SaveAsync();
    }
}
