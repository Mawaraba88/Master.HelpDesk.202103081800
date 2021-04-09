#region Références importées
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

        public int TicketID
        {
            get { return this.idTicket; }
            set { this.idTicket = value; }
        }
        // prop (snippet)
       

        public decimal Temps { get; set; }
        public decimal TempsJour
        {
            get { return this.Temps / 6; }
        }
        #endregion

        public Utilisateur Utilisateur { get; set; }
        public int UtilisateurID { get; set; }

        public Application Applications { get; set; }
        public int ApplicationID { get; set; }


        public Assistant Assistant { get; set; }
        // public int? AssistantID { get; set; }
        public Nullable<int> AssistantID { get; set; }
      
        public int PieceJointeID { get; set; }
        public int HistoriqueID { get; set; }


        public Type Type { get; set; }
        public int TypeID { get; set; }

        public ICollection<Commentaire> Commentaires { get; set; }


        public Categorie Categorie { get; set; }
        public int CategorieID { get; set; }

        public Niveau Niveau { get; set; }
        public int NiveauID { get; set; }
        public Priorite Priorite { get; set; }
        public int PrioriteID { get; set; }

        public Statut Statut { get; set; }
        public int StatutID { get; set; }

        public Motif Motif { get; set; }
        public int MotifID { get; set; }

        public List<PieceJointe> PieceJointes { get; set; }
        public List<Historique> Historiques { get; set; }

        public Ticket()
        {
            this.Commentaires = new List<Commentaire>();

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
