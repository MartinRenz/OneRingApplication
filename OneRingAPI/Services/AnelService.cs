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
        /// Retorna todos os anéis registrados no banco de dados.
        /// </summary>
        public async Task<List<Anel>> GetAllAsync()
        {
            return await _context.Aneis.ToListAsync();
        }

        /// <summary>
        /// Retorna um anel através do ID do banco de dados.
        /// </summary>
        /// <param name="id">O ID do anel que será retornado.</param>
        public async Task<Anel?> GetByIdAsync(int id)
        {
            return await _context.Aneis.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Adiciona um novo anel ao banco de dados.
        /// </summary>
        /// <param name="anel">Anel a ser adicionado.</param>
        public async Task<Anel> CreateAsync(Anel anel)
        {
            _context.Aneis.Add(anel);

            await _context.SaveChangesAsync();

            return anel;
        }
    }
}
