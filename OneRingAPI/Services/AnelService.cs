using OneRingAPI.Models;
using OneRingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace OneRingAPI.Services
{
    /// <summary>
    /// Responsável pelas operações relacionadas aos anéis.
    /// </summary>
    public class AnelService
    {
        private readonly DataContext _context;

        /// <summary>
        /// Construtor para a service de anéis.
        /// </summary>
        /// <param name="context">Contexto do banco de dados contendo os anéis.</param>
        public AnelService(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os anéis registrados.
        /// </summary>
        public async Task<List<Anel>> GetAllAsync()
        {
            return await _context.Aneis.ToListAsync();
        }

        /// <summary>
        /// Retorna um anel através do ID.
        /// </summary>
        /// <param name="id">O ID do anel que será retornado.</param>
        public async Task<Anel?> GetByIdAsync(int id)
        {
            return await _context.Aneis.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
