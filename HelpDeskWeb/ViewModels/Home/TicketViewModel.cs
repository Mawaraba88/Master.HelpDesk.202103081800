using AutoMapper;

using Metier.Domaine;
using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskWeb.ViewModels.Home
{
    using AutoMapper;

    using Metier.Domaine;
    using Metier.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class TicketViewModel : IDomaine<Ticket>, IHaveCustomMapping
    {
        public int TicketID { get; set; }

        public string TypeTicket { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateEcheance { get; set; }

        public string Auteur { get; set; }

        public string NomAuteur { get; set; }
        public int TicketCount { get; set; }

        public int CommentaireCount { get; set; }
        public List<Commentaire> Commentaire { get; set; }

        void IHaveCustomMapping.CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Ticket, TicketViewModel>()
                 .ForMember(m => m.TypeTicket, opt => opt.MapFrom(t => t.Type))
                
                 .ForMember(m => m.NomAuteur, opt => opt.MapFrom(t => t.Assistant.Email))
                 .ForMember(m => m.CommentaireCount, opt => opt.MapFrom(t => t.Commentaires.Count()))
                 .ReverseMap();
        }
    }

}