using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository : EfRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
    }
    public IEnumerable<Movie> GetTop30RevenueMovies()
    {
        var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30);
        return movies;
    }

    public override Movie GetById(int id)
    {
        //use Include method
        var movieDetails = _dbContext.Movies.Include(m => m.Genres).ThenInclude(m => m.Genre).Include(m => m.Trailers).FirstOrDefault(i => i.Id == id);
        return movieDetails;
    }


}