using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieManager.GetMovies();
            MovieManager.GetActors();
            MovieManager.GetGenres();
            MovieManager.AskForMovieSearch();
            MovieManager.GetSearch(Console.ReadLine());
            MovieManager.AskForActorSearch();
            MovieManager.GetSearchActors(Console.ReadLine());
            MovieManager.AskForGenreSearch();
            MovieManager.GetByGenre(Console.ReadLine());
            MovieManager.AskForActorInsert();
            MovieManager.InsertActor(Console.ReadLine(), Console.ReadLine());
            MovieManager.AskForMovieInsert();
            MovieManager.InsertMovie(Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine(), Console.ReadLine());
            MovieManager.AskForGenreInsert();
            MovieManager.InsertGenre(Console.ReadLine());
            MovieManager.AskDeleteMov();
            MovieManager.DeleteMovie(Console.ReadLine());
            MovieManager.AskDeleteAct();
            MovieManager.DeleteActor(Console.ReadLine());
            MovieManager.AskDeleteGenre();
            MovieManager.DeleteGenre(Console.ReadLine());

            Console.ReadKey();
        }
    }
}
