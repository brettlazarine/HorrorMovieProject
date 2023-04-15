using Dapper;
using HMOTD.Models;
using System.Data;

namespace HMOTD
{
    public class MovieRepository : IMovieInterface
    {
        private readonly IDbConnection _conn;

        public MovieRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Movies> GetAllMovies()
        {
            return _conn.Query<Movies>("SELECT * FROM horrormovies;");
        }

        public Movies GetMovie(int id)
        {
            return _conn.QuerySingle<Movies>("SELECT * FROM horrormovies WHERE ID = @id", new { id });
        }

        public void UpdateMovie(Movies movie)
        {
            _conn.Execute("UPDATE horrormovies SET Title = @title, Genres = @genres, ReleaseDate = @releaseDate, ReleaseCountry = @releaseCountry," +
                "MovieRating = @movieRating, ReviewRating = @reviewRating, RunTime = @runTime, Plot = @plot, Cast = @cast," +
                "Language = @language, FilmingLocations = @filmingLocations, Budget = @budget WHERE ID = @id",
                new
                {
                    title = movie.Title,
                    genres = movie.Genres,
                    releaseDate = movie.ReleaseDate,
                    releaseCountry = movie.ReleaseCountry,
                    movieRating = movie.MovieRating,
                    reviewRating = movie.ReviewRating,
                    runTime = movie.RunTime,
                    plot = movie.Plot,
                    cast = movie.Cast,
                    language = movie.Language,
                    filmingLocations = movie.FilmingLocations,
                    budget = movie.Budget,
                    id = movie.ID
                });
        }
    }
}
