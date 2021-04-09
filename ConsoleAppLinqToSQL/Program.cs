#region Références
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ConsoleAppLinqToSQL
{
    /// <summary>
    /// Présentation Linq to sql avec base HelpDesk
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projet LinkToSQL");

            // Instatiation du context DataClasses1Dat... par Mawaraba Doumbouya

            // Instantiation du context 
            DataClassesHelpDeskDataContext context = new DataClassesHelpDeskDataContext();
            var utilisateurs = context.Utilisateur;

            // Ajout d'Users
var nouveauUser = new Utilisateur  
{
    Nom = "Traore", 
    Prenom = "Hamid", 
    Email = "hamid@gmail.com",
    UtilisateurID = 23 
}​​;

            context.Utilisateur.InsertOnSubmit(nouveauUser);
            //Ajout de l'User dans la base
            context.SubmitChanges();

            //Modification
            var Pacory = context.Utilisateur.Where(u => u.Nom.StartsWith("PAC")).First();
            Pacory.Email = "jfp@gmail.com";
            context.SubmitChanges();
            //Delete
            var Hamid = context.Utilisateur.Where(u => u.UtilisateurID == 23).First();
            context.Utilisateur.DeleteOnSubmit(Hamid);
            context.SubmitChanges();

            // Select avec restrictions 
            foreach (Utilisateur utilisateur in utilisateurs)//.Where(u => u.Email.StartsWith("m")))
            {​​
                Console.WriteLine(utilisateur.Email);
            }​​

            Console.ReadLine();
        }
    }
}
