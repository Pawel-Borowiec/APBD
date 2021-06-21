using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Data;
using MovieApp.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Server.Services
{
    public interface IMoviesRepository
    {

    }

    public interface IMoviesDbService
    {
        Task<List<Movie>> GetMovies();
        Task AddMovie(Movie movie);
        Task<Movie> GetMovie(int movieId);
    }

    public class MoviesDbService : IMoviesDbService
    {
        private ApplicationDbContext _context;

        public MoviesDbService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMovie(Movie movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public Task<Movie> GetMovie(int movieId)
        {
            return _context.Movies.Where(m => m.Id==movieId).FirstOrDefaultAsync();
        }

        public Task<List<Movie>> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.Title).ToListAsync();
        }
    }
}
