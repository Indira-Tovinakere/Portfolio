using Portfolio.Domain;

namespace Domain.Interfaces.IServices
{
    public interface IService
    {
        Task<IEnumerable<Infos>> GetAllAsync();
        Task AddAsync(Infos model);
        Task UpdateAsync(Infos model);
        Task DeleteAsync(int id);
    }
}
