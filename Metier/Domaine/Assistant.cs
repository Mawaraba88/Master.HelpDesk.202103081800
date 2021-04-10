using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Domaine
{
    public class Assistant:Personne
    {
        /// <summary>
        /// Identifiant de l'assistant
        /// </summary>
        //public int AssistantID { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
