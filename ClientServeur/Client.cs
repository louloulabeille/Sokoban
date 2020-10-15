using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientServeur
{
    /// <summary>
    /// classe serveur
    /// </summary>
    public class Client : IOGame
    {
        private Thread _threadClient;
        private IPAddress _adresseIP;       // adresse ip du serveur


        #region constructeur
        /// <summary>
        /// intialisation du serveur et lancement
        /// </summary>
        public Client(IPAddress adresseIP, int port)
            : base(port)
        {
            AdresseIP = adresseIP;
            this._threadClient = new Thread(new ThreadStart(Connexion));
            this._threadClient.Start();
        }

        #region assesseur
        public IPAddress AdresseIP { get => _adresseIP; set => _adresseIP = value; }
        #endregion

        #endregion
        /// <summary>
        /// connexion au serveur
        /// </summary>
        private void Connexion()
        {
            this.TcpClient = new TcpClient(AddressFamily.InterNetwork);
            this.TcpClient.Connect(AdresseIP, Port);
            if (this.TcpClient.Connected)
            {
                if (!Envoi(this.TcpClient,MessageReseau.init))
                {
                    StopAll();
                    //throw (new ApplicationException("La connexion vers le serveur est impossible./nDéclaration de la connexion en lecture seule."));
                }
                ThreadClientLoop();
            }
            else
            {
                StopAll();
            }
        }

        /// <summary>
        /// Garder le client connecté au serveur
        /// et passe en attente
        /// </summary>
        private void ThreadClientLoop()
        {
            try
            {
                bool stop = true;
                while (stop)
                {
                    StringBuilder sB = new StringBuilder();
                    byte[] buffer = new byte[1024];
                    int nbOctet;
                    string message;

                    buffer = Lecture(this.TcpClient, out nbOctet);
                    message = sB.AppendFormat("{0}", Encoding.UTF8.GetString(buffer, 0, nbOctet)).ToString();
                    Debug.WriteLine(message);

                    switch(message)
                    {
                        case "gameReady":
                            if ( !GameReady )
                            {
                                EventGameReady += IOGames_EventGameReady;
                                GameReady = true;
                            }
                            break;
                        case "stop":
                            stop = !StopAll();
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

        #region method des event


        #endregion
    }
}
