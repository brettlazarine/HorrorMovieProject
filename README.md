# HorrorMovieProject
A horror movie console app for horror fans!
Utilizes The Movie Database (TMDb) API, picking out only the films with the Horror genre id.
Iterates through the API, selecting the horror movie that was released on "this" day at some point. (Could even be, literally, today!)
Criteria is set so that the flick with the highest audience rating of the selected films will be chosen as the prime movie on the landing page.
A second API call is sent to TMDb in order to retrieve the trailer for the film, specifically on YouTube.

A small database has also been included in the console app: the 2012-2017 IMDB horror films.
This portion of the program is MVC focused, allowing for the user to view, update, create, and delete items from the MySQL connected database.

The default formatting for the ASP.NET applications has been removed, with custom HTML and CSS created to provide a better aesthetic. 
