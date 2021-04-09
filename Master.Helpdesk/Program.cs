using Master.Helpdesk.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Helpdesk
{
    class Program
    {
        static void Main(string[] args)
        {
            // liste des etudiants de la base sqlite
            // 1. connexion  
            SQLiteConnection cnx = new
                SQLiteConnection(
                "Data Source=MasterCCI2021.sqlite;Version=3;");

            cnx.Open();

            // 2. execution SQL
            var sql = "SELECT * FROM Etudiant";
            SQLiteCommand cmd = new SQLiteCommand(sql, cnx);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            // 3. resultats
            while (rdr.Read())
            {

                Console.WriteLine($"{rdr[0]} {rdr[1]} {rdr[2]}  ");
              //  Console.WriteLine($"Identifiant = {(int)rdr[0]}" );

            }

            // 4. fermeture de la connexion
            rdr.Close();
            cnx.Close();


            // configuration 
            Console.WriteLine("Version = " + Settings.Default.Version);
            Console.WriteLine("Production ="+ ConfigurationManager.AppSettings["EstProduction"]);
            Console.WriteLine("Hello Master 2021 !!!!");

            // Lecture / écriture de fichiers  StreamReader / StreamWriter

            using (var sw =new StreamWriter("test.txt"))
            {
                sw.WriteLine("Hello !");
            }
             
            using(var sr=new StreamReader("test.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

            Console.ReadLine();
        }
    }
}
