using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ClientServeur
{
    public abstract class IOGame
    {
        private bool _endGame;  // gère la fin du jeux ou le redémarrage
        private bool _winGame;  // gère si une partie à gagner
        private bool _deconnexion;  // gère la déconnexion
        private bool _initialisation;   // information de l'inititalisation de début de partie pour la syncho
        private int _port;

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
            Initialisation = false;
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

        public bool Initialisation
        {
            get => _initialisation;
            set
            {
                OnEventInitialisation(this, new EventArgsInitialisation(value));
                _initialisation = value;
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
        public event EventHandler EventInitialisation;
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

        protected virtual void OnEventInitialisation(object sender, EventArgs e)
        {
            EventHandler hendler = EventInitialisation;
            if (hendler != null) hendler(sender, e);
        }
        #endregion

    }
}
