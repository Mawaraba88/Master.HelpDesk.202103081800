#region Références
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
#endregion

namespace Metier.Domaine
{
    /// <summary>
    /// Gestion des profils utilisateurs
    /// </summary>
   public class Profil
    {
        public int ProfilID { get; set; } 
        public string Libelle { get; set; }
        public bool Actif { get; set; }

        /* public Profil(int id):base()
         {

         }

         public Profil()
         {

         }*/
    }


}
