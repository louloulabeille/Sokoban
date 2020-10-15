using System;
using System.Runtime.CompilerServices;

namespace Sokoban
{
    public class Caisse : OnEmplacements
    {
        #region Champs privés
        public static int nbMouvement;
        #endregion Champs privés

        #region propriétés 
        public new int X
        {
            get => _x;
            set
            {
                if (this is Caisse && value != _x && value != 0)
                {
                    OnEventMoveCaisse(this, new EventArgs());
                }
                _x = value;
            }
        }

        public new int Y
        {
            get => _y;
            set
            {
                if (this is Caisse && value != _x && value != 0)
                {
                    OnEventMoveCaisse(this, new EventArgs());
                }
                _y = value;
            }
        }

        #endregion propriétés 

        #region Méthode
        #endregion Méthode

        #region Constructeur
        public Caisse(int x, int y) : base(x, y)
        {
            Content = '*';
            OnEmplacement = false;
        }
        #endregion Constructeur

        #region Evenement
        public event EventHandler EventMoveCaisse;

        protected virtual void OnEventMoveCaisse(object sender, EventArgs e)
        {
            EventHandler handler = EventMoveCaisse;
            if (handler != null) handler(sender, e);
        }
        #endregion Evenement

        #region methode de event de comptage du nombre de mouvement des caisses
        public void Elements_EventMoveCaisse(object sender, EventArgs e)
        {
            Caisse.nbMouvement++;
        }
        #endregion
    }


}
