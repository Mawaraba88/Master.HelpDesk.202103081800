#region Références
using Metier.Domaine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                new Statut{StatutID=60,Libelle="Fermé"},
            };


        }
        #endregion
    }
}
