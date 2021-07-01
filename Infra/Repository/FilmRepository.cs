using Microsoft.EntityFrameworkCore;
using starwars.Infra.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace starwars.Infra.Repository
{
    public interface IFilmRepository : IBaseRepository<Film>
    {
        Task<Film> GetAsync(string id);

        Task<List<Film>> GetAllAsync();
    }

    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        public FilmRepository(AppDbContext context) : base(context)
        {
        }

        public Task<Film> GetAsync(string id)
        {
            return context.Film.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Film>> GetAllAsync()
        {
            return context.Film.ToListAsync();
        }
    }
}
