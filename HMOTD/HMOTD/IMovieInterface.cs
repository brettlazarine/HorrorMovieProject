using HMOTD.Models;

namespace HMOTD
{
    public interface IMovieInterface
    {
        public IEnumerable<Movies> GetAllMovies();
    }
}
