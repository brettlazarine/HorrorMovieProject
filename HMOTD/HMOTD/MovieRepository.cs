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
    }
}
