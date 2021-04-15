using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Domaine
{
  public  class Utilisateur : Personne 
    {
        //public int UtilisateurID { get; set; }

       public  Profil Profil { get; set; }
        public int ProfilID { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
