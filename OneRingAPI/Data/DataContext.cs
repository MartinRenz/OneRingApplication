using OneRingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace OneRingAPI.Data
{
    /// <summary>
    /// Contexto do banco de dados contendo os anéis.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Representação de anéis no banco de dados.
        /// </summary>
        public DbSet<Anel> Aneis { get; set; }

        /// <summary>
        /// Construtor do contexto de dados.
        /// </summary>
        /// <param name="options">As opções de configuração para o contexto de dados.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
    }
}
