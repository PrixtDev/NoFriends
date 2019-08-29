using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {

        static void Main()
        {
            Console.Title = "NoFriends";
            Console.WriteLine("Choose Your Desired Removal.\n[1] = Remove All Incoming Friends \n[2] = Block All Incoming Friends");
            string type = Console.ReadLine();
            if (type == ("1"))
            {
                Console.Clear();
                Console.WriteLine("Welcome! Enter token:");
                string token = Console.ReadLine();
                DiscordSocketClient client = new DiscordSocketClient();
                client.OnLoggedIn += Client_OnLoggedIn;
                client.Login(token);
                Thread.Sleep(-1);
            }
            if (type == ("2"))
            {
                Console.Clear();
                Console.WriteLine("Welcome! Enter token:");
                string token = Console.ReadLine();
                DiscordSocketClient client = new DiscordSocketClient();
                client.OnLoggedIn += Client_OnLoggedInn;
                client.Login(token);
                Thread.Sleep(-1);
            }

        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.Clear();
            Console.WriteLine("Press Enter When Ready");
            Console.ReadLine();
            foreach (var relationship in args.Relationships)
            {
                if (relationship.Type == RelationshipType.IncomingRequest)
                    relationship.Remove();
                Console.WriteLine("Removed! You May Now Close The Program.");
            }
        }

        private static void Client_OnLoggedInn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.Clear();
            Console.WriteLine("Press Enter When Ready");
            Console.ReadLine();
            foreach (var relationship in args.Relationships)
            {
                if (relationship.Type == RelationshipType.IncomingRequest)
                    relationship.User.Block();
                Console.WriteLine("Blocked! You May Now Close The Program.");
            }
        }

    }
}
