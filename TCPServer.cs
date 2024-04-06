using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Networking;

class TCPServer{
      const int port = 8080;

      public void Start(){
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

            Socket listener = new Socket(ipAddr.AddressFamily,
                 SocketType.Stream, ProtocolType.Tcp);

            try {
                  listener.Bind(localEndPoint);

                  listener.Listen(10);
                  Console.WriteLine("Waiting for a connection on " + localEndPoint);

                  while(true){
                        AcceptConnection(listener);
                  }
            } 
            catch (Exception ex){
                  Console.WriteLine("Exception occured while setting up connection: " + ex);
            }
      }

      private static void AcceptConnection(Socket listener){
            Socket client = listener.Accept();
            Console.WriteLine("Connected by client:" + client.LocalEndPoint + " to Remote: " + client.RemoteEndPoint);

            NetworkStream stream = client.GetStream();

            byte[] requestBytes = new byte[1024];
            int bytesRead = stream.Read(requestBytes, 0, requestBytes.Length);
      }
}