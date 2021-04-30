using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Domaine
{
    /// <summary>
    /// Classe de gestion des rôles
    /// </summary>
    public class Role
    {

        #region Propriétés
        public int RoleID { get; set; }
        public string Titre { get; set; }
        public virtual List<Personne> Personnes { get; set; }

        #endregion

        //public int Encours() { return -1; }
    }


    public class Commentaire
    {
        public int CommentaireID { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 20)]
        [UIHint("MultiLineText")]
        public string Contenu { get; set; }

       /* public virtual Assistant Assistant {get; set; }
        public int AssistantID { get; set; }*/

        /*public virtual Utilisateur Utilisateur { get; set; }

        public int UtilisateurID { get; set; }*/
        public string AuteurId { get; set; }
        public virtual Personne Auteur { get; set; }


        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

       
    }

    public enum Criticite
    {
       Aucune = 0,
       Bloquante = 1,
       Majeure = 2,
       Mineure = 3
    }



    public enum Type
    {

       Bogue = 0,
       Test = 1,
       Interface = 2,
       Tâche = 3,
       Question = 4,
       Probleme = 5
         
    }
/*
    public class Niveau
    {
        public int NiveauID { get; set; }
        public string Libelle { get; set; } // Utilisateur, Service, Département,Direction, Etablissement, Groupe, Pays...

    }*/

 

    public enum Environnement
    {
      Developpement = 0,
      Test = 1,
      Formation = 2,
      Préproduction = 3,
      Production = 4

    }

    public enum Priorite
    {
       Haute = 0,
       Urgent = 1,
       Normal = 2,
       Immediat = 3,
       Bas = 4

    }

    public enum Resolution
    {
        Ouvert = 0,
        Résolu = 1,
        Fermé = 2,
        Archivé = 3

    }


    public class PieceJointe
    {
        public int PieceJointeID { get; set; }

        public byte[] Content { get; set; }   
        public string Libelle { get; set; }
    }

  

    public enum Statut
    {
       Nouveau = 0,
       Ouvert = 1,
       Résolu = 2,
       Fermé = 3

    }





}
