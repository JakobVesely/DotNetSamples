using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreManyToManyEagerLoading
{
    class DataService
    {
        private readonly Context _context;
        public DataService(Context context)
        {
            _context = context;
        }

        public bool CreateDatabase()
        {
            Console.WriteLine($"CreateDatabase: Start");

            bool created = _context.Database.EnsureCreated();
            Console.WriteLine($"CreateDatabase: {created}");

            return created;
        }

        public User AddUser(string Name)
        {
            Console.WriteLine($"AddUser: {Name}");

            User newUser = new User() { UserName = Name };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public Tournament AddTournament(string Name)
        {
            Console.WriteLine($"AddTournament: {Name}");

            Tournament newTournament = new Tournament() { TournamentName = Name };
            _context.Tournaments.Add(newTournament);
            _context.SaveChanges();
            return newTournament;
        }

        public void AddUserToTournament(User user, Tournament tournament)
        {
            var relation = new UTRelation();
            relation.User = user;
            relation.Tournament = tournament;

            tournament.UTRelations.Add(relation);

            _context.SaveChanges();
        }



        public IEnumerable<User> GetUsers()
        {
            return _context.Users
                .Include(u => u.UTRelations)
                .ThenInclude(ut => ut.Tournament);
        }

        public IEnumerable<Tournament> GetTournaments()
        {
            return _context.Tournaments
                .Include(u => u.UTRelations)
                .ThenInclude(ut => ut.User);
        }


    }
}
