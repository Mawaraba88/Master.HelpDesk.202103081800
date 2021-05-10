
namespace HelpDeskWeb.ViewModels.Ticket
{
    using AutoMapper;
    using Metier.Domaine;
    using Metier.Interfaces;
    using System;
    using System.Collections.Generic;
    using HelpDeskWeb.ViewModels.Commentaires;
    using System.Linq;
    using System.Web;
    public class TicketDetailsViewModel : IDomaine<Ticket>, IHaveCustomMapping
    {


        public int TicketID { get; set; }

        public Priorite Priorite { get; set; }

      
        public Criticite Criticite { get; set; }
        
        public Metier.Domaine.Type Type { get; set; }
       
        public Environnement Environnement { get; set; }
       
        public Resolution Resolution { get; set; }
       
        public Statut Statut { get; set; }

        
        public string Resume { get; set; }

     
        public string Description { get; set; }

    

        public string Application { get; set; }

        public ICollection<CommentViewModel> Commentaires { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Ticket, TicketDetailsViewModel>()
                .ForMember(m => m.Type, opt => opt.MapFrom(t => t.Type))
                .ForMember(m => m.Application, opt => opt.MapFrom(t => t.Applications.Libelle))

                .ReverseMap();
        }
    }
}