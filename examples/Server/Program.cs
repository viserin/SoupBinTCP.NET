using System;
using System.Threading.Tasks;
using System.Threading.Tasks;
using SoupBinTCP.NET;
using SoupBinTCP.NET.Messages;
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server");

            RunServerAsync().Wait();
        }

        private static async Task RunServerAsync()
        {
            var server = new SoupBinTCP.NET.Server(new ServerListener());
            server.Start();

            string command = "";
            while (command != "x")
            {
                Message message;
                switch (command)
                {
                    case "d":
                        message = new Debug("debug message!!");
                        break;
                    case "e":
                        message = new EndOfSession();
                        break;
                    case "h":
                        message = new ServerHeartbeat();
                        break;
                    default:
                        message = new Debug("default");
                        break;
                }

                command = Console.ReadLine();
            }

            await Task.FromResult(false);

            server.Shutdown();
        }
    }
}