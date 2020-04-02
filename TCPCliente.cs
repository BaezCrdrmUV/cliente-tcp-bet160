using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace SocketCom
{
    public class TCPCliente
    {
        private TcpClient cliente;
        private Stream stream;

        public TCPCliente(){
            cliente = new TcpClient();
        }

        public void conectarConServidor(IPAddress direccion, int puerto){
                 cliente.Connect(direccion, puerto);
                 Console.WriteLine("Conectado al servidor");
        }

        public void EnviarMensajeAServidor(){

            Console.WriteLine("Escriba el mensaje que quiere mandar al servidor");
            String mensaje =Console.ReadLine();

            stream = cliente.GetStream();

            byte[] datosAEnviar = Encoding.UTF8.GetBytes(mensaje);

            stream.Write(datosAEnviar,0,datosAEnviar.Length);
        }

        public void LeerMensajeDelServidor(){

            byte[] datosRecibidos = new byte[1024];

            int k = stream.Read(datosRecibidos,0,1024);
            
            for (int i=0;i<k;i++)
                Console.Write(Convert.ToChar(datosRecibidos[i]));

            Console.WriteLine("");
        }
    }
}