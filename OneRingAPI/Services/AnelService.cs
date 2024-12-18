using OneRingAPI.Models;
using OneRingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace OneRingAPI.Services
{
    public class AnelService
    {
        private readonly DataContext _context;

        public AnelService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Anel>> GetAllAsync()
        {
            return await _context.Aneis.ToListAsync();
        }

        public async Task<Anel?> GetByIdAsync(int id)
        {
            return await _context.Aneis.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
