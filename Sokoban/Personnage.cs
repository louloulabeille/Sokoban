using Microsoft.VisualBasic;
using System;
using System.Diagnostics;

namespace Sokoban
{
    public class Personnage : OnEmplacements
    {
        #region Champs privés

        #endregion Champs privés

        #region propriétés 

        #endregion propriétés 

        #region Méthode
        
        #endregion Méthode

        #region Constructeur
        public Personnage(int x, int y) : base(x, y)
        {
            Content = '@';
            OnEmplacement = false;
        }

        public Personnage()
        {

        }
        #endregion Constructeur

        #region Evenement





        #endregion Evenement

    }

}
