using System;

namespace Sokoban
{
    public class Elements
    {
        #region Champs privés

        private int _longueur;
        private int _largeur;


        #endregion Champs privés

        #region propriétés 
        
        public int Largeur { get => _largeur; set => _largeur = value; }
        public int Longueur { get => _longueur; set => _longueur = value; }

        #endregion propriétés 

        #region Méthode
        #endregion Méthode

        #region Constructeur
        public Elements()
        {

        }

        public Elements(int largeur, int longueur)
            : this()
        {
            this.Largeur = largeur;
            this.Longueur = longueur;
            
        }

        #endregion Constructeur


    }


}
