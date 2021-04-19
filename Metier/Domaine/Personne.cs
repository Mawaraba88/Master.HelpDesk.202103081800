using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Domaine
{
    public  class Personne
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        //public int Profil { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }


    }
}
