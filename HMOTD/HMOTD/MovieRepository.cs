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
            _conn.Execute("UPDATE horrormovies SET ModsHaveSeen = @oneOrTwo WHERE ID = @id",
                new
                {   
                    oneOrTwo = movie.ModsHaveSeen,
                    id = movie.ID
                });
        }

        public void InsertMovie(Movies movieToInsert)
        {
            _conn.Execute("INSERT INTO horrormovies (Title, Genres, ReleaseDate, ReleaseCountry, MovieRating, ReviewRating, " +
                "RunTime, Plot, Cast, Language, FilmingLocations, Budget, ModsHaveSeen) VALUES " +
                "(@title, @genres, @releaseDate, @releaseCountry, @movieRating, @reviewRating, @runTime, @plot, @cast, @language, " +
                "@filmingLocations, @budget, @modsHaveSeen);", 
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
                    modsHaveSeen = movieToInsert.ModsHaveSeen});
        }
    }
}
