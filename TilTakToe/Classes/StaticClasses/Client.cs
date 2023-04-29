using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Controls;

namespace TilTakToe.Classes.StaticClasses
{
    static public class Client
    {
        static private bool TurnOn { get; set; } = false;
        public static TextBlock test;

        static public async void ReceiveInfoAsync(TextBlock ClientReceive)
        {
            if(TurnOn)
            {
               return;
            }
            TurnOn = true;

            test = ClientReceive;

            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(6);

            while (true)
            {
                var listener = await tcpSocket.AcceptAsync();

                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = await listener.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (listener.Available > 0);

                test.Text = data.ToString();

                await listener.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("Success")), SocketFlags.None);

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
    }
}
