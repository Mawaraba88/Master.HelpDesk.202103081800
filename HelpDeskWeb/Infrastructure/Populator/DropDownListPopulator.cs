using HelpDeskWeb.Infrastructure.Caching;
using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskWeb.Infrastructure.Populator
{
    public class DropDownListPopulator : IDropDownListPopulator
    {
        private IHelpDeskData data;
        private ICacheService cache;

        public DropDownListPopulator(IHelpDeskData data, ICacheService cache)
        {
            this.data = data;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetApplications()
        {
            var applications = this.cache.Get<IEnumerable<SelectListItem>>("applications",
                () =>
                {
                    return this.data.Applications
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.ApplicationID.ToString(),
                           Text = c.Libelle
                       })
                       .ToList();
                });

            return applications;
        }

        public IEnumerable<SelectListItem> GetAuteurs()
        {
            var auteurs = this.cache.Get<IEnumerable<SelectListItem>>("auteurs",
                () =>
                {
                    return this.data.Auteurs
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.UserName
                       })
                       .ToList();
                });

            return auteurs;
        }

        public IEnumerable<SelectListItem> GetSatuts()
        {
            var statuts = this.cache.Get<IEnumerable<SelectListItem>>("status",
                () =>
                {
                    return this.data.Tickets
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Statut.ToString(),
                           Text = c.Statut.ToString()
                       })
                       .ToList();
                });

            return statuts;
        }
        public IEnumerable<SelectListItem> GetPriorites()
        {
            var priorites = this.cache.Get<IEnumerable<SelectListItem>>("priorites",
                () =>
                {
                    return this.data.Tickets
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Priorite.ToString(),
                           Text = c.Priorite.ToString()
                       })
                       .ToList();
                });

            return priorites;
        }

    }
}