using Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Domain;


namespace Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly PortfolioContext _context;
        public Repository(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Infos>> GetAllAsync() // Fix: Correct the return type to 'IEnumerable<Infos>'
        {
            return await _context.Infos.ToListAsync();
        }
        public async Task AddAsync(Infos model) // Fix: Correct the parameter type to 'Infos'
        {
            await _context.Infos.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Infos model) // Fix: Correct the parameter type to 'Infos'
        {
            _context.Infos.Update(model);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var model = await _context.Infos.FindAsync(id);
            if (model != null)
            {
                _context.Infos.Remove(model);
                await _context.SaveChangesAsync();
            }
        }
    }
}
