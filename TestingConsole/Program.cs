
using Microsoft.Extensions.Configuration;
using SecretMessages_Library.Contracts.DataAccess;
using SecretMessages_Library.DataAccess;
using SecretMessages_Library.Routines;
using SecretMessages_Library.Services;
using SecretMessages_Library.Utilities;
using System.IO;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = GetConfiguration();
            ISqlDbAccess db = new SqliteDbAccess(config);
            IPasswordCrypto crypto = new PasswordCrypto();
            SqliteUserService userService = new SqliteUserService(db, crypto);
            SqliteMessageService messageService = new SqliteMessageService(db);
            UserInputValidator validator = new UserInputValidator();
            LoginRoutine loginRoutine = new LoginRoutine(userService, validator);


            //Console.WriteLine("Logging in");
            //Console.Write("username: ");
            //string userName = Console.ReadLine();

            //Console.Write("Your password: ");
            //string password = Console.ReadLine();

            //(bool, int) confirmed = loginRoutine.SignIn(userName, password);

            //Console.WriteLine(confirmed.Item1);

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



        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
