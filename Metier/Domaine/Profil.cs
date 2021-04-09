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
        public int IDProfil;
        public string Libelle;
        public bool Actif;

        public Profil(int id):base()
        {
           
        }

        public Profil()
        {
            
        }
    }


}
