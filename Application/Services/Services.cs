using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Portfolio.Domain;
namespace Application.Services
{
    public class Services : IService
    {
        private readonly IRepository _repository;
        public Services(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Infos>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task AddAsync(Infos model)
        {
            await _repository.AddAsync(model);
        }
        public async Task UpdateAsync(Infos model)
        {
            await _repository.UpdateAsync(model);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
