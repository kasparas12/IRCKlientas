using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRClient
{
    public partial class ChatUI : Form
    {
        private IRCLogic _l = null;
        public ChatUI()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                _l = new IRCLogic(serverBox.Text, Int32.Parse(portBox.Text));
                _l.StartListening(this.dialogBox, this.connectButton, usersChannel);
                _l.Login(nicknameBox.Text);
            } catch (Exception ex)
            {
                dialogBox.Text += "\n" + ex.Message;
            }
        }

        private void sendBox_Click(object sender, EventArgs e)
        {
            _l.executeCommand(inputBox.Text);
            inputBox.Clear();
        }

        private void dialogBox_TextChanged(object sender, EventArgs e)
        {
            dialogBox.SelectionStart = dialogBox.Text.Length;
            dialogBox.ScrollToCaret();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
