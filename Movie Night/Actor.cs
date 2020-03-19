using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night
{
    public class Actor
    {
		private int actorID;

		public int ActorID
		{
			get { return actorID; }
			set { actorID = value; }
		}

		private string firstname;

		public string FirstName
		{
			get { return firstname; }
			set { firstname = value; }
		}

		private string lastname;

		public string LastName
		{
			get { return lastname; }
			set { lastname = value; }
		}

		public Actor(string firstname, string lastname)
		{
			this.LastName = lastname;
			this.FirstName = firstname;
		}
		public Actor(int id, string firstname, string lastname)
		 : this(firstname, lastname)
		{
			this.ActorID = actorID;
		}
	}
}
