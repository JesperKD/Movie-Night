using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night
{
    public static class MovieManager
    {
        public static bool answerrecieved = false;
        /// <summary>
        /// Prints out all the movies in the Movies table of the database
        /// </summary>
        public static void GetMovies()
        {
            List<Movie> returnedmovies = DALManager.GetMovies();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Movies\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Movie item in returnedmovies)
            {
                Console.WriteLine(item.MovieTitle);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Prints out all the actors in the Actors table of the database
        /// </summary>
        public static void GetActors()
        {
            List<Actor> actors = DALManager.GetActors();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Actors\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Actor item in actors)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Prints out all the genres in the Genre table of the database
        /// </summary>
        public static void GetGenres()
        {
            List<Genre> genres = DALManager.GetGenres();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Genres\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Genre item in genres)
            {
                Console.WriteLine(item.Type);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Asks the user to insert the title of a movie they want to look for in the database
        /// </summary>
        public static void AskForMovieSearch()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter title of movie in list: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Prints out the result of the search on the usergiven movie title
        /// </summary>
        /// <param name="search"></param>
        public static void GetSearch(string search)
        {
            List<Movie> movies = DALManager.GetSearch(search);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Search Result: \n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Movie item in movies)
            {
                Console.WriteLine(item.MovieTitle + " | " + item.Description);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Asks the user to insert the firstname of an actor they want to look for in the database
        /// </summary>
        public static void AskForActorSearch()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Firstname of actor in list: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Prints out the result of the search on the usergiven firstname
        /// </summary>
        /// <param name="search"></param>
        public static void GetSearchActors(string search)
        {
            List<Actor> actors = DALManager.GetSearchActors(search);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Search Result: \n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Actor item in actors)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Asks the user to enter a genre they want to find movies with in the database
        /// </summary>
        public static void AskForGenreSearch()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter genre: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Prints out the result of the search based on the usergiven genre
        /// </summary>
        /// <param name="search"></param>
        public static void GetByGenre(string search)
        {
            List<Movie> movies = DALManager.GetByGenre(search);

            foreach (Movie item in movies)
            {
                Console.WriteLine(item.MovieTitle + " " + item.Description);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// asks for the Firstname and Lastname of an actor the user wants to add to the database
        /// </summary>
        public static void AskForActorInsert()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Firstname and then Lastname of an actor to add him/her to the database");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Inserts the given first and last name as an actor in the database and prints the updated list of actors
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="ln"></param>
        public static void InsertActor(String fn, string ln)
        {
            Actor a = new Actor(fn, ln);
            DALManager.InsertActor(a);
            List<Actor> actors = DALManager.GetActors();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Updated list of Actors\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Actor item in actors)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Ask the user for the needed information to add a new movie to the database
        /// </summary>
        public static void AskForMovieInsert()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Title, Release Year, Genre, and a short description of the movie you want to add to the database");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Inserts the usergiven data into the database as a movie and prints out the updated list of movies
        /// </summary>
        /// <param name="title"></param>
        /// <param name="year"></param>
        /// <param name="genre"></param>
        /// <param name="description"></param>
        public static void InsertMovie(String title, int year, string genre, string description)
        {
            Console.WriteLine();
            Movie a = new Movie(title, year, genre, description);
            DALManager.InsertMovie(a);
            List<Movie> movies = DALManager.GetMovies();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Updated list of Movies\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Movie item in movies)
            {
                Console.WriteLine(item.MovieTitle + " | " + item.Description);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Asks the user to type in a new genre to add to the Genre table in the database
        /// </summary>
        public static void AskForGenreInsert()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the genre you want to add to the database");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Inserts the usergiven genre to the Genre table and prints out the update list of genres
        /// </summary>
        /// <param name="type"></param>
        public static void InsertGenre(String type)
        {
            Console.WriteLine();
            Genre a = new Genre(type);
            DALManager.InsertGenre(a);

            List<Genre> genres = DALManager.GetGenres();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Updated list of Genres\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Genre item in genres)
            {
                Console.WriteLine(item.Type);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Checks the answer from the user
        /// </summary>
        /// <param name="search"></param>
        public static void AskDeleteMov()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Type in the title of the movie you want to delete: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Deletes movie based on usergiven movietitle, if the user wanted to delete a movie
        /// </summary>
        /// <param name="search"></param>
        public static void DeleteMovie(string search)
        {
            if (answerrecieved == true)
            {
                DALManager.DeleteMovie(search);

                List<Movie> returnedmovies = DALManager.GetMovies();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Updated list of Movies\n");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (Movie item in returnedmovies)
                {
                    Console.WriteLine(item.MovieTitle);
                }
                Console.WriteLine();
            }
            else
            {


            }
        }

        /// <summary>
        /// Checks the answer from the user and if they said yes, asks them to type the name of the actor to delete
        /// </summary>
        /// <param name="search"></param>
        public static void AskDeleteAct()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Type in the Firstname of the actor you want to delete: ");
            Console.ForegroundColor = ConsoleColor.White;
            answerrecieved = true;
        }

        /// <summary>
        /// Deletes an actor from the database with the usergiven name and prints out the new full list of actors
        /// </summary>
        /// <param name="search"></param>
        public static void DeleteActor(string search)
        {
            DALManager.DeleteActor(search);

            List<Actor> actors = DALManager.GetActors();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Updated list of Actors\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Actor item in actors)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            Console.WriteLine();

        }

        /// <summary>
        /// Checks the answer from the user and if they said yes will then ask them to type the name of the genre to delete
        /// </summary>
        /// <param name="search"></param>
        public static void AskDeleteGenre()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Type in the mame of the genre you want to delete: ");
            Console.ForegroundColor = ConsoleColor.White;

        }
        /// <summary>
        /// Deletes a genre fitting the usergiven genre name, and then prints out the updates list of genres
        /// </summary>
        /// <param name="search"></param>
        public static void DeleteGenre(string search)
        {
            DALManager.DeleteGenre(search);

            List<Genre> genres = DALManager.GetGenres();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Updated list of Genres\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Genre item in genres)
            {
                Console.WriteLine(item.Type);
            }
            Console.WriteLine();

        }
    }
}



