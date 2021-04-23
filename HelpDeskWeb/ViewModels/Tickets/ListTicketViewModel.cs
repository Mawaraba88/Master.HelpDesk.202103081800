

using AutoMapper;


namespace HelpDeskWeb.ViewModels.Ticket
{

    using Metier.Domaine;
    using Metier.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class ListTicketViewModel /*: IDomaine<Ticket>, IHaveCustomMapping*/
    {

        public String Priorite { get; set; }

        public String Criticite { get; set; }
        
        public String TypeTicket { get; set; }
       
        public String Environnement { get; set; }
      
        public String Resolution { get; set; }
       
        public String Statut { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateEcheance { get; set; }
        public string Resume { get; set; }

       
        public string Description { get; set; }

        public string NomAssistant { get; set; }

        public String Application { get; set; }

        public int TicketCount { get; set; }

        /*public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Ticket, ListTicketViewModel>()
                .ForMember(m => m.TypeTicket, opt => opt.MapFrom(t => t.Type))
                .ForMember(m => m.Resume, opt => opt.MapFrom(t => t.Resume.ToString()))
                .ForMember(m => m.Statut, opt => opt.MapFrom(t => t.Statut.ToString()))
                .ForMember(m => m.Criticite, opt => opt.MapFrom(t => t.Criticite))
                .ForMember(m => m.Application, opt => opt.MapFrom(t => t.Applications.Libelle))
                .ForMember(m => m.Priorite, opt => opt.MapFrom(t => t.Priorite.ToString()))
                .ForMember(m => m.Environnement, opt => opt.MapFrom(t => t.Environnement.ToString()))
                .ForMember(m => m.Resolution, opt => opt.MapFrom(t => t.Resolution.ToString()))
                .ForMember(m => m.NomAssistant, opt => opt.MapFrom(t => t.Assistant.Nom))
                .ForMember(m => m.Description, opt => opt.MapFrom(t => t.Description.ToString()))


                .ReverseMap();*/
        }

    }
