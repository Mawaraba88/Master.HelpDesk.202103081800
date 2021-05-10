using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskWeb.Service
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

        public IEnumerable<SelectListItem> GetApplication()
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

        public IEnumerable<SelectListItem> GetAssistant()
        {
            var applications = this.cache.Get<IEnumerable<SelectListItem>>("assistants",
                () =>
                {
                    return this.data.Assistants
                       .All()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Email.ToString(),
                           Text = c.Nom
                       })
                       .ToList();
                });

            return applications;
        }
    }
}