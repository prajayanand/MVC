using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

    public class MovieServiceMock : IMovieService
    {
        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            var movies = new List<MovieCardModel>() { 
                new MovieCardModel { Id = 1, PosterUrl = "https://media.licdn.com/dms/image/C4E12AQG0XLL_RbB5WA/article-cover_image-shrink_720_1280/0/1528191623683?e=2147483647&v=beta&t=iqOMnKhi5j5wOa5YsrDSEqrUqv0HI8mjVtpw8Y2skpc",
                    Title = "Inception"
                },
                new MovieCardModel { Id = 2, PosterUrl = "", Title = "Batman" },
                new MovieCardModel { Id = 3, PosterUrl = "", Title = "Superman"} 
                };

            return movies;
        }
    }
       