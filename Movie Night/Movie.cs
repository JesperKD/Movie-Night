using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night
{
    public class Movie
    {
		private int movieID;

		public int MovieID
		{
			get { return movieID; }
			set { movieID = value; }
		}

		private string movieTitle;

		public string MovieTitle
		{
			get { return movieTitle; }
			set { movieTitle = value; }
		}

		private int movieYear;

		public int MovieYear
		{
			get { return movieYear; }
			set { movieYear = value; }
		}

		private string genre;

		public string Genre
		{
			get { return genre; }
			set { genre = value; }
		}

		private string description;

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public Movie()
		{
			

		}

		public Movie(string movietitle, int movieyear,string genre,string description)
		{
			this.MovieTitle = movietitle;
			this.MovieYear = movieyear;
			this.Genre = genre;
			this.Description = description;
		}
		public Movie(int movieid, string movietitle, int movieyear)
		{
			this.movieID = MovieID;
		}
	}
}
