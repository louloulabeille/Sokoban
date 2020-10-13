using System;
using System.Net.Sockets;
using System.Threading;

namespace ClientServeur
{
    public class Serveur
    {
        private Socket _socket;
        private Thread _threadServeur;

        /// <summary>
        /// initialisation du serveur
        /// AddressFamily -> ip v4
        /// SocketType -> flue bi directionnel ne peut être que AddressFamily.InterNetwork et ProtocolType.Tcp
        /// ProtocolType -> type de connexion tcp
        /// </summary>
        public Serveur()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _threadServeur = new Thread(new ThreadStart(ThreadServeurLoop));
            //_socket.c
        }

        private void ThreadServeurLoop()
        {
            this._threadServeur.Start();

            while (true)
            {

            }

        }
    }
}
