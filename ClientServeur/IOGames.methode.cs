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

        #region methode de vérification
        /// <summary>
        /// vérification si le port est correct
        /// compris entre IPEndPoint.MinPort et IPEndPoint.MaxPort
        /// </summary>
        /// <param name="port"> port d'écoute du serveur ou du client </param>
        /// <returns></returns>
        public bool IsVerifPort(int port)
        {
            return port > IPEndPoint.MinPort && port < IPEndPoint.MaxPort;
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

        /// <summary>
        /// renvoie un booléen pour savoir si la réception des données et ok
        /// </summary>
        /// <returns></returns>
        public bool ChargementData()
        {
            while (this.Donnee == null) { };
            return true;
        }

        /// <summary>
        /// méthode initialisation
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        protected void InitGame(TcpClient client, object donne)
        {
            BinaryFormatter bF = new BinaryFormatter();
            bF.Serialize(client.GetStream(), donne);
        }

        /// <summary>
        /// méthode de réception des donnees
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        protected object InitGameReception(TcpClient client)
        {
            BinaryFormatter bF = new BinaryFormatter();
            return bF.Deserialize(client.GetStream());
        }
        #endregion

    }
}
