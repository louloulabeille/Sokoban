using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientServeur
{
    public class Serveur : IOGame
    {
        private TcpListener _socket;
        private Thread _threadServeur;

        #region constructeur
        /// <summary>
        /// initialisation du serveur
        /// AddressFamily -> ip v4
        /// SocketType -> flue bi directionnel ne peut être que AddressFamily.InterNetwork et ProtocolType.Tcp
        /// ProtocolType -> type de connexion tcp
        /// </summary>
        public Serveur(int port)
            : base(port)    /// initialisation des paramètres au vert
        {
            _socket = new TcpListener(IPAddress.Any, Port);
            _threadServeur = new Thread(new ThreadStart(ThreadServeurLoop));
            _threadServeur.IsBackground = true;
            this._threadServeur.Start();
        }
        #endregion

        #region méthode du serveur
        private void ThreadServeurLoop()
        {
            try
            {
                this._socket.Start();   // lancement de l'écoute
                byte[] buffer = new byte[1024];
                int nbOctet;
                StringBuilder sB = new StringBuilder();
                bool stop = true;

                while (stop)
                {
                    string message;
                    this.TcpClient = this._socket.AcceptTcpClient(); // attente d'une connexion le traitement s'arrete
                    buffer = Lecture(this.TcpClient, out nbOctet);
                    message = sB.AppendFormat("{0}", Encoding.UTF8.GetString(buffer, 0, nbOctet)).ToString();
                    switch (message)
                    {
                        case "gameReady":
                            if ( !GameReady )
                            {
                                EventGameReady += OnEventGameReady;
                                GameReady = true;
                            } 
                            break;
                        case "stop":
                            stop = !StopAll();
                            break;
                        case "iCopy":
                            break;
                        case "init":

                            Debug.WriteLine("Connexion du client ok.");
                            break;
                    }
                }
            }
            catch (ArgumentNullException aNE)
            {
                Debug.WriteLine("Message: {0}", aNE.Message);
                Debug.WriteLine("Source: {0}", aNE.Source);
            }
            catch (ArgumentOutOfRangeException aOORE)
            {
                Debug.WriteLine("Message: {0}", aOORE.Message);
                Debug.WriteLine("Source: {0}", aOORE.Source);
            }
            catch (SocketException sE)
            {
                Debug.WriteLine($"Message :{sE.Message}\nCode erreur :{sE.ErrorCode}");
                Debug.WriteLine("Source: {0}", sE.Source);
            }
            catch (ObjectDisposedException oDE)
            {
                Debug.WriteLine("Message: {0}", oDE.Message);
                Debug.WriteLine("Source: {0}", oDE.Source);
            }
            catch (NotSupportedException nSE)
            {
                Debug.WriteLine("Message: {0}", nSE.Message);
                Debug.WriteLine("Source: {0}", nSE.Source);
            }
            catch (InvalidOperationException iOE)
            {
                Debug.WriteLine("Message: {0}", iOE.Message);
                Debug.WriteLine("Source: {0}", iOE.Source);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Message: {0}", e.Message);
                Debug.WriteLine("Source: {0}", e.Source);
            }
        }

        protected override bool StopAll()
        {
            this.TcpClient.Close();
            this._socket.Stop();
            return true;
        }

        #endregion
    }
}
