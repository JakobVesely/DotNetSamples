using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		var tournament = new Tournament();
		var debug = tournament.Users;
	}
}

public class Tournament
{
	public int TournamentId { get; set; }
	public int TournamentName { get; set; }

	public List<User> Users
	{
		get
		{
			return Relations.Select(relation => relation.User).ToList<User>();

			/*
			 * Old way
			 * 
			var users = new List<User>();
			this.Relations.ForEach(x => users.Add(x.User));
			return users;
			*/
		}
	}

	public List<Relation> Relations = new List<Relation>()
	{
		new Relation(new User(1, "Karl")),
		new Relation(new User(2, "Franz"))
	};
}

public class User
{
	public int UserId { get; set; }
	public string UserName { get; set; }


	public User(User user)
	{
		this.UserId = user.UserId;
		this.UserName = user.UserName;
	}

	public User(int id, string name)
	{
		this.UserId = id;
		this.UserName = name;
	}
}

public class Relation
{
	public User User { get; set; }

	public Relation(User u)
	{
		this.User = u;
	}
}