using System;
using System.Collections.Generic;
using System.Text;

namespace Utilitaires
{
    /// <summary>
    /// classe qui sera sérializé pour transfert de données
    /// </summary>
    [Serializable]
    public class GameIOData
    {
        private int _nbDeplacement;
        private int _lvl;

        #region constructeur
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="nbDeplacement"></param>
        /// <param name="lvl"></param>
        public GameIOData(int nbDeplacement, int lvl)
        {
            _nbDeplacement = nbDeplacement;
            _lvl = lvl;
        }
        #endregion

        #region assesseur
        public int NbDeplacement { get => _nbDeplacement; set => _nbDeplacement = value; }
        public int Lvl { get => _lvl; set => _lvl = value; }
        #endregion

        #region méthode hérité de object
        public override string ToString()
        {
            return string.Format("{0};{1}",this._lvl,this._nbDeplacement);
        }
        #endregion
    }
}
