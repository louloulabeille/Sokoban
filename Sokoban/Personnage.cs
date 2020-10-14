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
        public Personnage(int x, int y) : base(x, y)
        {
            Content = '@';
        }
        #endregion Constructeur

        #region Evenement

        public event EventHandler OnUPchanged;

        private void Update()
        {
            if (Console.ReadKey(true).Key == ConsoleKey.UpArrow)
            {
                OnUPchanged?.Invoke(this, EventArgs.Empty);
            }
        }

       
        #endregion Evenement

    }

}
