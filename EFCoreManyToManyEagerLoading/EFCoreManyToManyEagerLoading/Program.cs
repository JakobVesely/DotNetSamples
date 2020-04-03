using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreManyToManyEagerLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Console Application");
        
            using var host = Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.AddFilter(level => true);
                })
                .ConfigureServices((context, services) =>
                {
                    string connectionString = "server=(localdb)\\mssqllocaldb;database=EFCoreManyToManyEagerLoading;trusted_connection=true";
                    services.AddTransient<DataService>();
                    services.AddDbContext<Context>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });
                })
                .Build();

            var service = host.Services.GetService<DataService>();

            // 1. Create Database
            service.CreateDatabase();

            // 2. Add Users
            var user1 = service.AddUser("Karl");
            var user2 = service.AddUser("Sepp");

            // 3. Add Tournament
            var tournament = service.AddTournament("My Tournament");

            // 4. Add Users to Tournament
            service.AddUserToTournament(user1, tournament);
            service.AddUserToTournament(user2, tournament);

            // 5. Receive Tournament
            var tournamentsFromDatabase = service.GetTournaments();

            Console.WriteLine("End Console Application");
        }
    }
}