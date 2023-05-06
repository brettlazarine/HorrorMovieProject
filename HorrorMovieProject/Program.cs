using Newtonsoft.Json.Linq;
using System;
namespace HorrorMovieProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var key = File.ReadAllText("C:\\TrueCoders\\GitHub\\repos\\HorrorMovieProject\\HorrorMovieProject\\appsettings.json");
            var TMDbKey = JObject.Parse(key).GetValue("TMDbKey").ToString();
            var movieOfTheDay = HorrorMovieAPI.GetMovieInfo(TMDbKey);       
            var movieVideo = HorrorMovieAPI.GetVideo(TMDbKey, movieOfTheDay);
            //HorrorMovieAPI.GetVideo(key, movieOfTheDay);
            Console.WriteLine($"Movie id: {movieOfTheDay.id},\n" +
                $"Movie Title: {movieOfTheDay.title},\n" +
                $"Movie Release Date {movieOfTheDay.release_date},\n" +
                $"Movie Poster Path: {movieOfTheDay.poster_path},\n" +
                $"Movie Video Path: {movieVideo}");
        }
    }
}