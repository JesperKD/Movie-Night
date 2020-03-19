using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Movie_Night
{

    public static class DALManager
    {
        private static string cs = @"Data Source=desktop-tjrdgab;Initial Catalog=FilmManager;Integrated Security=True";
        /// <summary>
        /// Makes a list of all the movies in the database
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select movieID, movieTitle, description FROM Movies", connection);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //henter data fra readeren og "caster"
                    //til den rigtige datatype
                    int movieID = (int)rdr["movieID"];
                    string movieTitle = (string)rdr["movieTitle"];
                    string description = (string)rdr["description"];

                    //Opretter et ny film objekt
                    Movie f = new Movie();
                    f.MovieID = movieID;
                    f.MovieTitle = movieTitle;
                    f.Description = description;

                    //tilføjer film til listen
                    movies.Add(f);
                }
            }
            return movies;
        }
        /// <summary>
        /// Makes a list of all the actors in the database
        /// </summary>
        /// <returns></returns>
        public static List<Actor> GetActors()
        {
            List<Actor> actors = new List<Actor>();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select actorID, firstname, lastname FROM Actors", connection);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int actorID = (int)rdr["actorID"];
                    string firstname = (string)rdr["firstname"];
                    string lastname = (string)rdr["lastname"];
                    Actor f = new Actor(firstname, lastname);
                    actors.Add(f);
                }
            }
            return actors;
        }
        /// <summary>
        /// Makes a list of all the genres in the database
        /// </summary>
        /// <returns></returns>
        public static List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT type FROM Genre", connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string type = (string)rdr["type"];
                    Genre f = new Genre(type);
                    genres.Add(f);
                }
            }
            return genres;
        }
        /// <summary>
        /// Makes a list of the movie/movies that fit with the usergiven search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Movie> GetSearch(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select movieID, movieTitle, description FROM Movies WHERE movieTitle LIKE @search", connection);

                //Opretter et objekt der kan indeholde
                //et parameter
                SqlParameter sp = new SqlParameter();

                //angiver et parameternavn
                sp.ParameterName = "@search";

                //tilføjer en værdi til parameteret
                sp.Value = "%" + search + "%";

                //Tilføjer parameteret til command
                cmd.Parameters.Add(sp);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int movieID = (int)rdr["movieID"];
                    string movieTitle = (string)rdr["movieTitle"];
                    string description = (string)rdr["description"];
                    Movie f = new Movie();
                    f.MovieID = movieID;
                    f.MovieTitle = movieTitle;
                    f.Description = description;
                    movies.Add(f);
                }
            }
            return movies;
        }
        /// <summary>
        /// Makes a list of the actor/actors that fit the usergiven search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Actor> GetSearchActors(string search)
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select actorID, firstname, lastname FROM Actors  WHERE firstname LIKE @search", connection);

                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int actorID = (int)rdr["actorID"];
                    string firstname = (string)rdr["firstname"];
                    string lastname = (string)rdr["lastname"];
                    Actor f = new Actor(firstname, lastname);
                    f.FirstName = firstname;
                    f.LastName = lastname;
                    actors.Add(f);
                }
            }
            return actors;
        }
        /// <summary>
        /// Makes a list of the movies with a genre that matches the usergiven search
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Movie> GetByGenre(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select movieID, movieTitle, description FROM Movies WHERE genre LIKE @search", connection);

                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int movieID = (int)rdr["movieID"];
                    string movieTitle = (string)rdr["movieTitle"];
                    string description = (string)rdr["description"];
                    Movie f = new Movie();
                    f.MovieID = movieID;
                    f.MovieTitle = movieTitle;
                    f.Description = description;
                    movies.Add(f);
                }
            }
            return movies;
        }
        /// <summary>
        /// Adds an actor into the database with usergiven data
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Actor InsertActor(Actor a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                //Opretter en forbindelse til databasen
                connection.Open();

                //insert data
                SqlCommand cmd = new SqlCommand
                ("insert into Actors(firstname,lastname) OUTPUT INSERTED.actorID values(@fn,@ln)", connection);

                //tilføjer parametre
                cmd.Parameters.Add(new SqlParameter("@fn", a.FirstName));
                cmd.Parameters.Add(new SqlParameter("@ln", a.LastName));

                int newId = (Int32)cmd.ExecuteScalar();
                //Id sættes ind i a
                a.ActorID = newId;
            }
            return a;
        }
        /// <summary>
        /// Adds a movie into the database with usergiven data
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Movie InsertMovie(Movie a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                //Opretter en forbindelse til databasen
                connection.Open();

                //insert data
                SqlCommand cmd = new SqlCommand("insert into Movies(movieTitle,movieyear,genre,description) OUTPUT INSERTED.movieID values(@mt,@my,@mg,@md)", connection);

                //tilføjer parametre
                cmd.Parameters.Add(new SqlParameter("@mt", a.MovieTitle));
                cmd.Parameters.Add(new SqlParameter("@my", a.MovieYear));
                cmd.Parameters.Add(new SqlParameter("@mg", a.Genre));
                cmd.Parameters.Add(new SqlParameter("@md", a.Description));

                int newId = (Int32)cmd.ExecuteScalar();
                //Id sættes ind i a
                a.MovieID = newId;
            }
            return a;
        }
        /// <summary>
        /// Adds a Genre into the database with usergiven data
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Genre InsertGenre(Genre a)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                //Opretter en forbindelse til databasen
                connection.Open();

                //insert data
                SqlCommand cmd = new SqlCommand
                ("insert into Genre(type) OUTPUT INSERTED.ID values(@ty)", connection);

                //tilføjer parametre
                cmd.Parameters.Add(new SqlParameter("@ty", a.Type));


                int newId = (Int32)cmd.ExecuteScalar();
                //Id sættes ind i a
                a.ID = newId;
            }
            return a;
        }
        /// <summary>
        /// Deletes a movie from the Movies table based on the usergiven movietitle
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Movie> DeleteMovie(string search)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Movies WHERE movieTitle LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int movieID = (int)rdr["movieID"];
                    string movieTitle = (string)rdr["movieTitle"];
                    string description = (string)rdr["description"];
                    Movie f = new Movie();
                    f.MovieID = movieID;
                    f.MovieTitle = movieTitle;
                    f.Description = description;
                    movies.Add(f);
                }
            }
            return movies;
        }
        /// <summary>
        /// Deletes an actor from the Actors table based on the usergiven firstname
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Actor> DeleteActor(string search)
        {
            List<Actor> actors = new List<Actor>();
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Actors WHERE firstname LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int actorID = (int)rdr["actorID"];
                    string firstname = (string)rdr["firstname"];
                    string lastname = (string)rdr["lastname"];
                    Actor f = new Actor(firstname, lastname);
                    f.FirstName = firstname;
                    f.LastName = lastname;
                    actors.Add(f);
                }
            }
            return actors;
        }
        /// <summary>
        /// Deletes a genre from the Genres table based on the usergiven input
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<Genre> DeleteGenre(string search)
        {
            List<Genre> genres = new List<Genre>();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE type FROM Genre WHERE type LIKE @search", connection);
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@search";
                sp.Value = "%" + search + "%";
                cmd.Parameters.Add(sp);
                
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string type = (string)rdr["type"];
                    Genre f = new Genre(type);
                    genres.Add(f);
                }
            }
            return genres;
        }




    }
}
