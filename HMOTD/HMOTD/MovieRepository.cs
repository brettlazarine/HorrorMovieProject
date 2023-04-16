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
    }
}
