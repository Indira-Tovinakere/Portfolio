using Portfolio.Domain;

namespace Domain.Interfaces.IRepository
{
    public interface IRepository
    {
        Task<IEnumerable<Infos>> GetAllAsync();
       Task AddAsync(Infos model);
        Task UpdateAsync(Infos model);
        Task DeleteAsync(int id);
    }
}
