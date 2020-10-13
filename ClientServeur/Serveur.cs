using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientServeur
{
    public class Serveur
    {
        private TcpListener _socket;
        private Thread _threadServeur;

        /// <summary>
        /// initialisation du serveur
        /// AddressFamily -> ip v4
        /// SocketType -> flue bi directionnel ne peut être que AddressFamily.InterNetwork et ProtocolType.Tcp
        /// ProtocolType -> type de connexion tcp
        /// </summary>
        public Serveur()
        {
            _socket = new TcpListener(IPAddress.Any, 8580);
            //_threadServeur = new Thread(new ThreadStart(ThreadServeurLoop));
            //this._threadServeur.Start();
            ThreadServeurLoop();
        }

        private void ThreadServeurLoop()
        {
            try
            {
                this._socket.Start();   // lancement de l'écoute
                while (true)
                //while (this._threadServeur.IsAlive)
                {
                    Byte[] buffer = System.Text.Encoding.UTF8.GetBytes("j'aime le poulet.");
                    TcpClient client = this._socket.AcceptTcpClient();

                    NetworkStream nS = client.GetStream();

                    nS.Write(buffer);
                    Debug.WriteLine("Envoie au client");
                }
                //client.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }
    }
}
