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
        public override int X
        {
            get => _x;
            set
            {
                if ( value != _x )
                {
                    OnEventMoveCaisse(this, new EventArgs());
                }
                _x = value;
            }
        }
 
        public override int Y
        {
            get => _y;
            set
            {
                if ( value != this._y )
                {
                    OnEventMoveCaisse(this, new EventArgs());
                    //this.EventMoveCaisse += Caisse.Caisse_EventMoveCaisse;
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
            this.EventMoveCaisse += Caisse.Caisse_EventMoveCaisse;
        }
        public Caisse() { }
        #endregion Constructeur

        #region Evenement
        public event EventHandler EventMoveCaisse;

        protected virtual void OnEventMoveCaisse(object sender, EventArgs e)
        {
            EventHandler handler = EventMoveCaisse;
            if (handler != null) handler(sender, e);
        }
        #endregion Evenement

        public static void Caisse_EventMoveCaisse(object sender, EventArgs e)
        {
            Caisse.nbMouvement++;
        }
    }


}
