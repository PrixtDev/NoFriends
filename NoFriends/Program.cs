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
        private static bool _block;   
        

        static void Main()
        {
            Console.Title = "NoFriends";
            Console.WriteLine("Choose Your Desired Removal.\n[1] = Remove All Incoming Friends \n[2] = Block All Incoming Friends");

            if (Console.ReadLine() == ("2"))
                _block = true;

            Console.Clear();
            Console.WriteLine("Welcome! Enter token: ");
            DiscordSocketClient client = new DiscordSocketClient();
            client.OnLoggedIn += Client_OnLoggedIn;
            client.Login(Console.ReadLine());
            
            Thread.Sleep(-1);
        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Task.Run(() =>
            {
                Console.Clear();
                Console.WriteLine("Press Enter When Ready");
                Console.ReadLine();
                foreach (var relationship in args.Relationships)
                {
                    if (relationship.Type == RelationshipType.IncomingRequest)
                    {
                        if (_block)
                            relationship.User.Block();
                        else
                            relationship.Remove();
                    }
                        
                    Console.WriteLine("Removed! You May Now Close The Program.");
                }
            });
        }
    }
}
