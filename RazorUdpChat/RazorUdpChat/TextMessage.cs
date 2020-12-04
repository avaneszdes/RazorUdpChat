using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RazorUdpChat
{
    public class TextMessage
    {
        private UdpClient _receiver;
        private int _remotePort;
        private IPEndPoint _remoteIp;
        private TextBox _chatTextBox;
        private TextBox _chatTextBox2;
        private UdpClient _client;
        private TextBox _changePortToSendTextBox;
        private TextBox _sendTextBox;
        private TextBox _changeNameTextBox;

        public TextMessage(UdpClient receiver, int remotePort, IPEndPoint remoteIp, TextBox chatTextBox)
        {
            _receiver = receiver;
            _remoteIp = remoteIp;
            _remotePort = remotePort;
            _chatTextBox = chatTextBox;
        }

        public TextMessage(UdpClient client, TextBox changePortToSendTextBox, TextBox sendTextBox,
            TextBox changeNameTextBox, TextBox chatTextBox)
        {
            _client = client;
            _changePortToSendTextBox = changePortToSendTextBox;
            _sendTextBox = sendTextBox;
            _changeNameTextBox = changeNameTextBox;
            _chatTextBox2 = chatTextBox;
        }

        public async void ReceiveMessage()
        {
            try
            {
                _receiver = new UdpClient(_remotePort);

                await Task.Run(() =>
                {
                    while (true)
                    {
                        byte[] data = _receiver.Receive(ref _remoteIp);
                        _chatTextBox.Text += Encoding.UTF8.GetString(data) + $"  {DateTime.Now.Hour}:{DateTime.Now.Minute}\r\n";
                    }
                });
            }
            catch (Exception ex)
            {
                _receiver.Dispose();
                _receiver.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                _receiver.Dispose();
                _receiver.Close();
            }
        }

        public void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(_sendTextBox.Text))
            {
                return;
            }

            try
            {
                _chatTextBox2.Text += $"Я: {_sendTextBox.Text}  {DateTime.Now.Hour}:{DateTime.Now.Minute}\r\n";
                byte[] data = Encoding.UTF8.GetBytes($"{_changeNameTextBox.Text}: {_sendTextBox.Text}");
                _client.Send(data, data.Length, "127.0.0.1", Int32.Parse(_changePortToSendTextBox.Text));
            }
            catch (Exception ex)
            {
                _client.Dispose();
                _client.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}