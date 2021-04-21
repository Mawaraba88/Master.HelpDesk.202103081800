using AutoMapper.QueryableExtensions;
using HelpDeskWeb.ViewModels.Home;
using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskWeb.Service
{

    public class HomeServices : BaseServices, IHomeServices
    {
        public HomeServices(IHelpDeskData data)
            : base(data)
        {
        }

        public IList<TicketViewModel> GetIndexViewModel(int numberOfTickets)
        {
            var indexViewModel = this.Data
                .Tickets
                .All()
                .OrderByDescending(t => t.Commentaires.Count())
                .Take(numberOfTickets)
                .Project()
                .To<TicketViewModel>()
                .ToList();

            return indexViewModel;
        }
    }
}