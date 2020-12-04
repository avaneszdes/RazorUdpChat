using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace RazorUdpChat
{
    public sealed partial class Form1 : Form
    {
        private ExTextBox sendTextBox = new ExTextBox();
        private TextBoxPadding _textBoxPadding = new TextBoxPadding();
        private IPEndPoint _remoteIp = new IPEndPoint(IPAddress.Any, 0);

        private UdpClient _senderVideoUDPClient = new UdpClient(),
            _senderTextUDPClient = new UdpClient(),
            _receiverVideoUDPClient,
            _receiverTextUDPClient = null;

        private Point _mouseOffset;
        private bool _isMouseDown = false;
        private TextMessage _textMessageSender, _textMessageReceiver;
        private VideoStream _videoStreamSender, _videoStreamReceiver;
        FilterInfoCollection _videoDevices;
        VideoCaptureDevice _videoSource;

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
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            _textMessageSender.SendMessage();
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


        private int _i = 0;

        private void ConnectButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(changePortToSendTextBox.Text) ||
                string.IsNullOrEmpty(changePortToReceiveTextBox.Text))
            {
                MessageBox.Show("Введите номера портов");
                return;
            }

            if (_i % 2 == 0)
            {
                dropDownPanel.Hide();
                chatTextBox.Location = new Point(3, 32);
                chatTextBox.Show();
                sendTextBox.Location = new Point(3, Height - sendTextBox.Height - 2);
                sendTextBox.Show();
                sendMessageButton.Show();

                _textMessageReceiver = new TextMessage(_receiverTextUDPClient,
                    Int32.Parse(changePortToReceiveTextBox.Text), _remoteIp, chatTextBox);
                _textMessageSender = new TextMessage(_senderTextUDPClient, changePortToSendTextBox, sendTextBox,
                    changeNameTextBox, chatTextBox);
                _videoStreamReceiver =
                    new VideoStream(_receiverVideoUDPClient, changePortToReceiveTextBox, pictureBox1);
                _videoStreamSender = new VideoStream(_videoDevices, _videoSource, _senderVideoUDPClient,
                    changePortToSendTextBox);
                _textMessageReceiver.ReceiveMessage();
                _videoStreamReceiver.ReceiveVideo();
                _i++;
                return;
            }

            _senderTextUDPClient.Dispose();
            _receiverTextUDPClient.Dispose();
            _senderVideoUDPClient.Dispose();
            _receiverVideoUDPClient.Dispose();
        }

        private void DropDownButton_Click(object sender, EventArgs e)
        {
            sendMessageButton.Enabled = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _senderTextUDPClient.Dispose();
            _senderVideoUDPClient.Dispose();
            if (_receiverVideoUDPClient != null)
            {
                _receiverVideoUDPClient.Dispose();
                _receiverTextUDPClient.Dispose();
            }

            if (_videoSource.IsRunning)
            {
                _videoSource.Stop();
            }

            Application.Exit();
        }

        private void VideoStreamButton_Click(object sender, EventArgs e)
        {
            if (Width == 334)
            {
                pictureBox1.Location = new Point(chatTextBox.Width + 6, 32);
                Width = chatTextBox.Width + 3 + pictureBox1.Width + 6;
                _videoStreamSender.SendPicture();
                return;
            }

            _videoSource.Stop();
            Width = 334;
        }
    }
}