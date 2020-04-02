using System;
using System.Net;

namespace SocketCom
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args[0] == "server")
            {
                TCPServer server = new TCPServer("127.0.0.1", 8080, true);
                server.Listen();
            } else if(args[0] == "client")
            {

                TCPCliente cliente = new TCPCliente();
                IPAddress a = IPAddress.Parse("127.0.0.1");
                cliente.conectarConServidor(a, 8080);

                while(true){
                    cliente.EnviarMensajeAServidor();
                    cliente.LeerMensajeDelServidor();
                }
            }
        }
    }
}