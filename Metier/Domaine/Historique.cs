using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace Metier.Domaine
{
    public class Historique
    {
        public int HistoriqueID { get; set; }

        public DateTime DateCreation { get; set; }
        public string Libelle { get; set; }

        public Nullable<int> AssistantID { get; set; }
        public virtual Assistant Assistant { get; set; }

        [DefaultValue(Priorite.Bas)]
        public Priorite Priorite { get; set; }

        [DefaultValue(Resolution.Ouvert)]
        public Resolution Resolution { get; set; }
        [DefaultValue(Statut.Nouveau)]
        public Statut Statut { get; set; }
        [DefaultValue(Environnement.Developpement)]
        public Environnement Environnement { get; set; }
        [DefaultValue(Criticite.Bloquante)]
        public Criticite Criticite { get; set; }

        public Ticket Ticket { get; set; }
        public int TicketID { get; set; }

        public virtual PieceJointe PieceJointe { get; set; }
        public int? PieceJointeID { get; set; }
        /*public int UtilisateurID { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }*/

       


        public Historique()
        {
           
        }
    }
}