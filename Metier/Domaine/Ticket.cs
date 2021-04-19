﻿#region Références importées

//using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
// ctrl k s 
namespace Metier.Domaine
{
    public class Ticket
    {
        [DefaultValue(Type.Bogue)]
        public Type Type { get; set; }
      
        public string Resume { get; set; }
        public DateTime? DateEcheance { get; set; }
        public DateTime? DateCreation { get; set; }
        
        [Required]
        [StringLength(1000, MinimumLength = 20)]
        [UIHint("MultiLineText")]
        public string Description { get; set; }
        
        
        public int TicketID { get; set; }
        
        // prop (snippet)
       

        /*public decimal Temps { get; set; }
        public decimal TempsJour
        {
            get { return this.Temps / 6; }
        }*/
       
        /*public int UtilisateurID { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }*/
       

        public Application Applications { get; set; }
        public int ApplicationID { get; set; }

        public Nullable<int> AssistantID { get; set; }
        public virtual Assistant Assistant { get; set; }


        [DefaultValue(Priorite.Bas)]
        public  Priorite Priorite { get; set; }

        [DefaultValue(Resolution.Ouvert)]
        public  Resolution Resolution { get; set; }
        [DefaultValue(Statut.Nouveau)]
        public  Statut Statut { get; set; }
        [DefaultValue(Environnement.Developpement)]
        public  Environnement Environnement { get; set; }
        [DefaultValue(Criticite.Bloquante)]
        public  Criticite Criticite { get; set; }
       

        public virtual PieceJointe PieceJointe { get; set; }
        public int? PieceJointeID { get; set; }
        public  ICollection<Historique> Historiques { get; set; }
        public ICollection<Commentaire> Commentaires { get; set; }
       
        public Ticket()
        {
            this.Commentaires = new HashSet<Commentaire>();

            this.Historiques = new HashSet<Historique>();

            DateCreation = DateTime.Now;
            DateEcheance = DateTime.Now;


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
