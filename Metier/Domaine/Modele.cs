using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Domaine
{
    /*/// <summary>
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
    */

    public class Commentaire
    {
        public int CommentaireID{ get; set; }
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

    public class Historique
    {

        public int HistoriqueID { get; set; }
        public string Libelle { get; set; }
    }


    public class Statut
    {
        public int StatutID { get; set; }
        public string Libelle { get; set; }

    }




}
