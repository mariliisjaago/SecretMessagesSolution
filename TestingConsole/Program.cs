
using Microsoft.Extensions.Configuration;
using SecretMessages_Library.Contracts.DataAccess;
using SecretMessages_Library.DataAccess;
using SecretMessages_Library.Models;
using SecretMessages_Library.Routines;
using SecretMessages_Library.Services;
using SecretMessages_Library.Utilities;
using System;
using System.Collections.Generic;
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
            MessageService messageService = new MessageService(db);
            //LoginRoutine loginRoutine = new LoginRoutine(userService);


            //Console.WriteLine("Reading a message");
            //Console.Write("username: ");
            //string userName = Console.ReadLine();

            //Console.Write("Your password: ");
            //string password = Console.ReadLine();

            //bool confirmed = userService.CreateUser(userName, password);

            ////(bool, int) confirmed = userService.GetUserIdByUserName(userName);

            //Console.WriteLine($"Signing up result: { confirmed }");
            //Console.ReadLine();


            //MessageRoutine messageRoutine = new MessageRoutine(messageService, userService);

            ////MessageModel message = new MessageModel()
            ////{
            ////    Message = "This is the first message.",
            ////    FromUserId = 1
            ////};

            ////messageRoutine.SendMessage(message, "juusvali");

            //List<MessageFullModel> newMessages = messageRoutine.GetNewMessages(2);

            //foreach (var item in newMessages)
            //{
            //    Console.WriteLine($"To: { item.ToUserId }, from: { item.UserName }");
            //    Console.WriteLine(item.Message);
            //}

            string salt = PasswordCrypto.CreateSaltUsingNowTime();

            Console.WriteLine(salt);

            string hashedPassword = PasswordCrypto.SaltAndHashPassword("kiisud", salt);

            Console.WriteLine(hashedPassword);

        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
