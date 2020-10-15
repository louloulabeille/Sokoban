using System;

namespace Sokoban
{
    public class Caisse : OnEmplacements
    {
        #region Champs privés
        #endregion Champs privés

        #region propriétés 
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
        event EventHandler EventMoveCaisse;


        #endregion Evenement

    }


}
