using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RazorUdpChat
{
    public class MessageManager: IDisposable
    {
        private readonly UdpClient _updClient;
        private readonly IPEndPoint _interlocutorEndpoint;

        public MessageManager(IPEndPoint interlocutorEndpoint, IPEndPoint endpointToListen)
        {
            _updClient = new UdpClient(endpointToListen);
            _interlocutorEndpoint = interlocutorEndpoint;
        }

        public void ListenMessageRecieve(Action<string> onRecieve)
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var result = await _updClient.ReceiveAsync();
                    onRecieve(Encoding.UTF8.GetString(result.Buffer) + $" {DateTime.Now.Hour}:{DateTime.Now.Minute}\r\n");
                }
            });
        }

        public void SentTextMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

             byte[] data = Encoding.UTF8.GetBytes(message);
             _updClient.Send(data, data.Length, _interlocutorEndpoint);
        }

        public void Dispose()
        {
            _updClient.Dispose();
            _updClient.Close();
        }
    }
}