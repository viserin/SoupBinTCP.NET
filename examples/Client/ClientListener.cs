using System;
using System.Threading.Tasks;
using SoupBinTCP.NET;

namespace Client
{
    public class ClientListener : IClientListener
    {
        public async Task OnConnect()
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"cOnConnect ");
            await Task.FromResult(false);
        }

        public async Task OnMessage(byte[] message)
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"cOnMessage {message.Length} : {System.Text.Encoding.UTF8.GetString(message)}");
            await Task.FromResult(false);
        }

        public async Task OnLoginAccept(string session, ulong sequenceNumber)
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"cOnLoginAccept {session}");
            await Task.FromResult(false);
        }

        public async Task OnLoginReject()
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"cOnLoginReject");
            await Task.FromResult(false);
        }

        public async Task OnDisconnect()
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"cOnDisconnect");
            await Task.FromResult(false);
        }

        public Task OnDebug(string message)
        {
            Console.WriteLine($"cOnDebug {message}");
            return Task.FromResult(false);
        }

        public Task OnLoginReject(char rejectReasonCode)
        {
            Console.WriteLine($"cOnLoginReject {rejectReasonCode}");
            return Task.FromResult(false);
        }
    }
}