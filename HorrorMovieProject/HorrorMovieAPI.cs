﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HorrorMovieProject
{
    public class HorrorMovieAPI
    {
        public static Result GetMovieInfo(string key)
        {
            var client = new HttpClient();
            var count = 0;
            int page;
            var movieOfDay = new Result();
            var date = DateTime.UtcNow.AddHours(-6).ToString("yyyy-MM-dd"); //format today's date to pull for a specific release date
            //Console.WriteLine(date[5..]); //print to screen the date used to specify the desired movie

            Root root = new Root(); //instantiate root to begin processing API, can use in for-loops this way
            var apiURL = $"https://api.themoviedb.org/3/discover/movie?api_key={key}&with_genres=27"; //specify horror genre 27
            var response = client.GetStringAsync(apiURL).Result;
            root = JsonConvert.DeserializeObject<Root>(response); //get initial base values

            movieOfDay.id = root.results[0].id; //initialize movieID with a guaranteed film should no release date match today's date
            movieOfDay.release_date = root.results[0].release_date;
            movieOfDay.vote_average = 0; //set to 0 for later comparison

            //Console.WriteLine(movieID); verify movieID is capturing a film ID value
            for (page = 1; page <= 100; page++)
            {//iterate through multiple pages to find the film with the desired release date
                response = client.GetStringAsync($"https://api.themoviedb.org/3/discover/movie?api_key={key}&with_genres=27&page={page}").Result;
                root = JsonConvert.DeserializeObject<Root>(response);
                foreach (var item in root.results)
                {
                    count++;
                    if (item.release_date == null || item.release_date == "") { continue; } //null/empty string check
                    if (item.release_date[5..] == date[5..] && item.vote_average > movieOfDay.vote_average) //ensure the film released *today* and has a higher voter score than the previous value
                    {
                        movieOfDay.id = item.id;
                        movieOfDay.release_date = item.release_date;
                        movieOfDay.vote_average = item.vote_average;
                        movieOfDay.title = item.title;
                        movieOfDay.overview = item.overview;
                        movieOfDay.poster_path = $"https://image.tmdb.org/t/p/w185{item.poster_path}";
                        movieOfDay.video = item.video;
                    }
                    //Console.WriteLine(item.release_date); //verify the loop is iterating through the pages
                }
            }
            //$"https://api.themoviedb.org/3/movie/{movieOfDay.id}/videos?api_key={key}"

            //Console.WriteLine($"{movieOfDay.id}, {movieOfDay.release_date}, {movieOfDay.vote_average}"); //verify info
            //Console.WriteLine(movieOfDay.video);

            Console.WriteLine($"Number of movies: {count}");

            return movieOfDay;
        }

        public static string GetVideo(string key, Result movie)
        {
            var client = new HttpClient();

            var videoURL = $"https://api.themoviedb.org/3/movie/{movie.id}/videos?api_key={key}&language=en-US";

            //string videoLink = "";

            string youTubeKey = "";

            var response = client.GetStringAsync(videoURL).Result;
            Root root = JsonConvert.DeserializeObject<Root>(response);

            var videos = new List<Result>();

            foreach (var item in root.results)
            {
                Console.WriteLine($"Site: {item.site}");
                Console.WriteLine($"Type: {item.type}");
                Console.WriteLine($"YouTube Key: {item.key}");
                videos.Add(item);
            }
            foreach (var item in videos)
            {
                if (item.site == "YouTube" && item.type == "Trailer")
                {
                    youTubeKey = item.key;
                    return youTubeKey;
                }
            }

            //Original YouTube key collection, no longer working
            //    if (item.site == "YouTube" && item.type == "Trailer")
            //    {
            //        videoLink = $"https://www.youtube.com/watch?v={item.key}";
            //    }
            //    else
            //    {
            //        videoLink = "Not found.";
            //    }
            //}
            return youTubeKey;
            //}
        }
    }
}