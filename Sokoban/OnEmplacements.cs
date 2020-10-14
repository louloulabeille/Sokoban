using System;
using System.Collections.Generic;
using System.Text;

namespace Sokoban
{
    public abstract class OnEmplacements : Elements
    {
        private bool _onEmplacement;

        public bool OnEmplacement { get => _onEmplacement; set => _onEmplacement = value; }

        protected OnEmplacements(int x, int y) : base(x, y)
        {
        }
        protected OnEmplacements()
        {

        }
    }
}
