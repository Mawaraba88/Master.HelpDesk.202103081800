using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outils
{
    public class Formatage
    {
        public Formatage()
        {
            int i = 10; double r = 12.54d; DateTime dt = DateTime.Now;
            string nom = "KEFIF"; string prenom = "Youcef";

            // chaine 
            string snp1 = string.Format("{0} {1}", nom, prenom);
            string snp2 = $"{nom} {prenom}";
            string dir = @"D:\MASTERCCI\DOTNET";
            string guillemets = "un\"deux\"trois";
            string multilines = @"SELECT *
                                    FROM
                                    COLLABORATEUR";

            // entier
            string sint = $"{i:00}";  // zero si <10  exemple 12 -> 12, 7 -> 07 
            string sint2 = $"{i:#0}"; // exemple 12 -> 12, 7 -> 7 

            // reels
            string sr = $"{r:###,###,###.00}";  //  1,321,654.07  

            // date
            string sdt = $"{dt:yyyy-MM-dd}";   // 2021-01-25  ,  hh mm s

            // tableaux 
            int[] ti = new int[] { 1, 2, 3 };
            string sti = $"{ti[0]}/{ti[1]}/{ti[2]}";
        }

    }
}
