﻿using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Domaine
{
    public class Assistant:Personne,IDomaine
    {
        /// <summary>
        /// Identifiant de l'assistant
        /// </summary>
        public int AssistantID
        {
            get => default;
            set
            {

            }
        }
        public Role Role { get; set; }
        public int RoleID { get; set; }
    }
}