using System;
namespace HorrorMovieProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var key = "2e5aaec53df627a3c2f12b971432f2ef";
            var movieOfTheDay = HorrorMovieAPI.GetMovieInfo(key);       
            var movieVideo = HorrorMovieAPI.GetVideo(key, movieOfTheDay); //needs adjustment!
            //HorrorMovieAPI.GetVideo(key, movieOfTheDay);
            Console.WriteLine($"Movie id: {movieOfTheDay.id},\n" +
                $"Movie Title: {movieOfTheDay.title},\n" +
                $"Movie Release Date {movieOfTheDay.release_date},\n" +
                $"Movie Poster Path: {movieOfTheDay.poster_path},\n" +
                $"Movie Video Path: {movieVideo}");
        }
    }
}