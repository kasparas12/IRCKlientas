/* Kasparo Taminsko IRC kliento igyvendinimas Kompiuteriu Tinklu 2 laboratorinio darbo atsiskaitymui.
 * VU MIF PS 2 kursas: 2018-04-22
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace IRClient
{
    public class IRCLogic
    {
        // Serverio informacija
        private string _server;
        private int _port;
        private string _nick;
        private string _channel;


        // Stream'ai skaitymui ir rasymui
        private Socket _s = null;
        private NetworkStream _ns = null;
        private StreamReader _sr = null;
        private StreamWriter _sw = null;
        private Thread listener = null;

        // UI langai keitimui
        private RichTextBox _dialog = null;
        private Button _connectButton = null;
        private RichTextBox _users = null;

        public IRCLogic(string server, int port)
        {
            _server = server;
            _port = port;
            _s = ConnectSocket(_server, _port);
            if (!_s.Connected)
            {
                throw new Exception("SOCKET CONNECTION FAILED");
            }
            _ns = new NetworkStream(_s);
            _sr = new StreamReader(_ns);
            _sw = new StreamWriter(_ns);
        }

        // Custom palyginimas pagal vartotojo tipus
        public int UsersComparison(string x, string y) {
        if (x.StartsWith("+") && y.StartsWith("+"))
            {
                return 0;
            } else
            {
                if (x.StartsWith("+") && !y.StartsWith("+"))
                {
                    return 1;
                } else
                {
                    if (!x.StartsWith("+") && !y.StartsWith("+"))
                    {
                        return 0;
                    }
                    else
                    {
                        if (!x.StartsWith("+") && y.StartsWith("+"))
                        {
                            return -1;
                        } else
                        {
                            return 0;
                        }
                    }
                }
            }
        }

        // Berkeley Socket'o pajungimas
        private static Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            hostEntry = Dns.GetHostEntry(server);

            //Randame tinkanti IP formata
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }

        // Naujas, atskiras thread'as, skirtas klausytis ateinanciu is serverio zinuciu
        public void StartListening(RichTextBox dialog, Button connectButton, RichTextBox users)
        {
            _dialog = dialog;
            _users = users;
            _connectButton = connectButton;
            _connectButton.Enabled = false;

            if (listener == null)
            {
                listener = new Thread(receiveFromServer);
                listener.IsBackground = true;
                listener.Start();
            }
            else
            {
                listener.Start();
            }
        }

        // Is zinutes parsinamas komandos pavadinimas
        private static string CommandParser(String[] message)
        {
            if (message[0].Substring(0,1) == ":")
            {
                return message[1];
            } else
            {
                return message[0];
            }
        }

        // Parsinamas prefixas
        private static string PrefixParser(String[] message)
        {
            if (message[0].Substring(0,1) == ":")
            {
                return message[0].Substring(1,message.Length-1);
            }
            else
            {
                return String.Empty;
            }
        }

        // Parsinamas parametru sarasas, jei ju yra
        private static List<string> ParametersParser(String[] message)
        {
            List<string> parameters = new List<string>();

            if (message[0].Substring(0,1) == ":")
            {
                int i;
                for (i=2;i<message.Length;i++)
                {
                    parameters.Add(message[i]);
                }
                return parameters;
            }
            else
            {
                int i;
                for (i = 1; i < message.Length; i++)
                {
                    parameters.Add(message[i]);
                }
                return parameters;
            }
        }

        // Komandos ivykdymas sraute
        public void executeCommand(string cmd)
        {
            if (_s.Connected && _sw != null)
            {
                if (cmd.StartsWith("/"))
                {
                    // Specialus atvejis RIZONO tinklo autentifikavimo servisui
                    if (cmd.Contains("/msg"))
                    {
                        String[] splitMsg = cmd.Split(' ');
                        _sw.Flush();
                        string serviceCommand = String.Format("PRIVMSG " + splitMsg[1] + " :" + splitMsg[2] + " ");
                        for (int i = 3; i < splitMsg.Length; i++)
                        {
                            serviceCommand += splitMsg[i] + " ";
                        }
                        _sw.WriteLine(serviceCommand);
                        _sw.Flush();
                    } else
                    {
                        cmd = cmd.Substring(1, cmd.Length - 1);
                        if (cmd.Split(' ')[0].ToUpper() == "JOIN")
                            _channel = cmd.Split(' ')[1];
                        _sw.Flush();
                        _sw.WriteLine(cmd);
                        _sw.Flush();
                    }
                } else
                {
                    // Rasome zinute, o ne komanda
                    string simpleMessage = String.Format("PRIVMSG " + _channel + " :" + cmd);
                    _sw.Flush();
                    _sw.WriteLine(simpleMessage);
                    _sw.Flush();
                    _dialog.Text += "[YOU: ] " + cmd + "\n";
                }
            }
        }

        // Metodas, kuris klausosi nauju baitu is socketo
        private void receiveFromServer()
        {
            bool termination = false;
            byte[] recv = new byte[1026];

            while (true)
            {
                string resp = String.Empty;

                if (!_s.Connected)
                {
                    break;
                }
                else
                {
                    while (((resp = _sr.ReadLine()) != null))
                    {
                        String[] messages = resp.Split(' ');

                            if (messages[0].Substring(0, 1) == ":")
                            {
                                switch (CommandParser(messages))
                                {

                                    case "PRIVMSG":
                                        IrcMessage(messages,_dialog);
                                        break;
                                    case "NOTICE":
                                    IrcNotice(messages, _dialog);
                                        break;
                                    case "353":
                                    IrcDisplayUsers(messages, _users);
                                        break;
                                    case "PART":
                                    IrcUserLeft(messages, _dialog);
                                        break;
                                    case "QUIT":
                                    IrcUserQuit(messages, _dialog);
                                        break;
                                    case "JOIN":
                                    IrcUserEnter(messages, _dialog);
                                        break;
                                    default: IrcDefault(messages, _dialog);
                                        break;
                                    
                                }
                            }
                            else
                            {
                                if (CommandParser(messages) == "PING")
                                {
                                    IrcPing(messages);
                                }
                                if (CommandParser(messages) == "ERROR")
                                {
                                    IrcError(messages, _dialog);
                                    termination = true;
                                    break;
                                }
                            }
                    }
                }
                if (termination)
                {
                    _connectButton.Enabled = true;
                    break;
                }
                
            }
        }

        public void Login(string nickname)
        {
            _nick = nickname;
            if (_s.Connected)
            {
                executeCommand("/NICK " + nickname);
                executeCommand("/USER " + nickname + " 0 * " + nickname);
            }
        }

 //////////////////////////////// IRC komandu parseriai

        private void IrcPing(String[] messages)
        {
            string PingHash = String.Empty;

            foreach (var par in ParametersParser(messages))
            {
                PingHash += par + " ";
            }
            executeCommand(String.Format("/PONG " + PingHash));
        }

        private void IrcMessage(String[] message, RichTextBox dialog)
        {
            string nick = message[0].Substring(1, message[0].Length-1);
            nick = nick.Substring(0, nick.IndexOf("!"));
            string chatMessage = String.Join(" ", message).Substring(String.Join(" ", message).LastIndexOf(':') + 1, String.Join(" ", message).Length - (String.Join(" ", message).LastIndexOf(':')) - 1);

            dialog.Invoke((MethodInvoker)delegate
           {
               dialog.Text += "[" + nick +" on: " + message[2] + "]: " + chatMessage + "\n";
           });
        }

        private void IrcNotice(String[] message, RichTextBox dialog)
        {
            string server = message[0].Substring(1, message[0].Length-1);
            string text = String.Join(" ", message).Substring(String.Join(" ", message).LastIndexOf(':')+1, String.Join(" ", message).Length - (String.Join(" ", message).LastIndexOf(':'))-1);

            dialog.Invoke((MethodInvoker)delegate
            {
                dialog.Text += "[" + server + "]: " + text + "\n";
            });
        }

        private void IrcDisplayUsers(String[] messages, RichTextBox users)
        {
            int index = String.Join(" ", messages).LastIndexOf(':') + 1;
            string message = String.Join(" ", messages);
            List<string> usersInChannel = message.Substring(index, message.Length - index).Split(' ').ToList();
            usersInChannel.Sort(UsersComparison);
            usersInChannel.Reverse();

            foreach(var user in usersInChannel)
            {
                users.Invoke((MethodInvoker) delegate{
                    users.Text += user + "\n";
                });
            }
        }

        private void IrcDefault(String[] messages, RichTextBox dialog)
        {
            string server = messages[0].Substring(1, messages[0].Length - 1);
            string text = String.Join(" ", messages).Substring(String.Join(" ", messages).LastIndexOf(':') + 1, String.Join(" ", messages).Length - (String.Join(" ", messages).LastIndexOf(':')) - 1);

            dialog.Invoke((MethodInvoker)delegate
            {
                //dialog.Text += "[" + server + "]: " + text + "\n";
                dialog.Text += String.Join(" ", messages) + "\n";
            });
        }

        private void IrcUserLeft(String[] messages, RichTextBox dialog)
        {
            string nick = messages[0].Substring(1, messages[0].Length - 1);
            nick = nick.Substring(0, nick.IndexOf("!"));
            string channel = messages[2];

            dialog.Invoke((MethodInvoker)delegate
            {
                dialog.Text += "[User: " + nick +"]" + " LEFT : " +channel+ " "+"\n";
            });
        }

        private void IrcUserQuit(String[] messages, RichTextBox dialog)
        {
            string nick = messages[0].Substring(1, messages[0].Length - 1);
            nick = nick.Substring(0, nick.IndexOf("!"));
            string reason = String.Join(" ", messages).Substring(String.Join(" ", messages).LastIndexOf(':') + 1, String.Join(" ", messages).Length - (String.Join(" ", messages).LastIndexOf(':')) - 1);

            dialog.Invoke((MethodInvoker)delegate
            {
                dialog.Text += "[User: " + nick + "]" + " QUIT, REASON: " + reason + " " + "\n";
            });
        }

        private void IrcUserEnter(String[] messages, RichTextBox dialog)
        {
            string nick = messages[0].Substring(1, messages[0].Length - 1);
            nick = nick.Substring(0, nick.IndexOf("!"));
            string channel = messages[2];

            dialog.Invoke((MethodInvoker)delegate
            {
                dialog.Text += "[User: " + nick + "]" + " JOINED " + channel + "\n";
            });
        }

        private void IrcError(String[] messages, RichTextBox dialog)
        {
            dialog.Invoke((MethodInvoker)delegate
            {
                dialog.Text += "ERROR: Exiting...\n";
                Thread.Sleep(1000);
                dialog.Clear();
            });
        }
    }
}
