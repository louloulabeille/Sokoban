using Microsoft.VisualBasic;
using System;
using System.Diagnostics;

namespace Sokoban
{
    public class Personnage : Elements
    {
        #region Champs privés


        #endregion Champs privés

        #region propriétés 


        #endregion propriétés 

        #region Méthode
        #endregion Méthode

        #region Constructeur
        
        #endregion Constructeur

        #region Evenement



        public event EventHandler OnZPressed;
        
        
        private void update()
        {
            ConsoleKeyInfo Z = new ConsoleKeyInfo();
            if ( .KeyChar == 'z')
            {
                OnZPressed?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion Evenement
    }

}
