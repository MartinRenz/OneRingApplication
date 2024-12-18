using Microsoft.EntityFrameworkCore;
using OneRingAPI.Data;
using OneRingAPI.Enums;
using OneRingAPI.Models;
using OneRingAPI.Models.DTOs;

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
            if (!Enum.IsDefined(typeof(TipoPortador), anel.Tipo))
            {
                throw new InvalidOperationException("O tipo fornecido não é válido.");
            }

            if (!await IsRingAvailable(anel.Tipo))
            {
                throw new InvalidOperationException($"O limite de anéis para o tipo '{anel.Tipo}' foi atingido.");
            }

            _context.Aneis.Add(anel);

            await _context.SaveChangesAsync();

            return anel;
        }

        /// <summary>
        /// Atualiza as informações de um anel no banco de dados.
        /// </summary>
        /// <param name="id">O ID do anel a ser atualizado.</param>
        /// <param name="anel">Dados do anel a serem atualizados.</param>
        public async Task<Anel?> UpdateAsync(int id, UpdateAnelDTO anel)
        {
            var existingAnel = await _context.Aneis.FirstOrDefaultAsync(x => x.Id == id);

            if (existingAnel == null)
            {
                return null;
            }

            // Se o tipo está sendo alterado, verificar o limite
            if (anel.Tipo.HasValue && anel.Tipo.Value != existingAnel.Tipo)
            {
                if (!Enum.IsDefined(typeof(TipoPortador), anel.Tipo))
                {
                    throw new InvalidOperationException("O tipo fornecido não é válido.");
                }

                if (!await IsRingAvailable(anel.Tipo.Value))
                {
                    throw new InvalidOperationException($"O limite de anéis para o tipo '{anel.Tipo.Value}' foi atingido.");
                }
                existingAnel.Tipo = anel.Tipo.Value;
            }

            if (!string.IsNullOrEmpty(anel.Nome))
                existingAnel.Nome = anel.Nome;

            if (!string.IsNullOrEmpty(anel.Poder))
                existingAnel.Poder = anel.Poder;

            if (!string.IsNullOrEmpty(anel.Portador))
                existingAnel.Portador = anel.Portador;

            if (!string.IsNullOrEmpty(anel.ForjadoPor))
                existingAnel.ForjadoPor = anel.ForjadoPor;

            if (!string.IsNullOrEmpty(anel.Imagem))
                existingAnel.Imagem = anel.Imagem;

            await _context.SaveChangesAsync();

            return existingAnel;
        }

        /// <summary>
        /// Deleta um anel pelo ID no banco de dados.
        /// </summary>
        /// <param name="id">ID do anel a ser deletado.</param>
        public async Task<bool> DeleteAsync(int id)
        {
            var anel = await _context.Aneis.FindAsync(id);

            if (anel == null)
            {
                return false;
            }

            _context.Aneis.Remove(anel);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Valida o limite de anéis por tipo do portador.
        /// </summary>
        /// <param name="tipo">Tipo do portador.</param>
        private async Task<bool> IsRingAvailable(TipoPortador tipo)
        {
            int limit = tipo switch
            {
                TipoPortador.Elfo => 3,
                TipoPortador.Anao => 7,
                TipoPortador.Homem => 9,
                TipoPortador.Sauron => 1,
                _ => 0
            };

            int ringTypeCount = await _context.Aneis.CountAsync(a => a.Tipo == tipo);
            return ringTypeCount < limit;
        }
    }
}
