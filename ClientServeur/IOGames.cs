using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Utilitaires;

namespace ClientsServeur
{
    public abstract partial class IOGame
    {
        private bool _endGame;  // gère la fin du jeux
        private bool _winGame;  // gère si une partie est gagnée
        private bool _deconnexion;  // gère la déconnexion
        private bool _gameReady;
        private bool _initialisation;
        private bool _wait;
        private int _port;
        private GameIOData _donnee; // correspond aux données initiale de la partie
        private GameIOData _donneeAffichage;    // correspond aux données de qui sont affiché en fin de partie
        private TcpClient _tcpClient;

        #region constructeur
        /// <summary>
        /// init de la classe serveur ou clien 
        /// tout est ok
        /// </summary>
        public IOGame()
        {
            this._endGame = false;
            this._winGame = false;
            this._deconnexion = false;
            this._gameReady = false;
            this._wait = false;
            this._initialisation = false;
            this.EventDeconnexion += IOGames_EventDeconnexion;
            this.EventEndGame += IOGames_EventEndGame;
            this.EventGameReady += IOGames_EventGameReady;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"> port réseau d'écoute </param>
        public IOGame(int port)
        {
            Port = port;
            this.EventDeconnexion += IOGames_EventDeconnexion;
            this.EventEndGame += IOGames_EventEndGame;
            this.EventGameReady += IOGames_EventGameReady;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"> port réseau d'écoute </param>
        /// <param name="data"> données à envoyer du serveur vers client </param>
        public IOGame(int port, GameIOData data)
        {
            Donnee = data;
            Port = port;
            this.EventDeconnexion += IOGames_EventDeconnexion;
            this.EventEndGame += IOGames_EventEndGame;
            this.EventGameReady += IOGames_EventGameReady;
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
                if ( value ) OnEventGameReady(this, new EventArgs());
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

        public bool Initialisation 
        { 
            get => _initialisation;
            set
            {
                if (!value) OnEventDeconnexion(this, new EventArgs());
                _initialisation = value;
            }
        }

        public TcpClient TcpClient { get => _tcpClient; set => _tcpClient = value; }
        public GameIOData Donnee { get => _donnee; set => _donnee = value; }
        /// <summary>
        /// Attention le get DonneeAffichage
        /// renvoie la valeur et met dans l'object la valeur Null
        /// </summary>
        public GameIOData DonneeAffichage 
        {
            get => _donneeAffichage;
            set => _donneeAffichage = value; }

        #endregion

        #region méthode hérité de object

        /// <summary>
        /// ToString retourne une chaine
        /// de l'état du client ou serveur
        /// this.EndGame, this.WinGame, this.Deconnexion, this.GameReady, this.Initialisation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4}", this.EndGame, this.WinGame, this.Deconnexion, this.GameReady, this.Initialisation);
        }
        #endregion

    }
}
