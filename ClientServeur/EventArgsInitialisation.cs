using System;
using System.Collections.Generic;
using System.Text;

namespace ClientServeur
{
    public class EventArgsInitialisation : EventArgs
    {
        /// <summary>
        /// event init sera toujours envoyé
        /// il sert s'il le jeux est prêt et donner les informations au poste
        /// distant et de rester en attente un certains temps
        /// </summary>
        private bool _init;

        public EventArgsInitialisation(bool init)
        {
            Init = init;
        }

        public bool Init { get => _init; set => _init = value; }
    }
}