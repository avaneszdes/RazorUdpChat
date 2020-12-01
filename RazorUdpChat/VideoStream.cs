using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace RazorUdpChat
{
    public class VideoStream : IDisposable
    {
        private UdpClient _receiverVideoUdpClient;
        private TextBox _changePortToReceiveTextBox;
        private PictureBox _pictureBox1;
        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private UdpClient _senderVideoUDPClient;
        private TextBox _changePortToSendTextBox;
        public VideoStream(UdpClient receiverVideoUdpClient, TextBox changePortToReceiveTextBox, PictureBox pictureBox1)
        {
            _receiverVideoUdpClient = receiverVideoUdpClient;
            _changePortToReceiveTextBox = changePortToReceiveTextBox;
            _pictureBox1 = pictureBox1;
        }

        public VideoStream(FilterInfoCollection videoDevices, VideoCaptureDevice videoSource,
            UdpClient senderVideoUdpClient, TextBox changePortToSendTextBox)
        {
            _videoDevices = videoDevices;
            _videoSource = videoSource;
            _senderVideoUDPClient = senderVideoUdpClient;
            _changePortToSendTextBox = changePortToSendTextBox;
        }

        public void Dispose()
        {
            _receiverVideoUdpClient.Dispose();
            _senderVideoUDPClient.Dispose();
        }

        public async Task ReceiveVideo()
        {
            _receiverVideoUdpClient = new UdpClient(int.Parse(_changePortToReceiveTextBox.Text) + 20);
            try
            {
                while (true)
                {
                    var data = await _receiverVideoUdpClient.ReceiveAsync();
                    using (var ms = new MemoryStream(data.Buffer))
                    {
                        _pictureBox1.Image = new Bitmap(ms);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public async void SendPicture()
        {
            await Task.Run(() =>
            {
                try
                {
                    _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
                    _videoSource.NewFrame += VideoSource_NewFrame;
                    _videoSource.Start();
                }
                catch (Exception e)
                {
                    _videoSource.NewFrame -= VideoSource_NewFrame;
                    _videoSource.Stop();
                    MessageBox.Show($"Line 253 => {e}");
                }
            });
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventargs)
        {
            var bmp = new Bitmap(eventargs.Frame);
            try
            {
                using (var ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Jpeg);
                    var bytes = ms.ToArray();
                    _senderVideoUDPClient.Send(bytes, bytes.Length, Dns.GetHostEntry(Dns.GetHostName()).AddressList.
                            FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork ).ToString(),
                        int.Parse(_changePortToSendTextBox.Text) + 20);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());   
            }
        }
    }
}