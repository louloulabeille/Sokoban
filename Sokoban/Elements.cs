using System;

namespace Sokoban
{
    public class Elements 
    {
        #region Champs privés

        protected int _x;
        protected int _y;
        private char _content;
        private bool _isMovable;

        #endregion Champs privés

        #region propriétés 

        public virtual int X
        { 
            get => _x;
            set
            {
                _x = value;
            }
        }
        public virtual int Y { get => _y; set => _y = value; }
        public char Content { get => _content; set => _content = value; }
        public bool IsMovable { get => _isMovable; set => _isMovable = value; }



        #endregion propriétés
        //dd
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
            Content = ' ';
        }
        #endregion Constructeur
        #region event
        #endregion

        

    }


}
