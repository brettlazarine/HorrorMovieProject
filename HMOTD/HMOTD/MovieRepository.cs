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
            return _conn.QuerySingle<Movies>("SELECT * FROM horrormovies WHERE ID = @id;", new { id });
        }

        public void UpdateMovie(Movies movie)
        {
            _conn.Execute("UPDATE horrormovies SET UserRating = @rating WHERE ID = @id;",
                new
                {   
                    rating = movie.UserRating,
                    id = movie.ID
                });
        }

        public void InsertMovie(Movies movieToInsert)
        {
            _conn.Execute("INSERT INTO horrormovies (Title, Genres, ReleaseDate, ReleaseCountry, MovieRating, ReviewRating, " +
                "RunTime, Plot, Cast, Language, FilmingLocations, Budget, UserRating) VALUES " +
                "(@title, @genres, @releaseDate, @releaseCountry, @movieRating, @reviewRating, @runTime, @plot, @cast, @language, " +
                "@filmingLocations, @budget, @userRating);", 
                new {title = movieToInsert.Title, 
                    genres = movieToInsert.Genres,
                    releaseDate = movieToInsert.ReleaseDate,
                    releaseCountry = movieToInsert.ReleaseCountry,
                    movieRating = movieToInsert.MovieRating,
                    reviewRating = movieToInsert.ReviewRating,
                    runTime = movieToInsert.RunTime,
                    plot = movieToInsert.Plot,
                    cast = movieToInsert.Cast,
                    language = movieToInsert.Language,
                    filmingLocations = movieToInsert.FilmingLocations,
                    budget = movieToInsert.Budget,
                    userRating = movieToInsert.UserRating});
        }

        public void DeleteMovie(Movies movie)
        {
            _conn.Execute("DELETE FROM horrormovies WHERE id = @id;", new { id  = movie.ID });
        }
    }
}
