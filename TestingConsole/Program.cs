
using Microsoft.Extensions.Configuration;
using SecretMessages_Library.Contracts.DataAccess;
using SecretMessages_Library.DataAccess;
using SecretMessages_Library.Routines;
using SecretMessages_Library.Services;
using System;
using System.IO;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = GetConfiguration();
            ISqlDbAccess db = new SqliteDbAccess(config);
            UserService userService = new UserService(db);
            LoginRoutine loginRoutine = new LoginRoutine(userService);

            Console.WriteLine("Signing in.");
            Console.Write("Your username: ");
            string userName = Console.ReadLine();

            Console.Write("Your password: ");
            string password = Console.ReadLine();

            bool confirmed = loginRoutine.SignIn(userName, password);

            Console.WriteLine(confirmed.ToString());



        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
