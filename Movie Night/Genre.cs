using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night
{
    public class Genre
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private string type;

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		public Genre (string type)
		{
			this.Type = type;
		}

		public Genre (int id, string type)
		{
			this.ID = id;
		}
			
	}
}
