#region Références
using Metier.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Metier.Domaine.Type;
#endregion

namespace Metier
{
    /// <summary>
    /// Gestion du service métier
    /// </summary>
    public class Service
    {

        #region Attributs
        private List<Statut> statuts;

        private List<Application> applications;

        private List<Resolution> resolutions;

        private List<Priorite> priorites;

        private List<Type> types;
        #endregion

        #region Propriétés

        #endregion

        #region Initialisations

        /// <summary>
        /// Constructeur 
        /// </summary>
        public Service()
        {
            // constructeur 
            if (true)
            {

            }

            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            // ctrl k+c 
            /*
            //foreach (var item in collection)
            //{

            //}
            */

            while (true)
            {

            }

            // entourer  ctrl k + s 
            try
            {
                bool estVrai = false;
            }
            catch (Exception)
            {

                throw;
            }



        }
        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Retourne une priorité .  
        /// </summary>
        /// <param name="id">ID de la priorité</param>
        public void GetPrioriteByID(int id)
        {

            Personne u = new Utilisateur();
        }

        #endregion

        #region Méthodes privées
        /// <summary>
        /// Initialisations de l'application
        /// </summary>
        public void Initialisations()
        {
            this.statuts = new List<Statut>
            {
                new Statut{StatutID=10,Libelle="Nouveau"},
                new Statut{StatutID=20,Libelle="Ouvert"},
                new Statut{StatutID=30,Libelle="En cours"},
                new Statut{StatutID=40,Libelle="En attente"},
                new Statut{StatutID=50,Libelle="Résolu"},
                new Statut{StatutID=60,Libelle="Fermé"}
            };

            this.applications = new List<Application>
            {
                new Application{ApplicationID=1,Libelle="Windows"},
                new Application{ApplicationID=2,Libelle="Excel"},
                new Application{ApplicationID=3,Libelle="SAP"},
                new Application{ApplicationID=4,Libelle="Catia"},
                new Application{ApplicationID=5,Libelle="Gestion Laboratoire"}
            };

            this.resolutions = new List<Resolution>
            {
                new Resolution{ResolutionID=10,Libelle="Ouvert"},
                new Resolution{ResolutionID=20,Libelle="Résolu"},
                new Resolution{ResolutionID=30,Libelle="Fermé"},
                new Resolution{ResolutionID=40,Libelle="Archivé"}
            };

            this.priorites = new List<Priorite>
            {
                new Priorite{PrioriteID=10,Libelle="Haute"},
                new Priorite{PrioriteID=20,Libelle="Urgent"},
                new Priorite{PrioriteID=30,Libelle="Normal"},
                new Priorite{PrioriteID=40,Libelle="Immediat"},
                new Priorite{PrioriteID=50,Libelle="Bas"}
            };

            this.types = new List<Type>
            {
                new Type{TypeID=10,Libelle="Incident"},
                new Type{TypeID=20,Libelle="Problème"},
                new Type{TypeID=30,Libelle="Mise à jour"},
            };


            
        }
        #endregion
    }
}
