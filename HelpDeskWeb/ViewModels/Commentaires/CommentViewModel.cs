using Metier.Domaine;
namespace HelpDeskWeb.ViewModels.Commentaires
{
    using AutoMapper;
    using Metier.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class CommentViewModel /*: IDomaine<Commentaire>, IHaveCustomMapping*/
    {
    
        public int CommentaireID { get; set; }

        public string NomAssistant { get; set; }

        public string Contenu { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Commentaire, CommentViewModel>()
                .ForMember(c => c.NomAssistant, opt => opt.MapFrom(c => c.Assistant));
        }


    }
}