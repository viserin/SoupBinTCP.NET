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
            Console.WriteLine($"OnConnect ");
            await Task.FromResult(false);
        }

        public async Task OnMessage(byte[] message)
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"OnMessage {message.Length}");
            await Task.FromResult(false);
        }

        public async Task OnLoginAccept(string session, ulong sequenceNumber)
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"OnLoginAccept {session}");
            await Task.FromResult(false);
        }

        public async Task OnLoginReject()
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"OnLoginReject");
            await Task.FromResult(false);
        }

        public async Task OnDisconnect()
        {
            //throw new System.NotImplementedException();
            Console.WriteLine($"OnDisconnect");
            await Task.FromResult(false);
        }

        public Task OnDebug(string message)
        {
            Console.WriteLine($"OnDebug {message}");
            return Task.FromResult(false);
        }

        public Task OnLoginReject(char rejectReasonCode)
        {
            Console.WriteLine($"OnLoginReject {rejectReasonCode}");
            return Task.FromResult(false);
        }
    }
}