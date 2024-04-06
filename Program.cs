namespace Networking;

class Program
{
    static void Main(string[] args)
    {
        TCPServer server = new TCPServer();

        server.Start();
    }
}
