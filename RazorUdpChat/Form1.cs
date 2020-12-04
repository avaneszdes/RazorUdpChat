using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace RazorUdpChat
{
    public sealed partial class Form1 : Form
    {
        private ExTextBox sendTextBox = new ExTextBox();
        private TextBoxPadding _textBoxPadding = new TextBoxPadding();
        private Point _mouseOffset;
        private bool _isMouseDown = false;
        private bool isPressVideoButton = false;
        private MessageManager messageManager;
        private VideoStreamManager videoStreamManager;

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sendTextBox);
            sendTextBox.Hint = "Сообщение";
            sendTextBox.HintColor = Color.Black;
            sendTextBox.BackColor = SystemColors.ActiveCaption;
            sendTextBox.BorderStyle = BorderStyle.FixedSingle;
            sendTextBox.Cursor = Cursors.IBeam;
            sendTextBox.TabIndex = 1;
            sendTextBox.Font = new Font(FontFamily.GenericSansSerif, 12f);
            sendTextBox.Multiline = true;
            sendTextBox.Size = new Size(278, 40);
            sendTextBox.TabIndex = 1;
            _textBoxPadding.SetPadding(sendTextBox, new Padding(2, 8, 2, 2));
            chatTextBox.Font = new Font(FontFamily.GenericSansSerif, 12f);
            videoButton.Enabled = false;
            Cursor = Cursors.Arrow;
            Width = 334;
            Height = 538;
            pictureBox1.Location = new Point(chatTextBox.Width + 6, 30);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dropDownPanel.Location = new Point((Width / 2) - (dropDownPanel.Width / 2),
                (Height / 2) - (dropDownPanel.Height / 2));
            chatTextBox.Hide();
            sendTextBox.Hide();
            sendMessageButton.Hide();
        }

        #region Работа с формой

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (messageManager != null)
            {
                messageManager.Dispose();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                          SystemInformation.FrameBorderSize.Height;
                _mouseOffset = new Point(xOffset, yOffset);
                _isMouseDown = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(_mouseOffset.X, _mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = false;
            }
        }

        #endregion

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            chatTextBox.Text += $"Я: {sendTextBox.Text}  {DateTime.Now.Hour}:{DateTime.Now.Minute}\r\n"; ;
            messageManager.SentTextMessage($"{changeNameTextBox.Text}: {sendTextBox.Text}");
        }

        private IPEndPoint[] IncrementNumbersOfPorts(int incrementNumberForPort = 0)
        {
            IPEndPoint[] endpoints = { new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), int.Parse(changePortToReceiveTextBox.Text) + incrementNumberForPort),
            new IPEndPoint(IPAddress.Parse(GetLocalIPAddress()), int.Parse(changePortToSendTextBox.Text) + incrementNumberForPort)};

            return endpoints;
        }
        
        private void ConnectButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(changePortToSendTextBox.Text) ||
                string.IsNullOrEmpty(changePortToReceiveTextBox.Text))
            {
                MessageBox.Show("Введите номера портов");
                return;
            }

            videoButton.Enabled = true;
            dropDownPanel.Hide();
            chatTextBox.Location = new Point(3, 32);
            chatTextBox.Show();
            sendTextBox.Location = new Point(3, Height - sendTextBox.Height - 2);
            sendTextBox.Show();
            sendMessageButton.Show();

            var endpointsForMessages = IncrementNumbersOfPorts();
            messageManager = new MessageManager(endpointsForMessages[0], endpointsForMessages[1]);
            var endpointsForVideo = IncrementNumbersOfPorts(10);
            videoStreamManager = new VideoStreamManager(endpointsForVideo[0], endpointsForVideo[1]);

            messageManager.ListenMessageRecieve((string message) =>
            {
                chatTextBox.Text += message;
                Application.DoEvents();
            });

            videoStreamManager.ListenVideoRecieve((Bitmap picture) =>
            {
                pictureBox1.Image = picture;
            });

        }
        private void DropDownButton_Click(object sender, EventArgs e)
        {
            sendMessageButton.Enabled = true;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (videoStreamManager != null)
            {
                videoStreamManager.Dispose();
                messageManager.Dispose();
            }

            Application.Exit();
        }
        private async void VideoStreamButton_Click(object sender, EventArgs e)
        {
            if (!isPressVideoButton)
            {
                pictureBox1.Location = new Point(chatTextBox.Width + 6, 32);
                Width += 3 + pictureBox1.Width;
                await videoStreamManager.SentPicturies();
                isPressVideoButton = true;
                return;
            }

            videoStreamManager.Dispose();
            Width -= 3 + pictureBox1.Width;
            isPressVideoButton = false;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}