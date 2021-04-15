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
        public string Libelle { get; set; }

        #endregion

        public int Encours() { return -1; }
    }
    

    public class Commentaire
    {
        public int CommentaireID{ get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 50)]
        [UIHint("MultiLineText")]
        public string Contenu { get; set; }
    }

    public class Criticite
    {
        public int CriticiteID { get; set; }
        public string Libelle { get; set; }
    }



    public class Type
    {

        public int TypeID { get; set; }
        public string Libelle { get; set; }

    }

    public class Niveau
    {
        public int NiveauID { get; set; }
        public string Libelle { get; set; } // Utilisateur, Service, Département,Direction, Etablissement, Groupe, Pays...

    }

    public class Categorie
    {
        public int CategorieID { get; set; }
        public string Libelle { get; set; }
    }

    public class Environnement
    {
        public int EnvironnementID { get; set; }
        public string Libelle { get; set; }
    }

    public class Priorite
    {
        public int PrioriteID { get; set; }
        public string Libelle { get; set; }

    }

    public class Resolution
    {
        public int ResolutionID { get; set; }
        public string Libelle { get; set; }
    }


    public class PieceJointe
    {
        public int PieceJointeID { get; set; }

        public byte[] Content { get; set; }   
        public string Libelle { get; set; }
    }

    /*public class Historique
    {

        public int HistoriqueID { get; set; }
        public string Libelle { get; set; }

       public int Assistant
        {
            get => default;
            set
            {
            }
        }

     
        public int DateCreation
        {
            get => default;
            set
            {
            }
        }

        public int PieceJointe
        {
            get => default;
            set
            {
            }
        }

        public int PieceJointeID
        {
            get => default;
            set
            {
            }
        }

        public int Priorite
        {
            get => default;
            set
            {
            }
        }

        public int PrioriteID
        {
            get => default;
            set
            {
            }
        }

        public int Resolution
        {
            get => default;
            set
            {
            }
        }

        public int ResolutionID
        {
            get => default;
            set
            {
            }
        }

        public int Statut
        {
            get => default;
            set
            {
            }
        }

        public int StatutID
        {
            get => default;
            set
            {
            }
        }

        public int Ticket
        {
            get => default;
            set
            {
            }
        }

        public int TicketID
        {
            get => default;
            set
            {
            }
        }

        public int Utilisateur
        {
            get => default;
            set
            {
            }
        }

        public int UtilisateurID
        {
            get => default;
            set
            {
            }
        }

        public int AssistantID
        {
            get => default;
            set
            {
            }
        }
    }*/


    public class Statut
    {
        public int StatutID { get; set; }
        public string Libelle { get; set; }

    }




}
