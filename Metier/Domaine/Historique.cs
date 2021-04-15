using System;
using System.Collections.Generic;
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

        public PieceJointe PieceJointe { get; set; }
        public int PieceJointeID { get; set; }

        public Priorite Priorite { get; set; }
        public int PrioriteID { get; set; }

        public Resolution Resolution { get; set; }
        public int ResolutionID { get; set; }

        public Statut Statut { get; set; }
        public int StatutID { get; set; }

        /*public Ticket Ticket { get; set; }
        public int TicketID { get; set; }*/
        public int UtilisateurID { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

        public List<PieceJointe> PieceJointes { get; set; }


        public Historique()
        {
            this.PieceJointes = new List<PieceJointe>();
        }
    }
}