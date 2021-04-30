using Metier.Domaine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Interfaces
{
    public interface IHelpDeskData
    {
        DbContext Context { get; }

       

        IRepository<Commentaire> Commentaires { get; }

        IRepository<PieceJointe> PieceJointes { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Personne> Personnes { get; }

        IRepository<Application> Applications { get; }

        void Dispose();

        int SaveChanges();
    }
}
