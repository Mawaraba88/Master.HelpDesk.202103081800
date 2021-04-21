

namespace HelpDeskWeb.ViewModels.Ticket
{
    using Metier.Domaine;
    using Metier.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class AddTicketViewModel : IDomaine<Ticket>
    {
        /// <summary>
        /// GEstion des enumérations
        /// </summary>
        /// 

        [Display(Name = "Priorité")]
        [UIHint("Enum")]
        public Priorite Priorite { get; set; }

        [Display(Name = "Criticite")]
        [UIHint("Enum")]
        public Criticite Criticite { get; set; }
        [Display(Name = "Type de ticket")]
        [UIHint("Enum")]
        public Metier.Domaine.Type Type { get; set; }
        [Display(Name = "Environnement")]
        [UIHint("Enum")]
        public Environnement Environnement { get; set; }
        [Display(Name = "Resolution")]
        [UIHint("Enum")]
        public Resolution Resolution { get; set; }
        [Display(Name = "Statut")]
        [UIHint("Enum")]
        public Statut Statut { get; set; }

        [StringLength(50)]
        [UIHint("SingleLineText")]
        public string Resume { get; set; }

        [StringLength(1000)]
        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [Display(Name = "Application")]
        [UIHint("DropDownList")]

        public int ApplicationID { get; set; }

        public IEnumerable<SelectListItem> Applications { get; set; }

        public HttpPostedFileBase UploadesPieceJointe { get; set; }


    }
}