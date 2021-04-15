using Metier.Domaine;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Type = Metier.Domaine.Type;

namespace Metier
{
    public class ModeleHelpDesk : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « ModeleHelpDesk » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « Metier.ModeleHelpDesk » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « ModeleHelpDesk » dans le fichier de configuration de l'application.
        public ModeleHelpDesk()
            : base("name=ModeleHelpDesk")
        {

        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Application> Applications { get; set; }
        public  DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Assistant> Assistants { get; set; }  
        public virtual DbSet<Commentaire> Commentaires { get; set; }
       
        public virtual DbSet<Categorie> Categories { get; set; }
    
        public virtual DbSet<Resolution> Resolutions { get; set; }
        public virtual DbSet<Criticite> Criticites { get; set; }
        public virtual DbSet<Priorite> Priorites { get; set; }
        public virtual DbSet<Statut> Statuts { get; set; }
       // public virtual DbSet<Niveau> Niveaux { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Profil> Profils { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Environnement> Environnements { get; set; }
     
        public virtual DbSet<Historique> Historiques { get; set; }
        public virtual DbSet<PieceJointe> PieceJointes { get; set; }
        public DbSet<Personne> Personnes { get; set; }

      



        

    }



    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}