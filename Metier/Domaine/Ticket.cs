#region Références importées

//using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
// ctrl k s 
namespace Metier.Domaine
{
    public class Ticket
    {
        #region Propriétés
        private int idTicket;
        public Type Type { get; set; }
        public int TypeID { get; set; }
        public string Resume { get; set; }
        public DateTime DateEcheance { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateResolution { get; set; }
        
        public string Description { get; set; }
        
        
        public int TicketID
        {
            get { return this.idTicket; }
            set { this.idTicket = value; }
        }
        // prop (snippet)
       

        /*public decimal Temps { get; set; }
        public decimal TempsJour
        {
            get { return this.Temps / 6; }
        }*/
        #endregion
        public int UtilisateurID { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
       

        public Application Applications { get; set; }
        public int ApplicationID { get; set; }

        public Nullable<int> AssistantID { get; set; }
        public virtual Assistant Assistant { get; set; }
        // public int? AssistantID { get; set; }
       
      
        public int PieceJointeID { get; set; }
        public int HistoriqueID { get; set; }

        public int CommentaireID { get; set; }


       
        public ICollection<Commentaire> Commentaires { get; set; }


        public Categorie Categorie { get; set; }
        public int CategorieID { get; set; }

       /* public Niveau Niveau { get; set; }
        public int NiveauID { get; set; }*/
        public Priorite Priorite { get; set; }
        public int PrioriteID { get; set; }

        public Resolution Resolution { get; set; }
        public int ResolutionID { get; set; }


        public Statut Statut { get; set; }
        public int StatutID { get; set; }

        public Environnement Environnement { get; set; }
        public int EnvironnementID { get; set; }

        public Criticite Criticite { get; set; }
        public int CriticiteID { get; set; }

        public List<PieceJointe> PieceJointes { get; set; }
        public List<Historique> Historiques { get; set; }

        public Ticket()
        {
            this.Commentaires = new List<Commentaire>();

            this.Historiques = new List<Historique>();

            this.PieceJointes = new List<PieceJointe>();

            //  ctrl+v = coller circulaire        public List<PieceJointe> PieceJointes { get; set; }
            // selection rectangulaire =  alt + souris
            // FORMATAGE = ctrl + k +d 

            var ti = new int[5];
            ti[0] = 1;
            ti[1] = 1;
            ti[2] = 1;
            ti[3] = 1;
            ti[0] = 1;
            ti[0] = 1;
            ti[0] = 1;
        }

    }
}
