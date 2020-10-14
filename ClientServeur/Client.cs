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
        private TcpClient _tcpClient;
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
        private void Connexion()
        {
            //this._tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._tcpClient = new TcpClient(AddressFamily.InterNetwork);
            this._tcpClient.Connect(AdresseIP, Port);
            if (this._tcpClient.Connected)
            {
                if (!Initclient()) throw (new ApplicationException("La connexion vers le serveur est impossible./nDéclaration de la connexion en lecture seule."));
            }
            else
            {
                throw (new SocketException());
            }
        }


        private bool Initclient()
        {
            NetworkStream nS = this._tcpClient.GetStream();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(MessageReseau.iCopy.ToString());
            if (nS.CanWrite)
            {
                nS.Write(buffer);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ThreadClientLoop()
        {
            try
            {
                //while (this._threadClient.IsAlive) {
                /*IPAddress localHost = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
                IPEndPoint iPeP = new IPEndPoint(localHost, 0);
                this._tcpClient = new TcpClient(iPeP);*/

                byte[] readBuffer = new byte[1024];
                int nbOctet;
                StringBuilder sB = new StringBuilder();

                while (this._threadClient.IsAlive)
                {
                    //nbOctet = this._tcpClient.Receive(readBuffer);
                    sB.AppendFormat("{0}", Encoding.UTF8.GetString(readBuffer));
                    Debug.WriteLine(sB.ToString());


                }
                Debug.WriteLine(sB.ToString());

                /*
                IPEndPoint iPeP = new IPEndPoint(ip, 8580);
                Debug.WriteLine(iPeP.Address.ToString());
                this._tcpClient = new TcpClient(iPeP);

                NetworkStream nS = this._tcpClient.GetStream();

                if (nS.CanRead)
                {
                    do
                    {
                        nbOctet = nS.Read(readBuffer, 0, readBuffer.Length);
                        sB.AppendFormat("{0}", Encoding.UTF8.GetString(readBuffer, 0, nbOctet));
                    } while (nS.DataAvailable);

                    Debug.WriteLine(sB.ToString());
                }
                else
                {
                    Debug.WriteLine("Impossible de lire sur le NetworkStream.");
                }
                nS.Close();
                this._tcpClient.Close();
                this._threadClient.Abort();
                */

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
    }
}
