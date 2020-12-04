using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;

namespace RazorUdpChat
{
    public class VideoStreamManager : IDisposable
    {
        private UdpClient _updClient;
        private readonly IPEndPoint _interlocutorEndpoint;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public VideoStreamManager(IPEndPoint interlocutorEndpoint, IPEndPoint endpointToListen)
        {
            _updClient = new UdpClient(endpointToListen);
            _interlocutorEndpoint = interlocutorEndpoint;
        }
        public void Dispose()
        {
            videoSource?.Stop();

            if(videoSource != null)
            {
                videoSource.NewFrame -= VideoSource_NewFrame;
            }
           
            _updClient?.Dispose();
            _updClient?.Close();

        }

        public void ListenVideoRecieve(Action<Bitmap> onRecievePictures)
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var data = await _updClient.ReceiveAsync();
                    using (var ms = new MemoryStream(data.Buffer))
                    {
                        onRecievePictures(new Bitmap(ms));
                    }
                }

            });
        }

        public async Task SentPicturies()
        {
            await Task.Factory.StartNew(() =>
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            });
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventargs)
        {
            var bmp = (Bitmap)eventargs.Frame.Clone();
            using (var ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Jpeg);
                var bytes = ms.ToArray();
                _updClient.SendAsync(bytes, bytes.Length, _interlocutorEndpoint);
            }
        }
    }
}