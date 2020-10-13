using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    
    public class Game
    {
        private string _nomDuJoueur;
        private Map _carte;

        public string NomDuJoueur { get => _nomDuJoueur; set => _nomDuJoueur = value; }
        public Map Carte { get => _carte; set => _carte = value; }

        public void Reload()
        {
            throw new NotImplementedException();
        }
    }
}
