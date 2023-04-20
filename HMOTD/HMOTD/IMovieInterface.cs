using HMOTD.Models;

namespace HMOTD
{
    public interface IMovieInterface
    {
        public IEnumerable<Movies> GetAllMovies();
        public Movies GetMovie(int id);
        public void UpdateMovie(Movies movie);
        public void InsertMovie(Movies movieToInsert);

        public void DeleteMovie(Movies movie);
    }
}
