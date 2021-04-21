using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Interfaces
{
    public class HelpDeskData : IHelpDeskData
    {
        private readonly DbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public HelpDeskData(DbContext context)
        {
            this.context = context;
        }

        public DbContext Context => throw new NotImplementedException();

        public IRepository<Domaine.Commentaire> Commentaires
        {
            get { return this.GetRepository<Domaine.Commentaire>(); }
        }
        public IRepository<Domaine.PieceJointe> PieceJointes
        {
            get
            {
                return this.GetRepository<Domaine.PieceJointe>();
            }
        }

        public IRepository<Domaine.Ticket> Tickets
             
            {
            get { return this.GetRepository<Domaine.Ticket>(); }
            }
        public IRepository<Domaine.Assistant> Assistants
        {
            get
            {
                return this.GetRepository<Domaine.Assistant>();
            }
        }

        public IRepository<Application> Applications
        {
            get
            {
                return this.GetRepository<Application>();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
