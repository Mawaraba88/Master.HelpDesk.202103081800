#region Références
using Metier.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Metier.Services
{
    public class Liste<T>
    {
        private IList<T> liste = new List<T>();

        
        public Liste()
        {

        }
        public void Ajouter(T element)
        {
            liste.Add(element);
        }

        public IList<T> Get()
        {
            return liste;
        }
    }

    public class ServiceHelpDesk
    {
        private Liste<Profil> profils = new Liste<Profil>();
        public Liste<Profil> Profils { get { return profils; } }

 
        public Profil this[string index]
        {
            get
            {
                return null; 
            }
        }
        public ServiceHelpDesk()
        {
            #region Profils
            Profil profilCollaborateur = new Profil();
            profilCollaborateur.ProfilID = 3;
            profilCollaborateur.Libelle = "Collaborateur";


            profils.Ajouter(new Profil { ProfilID = 1, Libelle = "Administrateur" });
            profils.Ajouter(new Profil { ProfilID = 2, Libelle = "Client" });
            profils.Ajouter(profilCollaborateur);
            #endregion

            

        }
    }


}
