﻿using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SoupBinTCP.NET;
using SoupBinTCP.NET.Messages;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client");

            RunClientAsync().Wait();
        }

        private static async Task RunClientAsync()
        {
            var client = new SoupBinTCP.NET.Client(IPAddress.Parse("127.0.0.1"), 5500, new LoginDetails()
            {
                Password = "password",
                Username = "user"
            }, new ClientListener());

            client.Start();

            string command = Console.ReadLine();
            while (command != "x")
            {
                Message message;
                switch (command)
                {
                    case "d":
                        message = new Debug("debug message!!");
                        break;
                    case "u":
                        message = new UnsequencedData(Encoding.ASCII.GetBytes("unsequenced"));
                        break;
                    case "s":
                        message = new SequencedData(Encoding.ASCII.GetBytes("sequenced"));
                        break;
                    case "l":
                        message = new LoginRequest("user", "password");
                        break;
                    case "h":
                        message = new ClientHeartbeat();
                        break;
                    case "o":
                        message = new LogoutRequest();
                        break;
                    default:
                        message = new Debug("default");
                        break;
                }

                await client.Send(message.Bytes);

                command = Console.ReadLine();
            }

            await Task.FromResult(false);

            client.Shutdown();
        }
    }
}