using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TilTakToe.Classes.StaticClasses.Web
{
    public static class Server
    {
        public static async void SendMessageAsync(int port, string ip ,string message )
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var data = Encoding.UTF8.GetBytes(message);
            
            try
            {
                await tcpSocket.ConnectAsync(tcpEndPoint);
                await tcpSocket.SendAsync(data, SocketFlags.None);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();
            }
            catch(Exception)
            {
            }
        }

        public static void InitializeSocket(ref Socket socket, int port, string ip)
        {
            var EndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(EndPoint);
            socket.Listen(6);
        }
    }
}
