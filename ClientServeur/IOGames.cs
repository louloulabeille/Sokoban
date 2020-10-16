using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace ClientServeur
{
    public abstract class IOGame
    {
        private bool _endGame;  // gère la fin du jeux
        private bool _winGame;  // gère si une partie est gagnée
        private bool _deconnexion;  // gère la déconnexion
        private bool _gameReady;
        private bool _initialisation; 
        private bool _wait;
        private int _port;
        
        private TcpClient _tcpClient;

        #region constructeur
        /// <summary>
        /// init de la classe serveur ou clien 
        /// tout est ok
        /// </summary>
        public IOGame()
        {
            EndGame = false;
            WinGame = false;
            Deconnexion = false;
            GameReady = false;
            Wait = false;
        }
        public IOGame(int port)
            : base()
        {
            Port = port;
        }

        #endregion

        #region assesseur
        public bool EndGame
        {
            get => _endGame;
            set
            {
                if (value)
                {
                    OnEventEndGame(this, new EventArgs());  /// faudra modifier le EventArgs() pour passer n'importe quel EventArgs passer par une interface
                }
                _endGame = value;
            }
        }
        public bool WinGame
        {
            get => _winGame;
            set
            {
                if (value)
                {
                    OnEventWinGame(this, new EventArgs());
                }
                _winGame = value;
            }
        }
        public bool Deconnexion
        {
            get => _deconnexion;
            set
            {
                if (value)
                {
                    OnEventDeconnexion(this, new EventArgs());
                }
                _deconnexion = value;
            }
        }

        public bool GameReady
        {
            get => _gameReady;
            set
            {
                if ( value ) OnEventGameReady(this, new EventArgsInitialisation(value));
                _gameReady = value;
            }
        }

        public int Port
        {
            get => _port;
            set
            {
                _port = IsVerifPort(value) ? value : throw (new ArgumentOutOfRangeException("Les ports doivent être compris entre {0} et {1}.", IPEndPoint.MaxPort.ToString(), IPEndPoint.MinPort.ToString()));
            }
        }

        public bool Wait 
        { 
            get => _wait;
            set
            {
                OnEventWait(this, new EventArgs());
                _wait = value;
            }
        }

        public bool Initialisation { get => _initialisation; set => _initialisation = value; }

        public TcpClient TcpClient { get => _tcpClient; set => _tcpClient = value; }
        

        #endregion

        #region methode de vérification
        public bool IsVerifPort(int port)
        {
            return port > IPEndPoint.MinPort && port < IPEndPoint.MaxPort;
        }

        #endregion

        #region event
        public event EventHandler EventEndGame;
        public event EventHandler EventWinGame;
        public event EventHandler EventDeconnexion;
        public event EventHandler EventGameReady;
        public event EventHandler EventWait;
        #endregion

        #region methode des events de lancement
        /// <summary>
        /// creation de EventEndGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnEventEndGame(object sender, EventArgs e)
        {
            EventHandler handler = EventEndGame;
            if (handler != null) handler(sender, e);
        }

        /// <summary>
        /// creation de EventWinGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnEventWinGame(object sender, EventArgs e)
        {
            EventHandler handler = EventWinGame;
            if (handler != null) handler(sender, e);
        }

        /// <summary>
        /// creation de EventDeconnexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnEventDeconnexion(object sender, EventArgs e)
        {
            EventHandler handler = EventDeconnexion;
            if (handler != null) handler(sender, e);
        }

        /// <summary>
        /// event en attente initialisation du jeu quand tout est prêt pour lancer le jeu 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnEventGameReady(object sender, EventArgs e)
        {
            EventHandler hendler = EventGameReady;
            if (hendler != null) hendler(sender, e);
        }

        /// <summary>
        /// mise en attente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnEventWait(object sender, EventArgs e)
        {
            EventHandler hendler = EventWait;
            if (hendler != null) hendler(hendler, e);
        }
        #endregion

        #region methode event

        /// <summary>
        /// Event de gestion si le partie sont prêt a jouer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IOGames_EventGameReady( object sender, EventArgs e)
        {
            if ( GameReady )
            {
                Envoi(TcpClient, MessageReseau.gameReady);
            }
        }

        /// <summary>
        /// Methode de event arret du jeu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IOGames_EventDeconnexion(object sender, EventArgs e)
        {
            if ( Envoi(TcpClient, MessageReseau.stop) )
            {
                StopAll();
            }
            StopAll();
            Deconnexion = false;
        }

        /// <summary>
        /// gestion de event deconnexion ou connexion impossible
        /// on refait 5 tentatives
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IOGames_EventEndGame(object sender, EventArgs e)
        {
            if (Envoi(TcpClient, MessageReseau.stop))
            {
                StopAll();
            }
            StopAll();
        }
        #endregion

        #region methode

        /// <summary>
        /// méthode pour l'arrêt du jeu coté client
        /// </summary>
        protected virtual bool StopAll()
        {
            this.TcpClient.Close();
            return true;
        }

        public void Arret()
        {
            this.EventDeconnexion += IOGames_EventDeconnexion;
            Deconnexion = true;
        }

        /// <summary>
        /// initialisation du lancement du jeu
        /// attente de init
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nbOctet"></param>
        /// <returns></returns>
        protected virtual byte[] Lecture(TcpClient client, out int nbOctet)
        {
            byte[] buffer = new byte[1024];
            NetworkStream nS = client.GetStream();
            nbOctet = 0;
            if (nS.CanRead)
            {
                do
                {
                    nbOctet = nS.Read(buffer, 0, buffer.Length);
                } while (nS.DataAvailable);
            }
            return buffer;
        }

        /// <summary>
        /// méthode à mettre à fin du chargement
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        protected bool Envoi(TcpClient client, MessageReseau message)
        {
            if (client.Connected)
            {
                NetworkStream nS = client.GetStream();
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(message.ToString());
                if (nS.CanWrite)
                {
                    nS.Write(buffer);
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
