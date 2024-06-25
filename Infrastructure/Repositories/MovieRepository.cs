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


}