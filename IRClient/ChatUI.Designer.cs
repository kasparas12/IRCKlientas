namespace IRClient
{
    partial class ChatUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nicknameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dialogBox = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sendBox = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.usersBox = new System.Windows.Forms.GroupBox();
            this.usersChannel = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.usersBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.connectButton);
            this.groupBox1.Controls.Add(this.portBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.serverBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nicknameBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(525, 38);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 8;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(451, 38);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(50, 20);
            this.portBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port:";
            // 
            // serverBox
            // 
            this.serverBox.Location = new System.Drawing.Point(279, 38);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(120, 20);
            this.serverBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IRC Server:";
            // 
            // nicknameBox
            // 
            this.nicknameBox.Location = new System.Drawing.Point(104, 38);
            this.nicknameBox.Name = "nicknameBox";
            this.nicknameBox.Size = new System.Drawing.Size(101, 20);
            this.nicknameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nickname:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dialogBox);
            this.groupBox3.Location = new System.Drawing.Point(13, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(626, 292);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dialog:";
            // 
            // dialogBox
            // 
            this.dialogBox.Location = new System.Drawing.Point(9, 19);
            this.dialogBox.Name = "dialogBox";
            this.dialogBox.Size = new System.Drawing.Size(611, 267);
            this.dialogBox.TabIndex = 0;
            this.dialogBox.Text = "";
            this.dialogBox.TextChanged += new System.EventHandler(this.dialogBox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sendBox);
            this.groupBox4.Controls.Add(this.inputBox);
            this.groupBox4.Location = new System.Drawing.Point(13, 403);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(507, 46);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input:";
            // 
            // sendBox
            // 
            this.sendBox.Location = new System.Drawing.Point(426, 12);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(75, 23);
            this.sendBox.TabIndex = 1;
            this.sendBox.Text = "Send";
            this.sendBox.UseVisualStyleBackColor = true;
            this.sendBox.Click += new System.EventHandler(this.sendBox_Click);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(15, 17);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(404, 20);
            this.inputBox.TabIndex = 0;
            this.inputBox.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // usersBox
            // 
            this.usersBox.Controls.Add(this.usersChannel);
            this.usersBox.Location = new System.Drawing.Point(646, 13);
            this.usersBox.Name = "usersBox";
            this.usersBox.Size = new System.Drawing.Size(165, 427);
            this.usersBox.TabIndex = 4;
            this.usersBox.TabStop = false;
            this.usersBox.Text = "Users";
            // 
            // usersChannel
            // 
            this.usersChannel.Location = new System.Drawing.Point(7, 20);
            this.usersChannel.Name = "usersChannel";
            this.usersChannel.Size = new System.Drawing.Size(152, 401);
            this.usersChannel.TabIndex = 0;
            this.usersChannel.Text = "";
            // 
            // ChatUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 461);
            this.Controls.Add(this.usersBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChatUI";
            this.Text = "IRChat";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.usersBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nicknameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox dialogBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button sendBox;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.GroupBox usersBox;
        private System.Windows.Forms.RichTextBox usersChannel;
    }
}

