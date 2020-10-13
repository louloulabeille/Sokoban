using System;

namespace Sokoban
{
    public class Elements
    {
        #region Champs privés

        private int _x;
        private int _y;


        #endregion Champs privés

        #region propriétés 



        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }



        #endregion propriétés 

        #region Méthode
        #endregion Méthode

        #region Constructeur
        public Elements()
        {

        }

        public Elements(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        #endregion Constructeur


    }


}
