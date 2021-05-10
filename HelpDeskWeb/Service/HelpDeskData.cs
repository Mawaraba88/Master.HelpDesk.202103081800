using Metier.Domaine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = System.Type;

namespace Metier.Interfaces
{
    class HelpDeskData : IHelpDeskData

    {
        private readonly DbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public HelpDeskData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<Application> Applications
        {
            get
            {
                return this.GetRepository<Application>();
            }
        }
        public IRepository<PieceJointe> PieceJointes
        {
            get { return this.GetRepository<PieceJointe>(); }
        }


        public IRepository<Ticket> Tickets
        {
            get
            {
                return this.GetRepository<Ticket>();
            }
        }

        public IRepository<Assistant> Assistants
        {
            get
            {
                return this.GetRepository<Assistant>();
            }
        }



        public IRepository<Commentaire> Commentaires
        {
            get
            {
                return this.GetRepository<Commentaire>();
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
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
