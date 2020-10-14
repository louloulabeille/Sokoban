﻿using System;

namespace Sokoban
{
    public class Elements
    {
        #region Champs privés

        private int _x;
        private int _y;
        private char _content;
        private bool _isMovable;

        #endregion Champs privés

        #region propriétés 



        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public char Content { get => _content; set => _content = value; }
        public bool IsMovable { get => _isMovable; set => _isMovable = value; }



        #endregion propriétés  

        #region Méthode
        public override string ToString()
        {
            return this.Content.ToString();
        }
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
