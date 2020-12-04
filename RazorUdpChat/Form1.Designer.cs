namespace RazorUdpChat
{
    sealed partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.changePortToReceiveTextBox = new System.Windows.Forms.TextBox();
            this.dropDownButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.changePortToSendTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.changeNameTextBox = new System.Windows.Forms.TextBox();
            this.dropDownPanel = new System.Windows.Forms.Panel();
            this.connectButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.videoButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dropDownPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "№ порта для отправки";
            // 
            // changePortToReceiveTextBox
            // 
            this.changePortToReceiveTextBox.Location = new System.Drawing.Point(30, 64);
            this.changePortToReceiveTextBox.Name = "changePortToReceiveTextBox";
            this.changePortToReceiveTextBox.Size = new System.Drawing.Size(65, 20);
            this.changePortToReceiveTextBox.TabIndex = 3;
            // 
            // dropDownButton
            // 
            this.dropDownButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dropDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.dropDownButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dropDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("dropDownButton.Image")));
            this.dropDownButton.Location = new System.Drawing.Point(3, 2);
            this.dropDownButton.Name = "dropDownButton";
            this.dropDownButton.Size = new System.Drawing.Size(25, 25);
            this.dropDownButton.TabIndex = 0;
            this.dropDownButton.UseVisualStyleBackColor = false;
            this.dropDownButton.Click += new System.EventHandler(this.DropDownButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "№ порта для приема";
            // 
            // changePortToSendTextBox
            // 
            this.changePortToSendTextBox.Location = new System.Drawing.Point(30, 22);
            this.changePortToSendTextBox.Name = "changePortToSendTextBox";
            this.changePortToSendTextBox.Size = new System.Drawing.Size(65, 20);
            this.changePortToSendTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Введите ваш НИК";
            // 
            // changeNameTextBox
            // 
            this.changeNameTextBox.Location = new System.Drawing.Point(30, 110);
            this.changeNameTextBox.Name = "changeNameTextBox";
            this.changeNameTextBox.Size = new System.Drawing.Size(65, 20);
            this.changeNameTextBox.TabIndex = 4;
            // 
            // dropDownPanel
            // 
            this.dropDownPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dropDownPanel.Controls.Add(this.connectButton);
            this.dropDownPanel.Controls.Add(this.changeNameTextBox);
            this.dropDownPanel.Controls.Add(this.label3);
            this.dropDownPanel.Controls.Add(this.changePortToSendTextBox);
            this.dropDownPanel.Controls.Add(this.label2);
            this.dropDownPanel.Controls.Add(this.changePortToReceiveTextBox);
            this.dropDownPanel.Controls.Add(this.label1);
            this.dropDownPanel.Location = new System.Drawing.Point(828, 258);
            this.dropDownPanel.Name = "dropDownPanel";
            this.dropDownPanel.Size = new System.Drawing.Size(136, 277);
            this.dropDownPanel.TabIndex = 5;
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.connectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.connectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Image = ((System.Drawing.Image)(resources.GetObject("connectButton.Image")));
            this.connectButton.Location = new System.Drawing.Point(8, 145);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(119, 48);
            this.connectButton.TabIndex = 11;
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // chatTextBox
            // 
            this.chatTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chatTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatTextBox.Location = new System.Drawing.Point(3, 31);
            this.chatTextBox.Multiline = true;
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(328, 465);
            this.chatTextBox.TabIndex = 10;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sendMessageButton.BackgroundImage")));
            this.sendMessageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.sendMessageButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sendMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendMessageButton.Location = new System.Drawing.Point(279, 495);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(52, 41);
            this.sendMessageButton.TabIndex = 6;
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(889, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 30);
            this.panel1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(47, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 25);
            this.button3.TabIndex = 10;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 32);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // videoButton
            // 
            this.videoButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.videoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.videoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.videoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoButton.Image = ((System.Drawing.Image)(resources.GetObject("videoButton.Image")));
            this.videoButton.Location = new System.Drawing.Point(106, 2);
            this.videoButton.Name = "videoButton";
            this.videoButton.Size = new System.Drawing.Size(33, 25);
            this.videoButton.TabIndex = 8;
            this.videoButton.UseVisualStyleBackColor = false;
            this.videoButton.Click += new System.EventHandler(this.VideoStreamButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(334, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(489, 504);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(965, 538);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.videoButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sendMessageButton);
            this.Controls.Add(this.dropDownPanel);
            this.Controls.Add(this.dropDownButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.dropDownPanel.ResumeLayout(false);
            this.dropDownPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button connectButton;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Button videoButton;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Button sendMessageButton;

        private System.Windows.Forms.TextBox changeNameTextBox;
        private System.Windows.Forms.TextBox changePortToReceiveTextBox;
        private System.Windows.Forms.TextBox changePortToSendTextBox;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.Button dropDownButton;
        private System.Windows.Forms.Panel dropDownPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        #endregion
    }
}