using Metier.Domaine;
using Metier.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDeskWeb.ViewModels.Commentaires
{
    public class PostCommentViewModel  : IDomaine<Commentaire>
    {
    
        public PostCommentViewModel()
    {
    }

    public PostCommentViewModel(int ticketId)
    {
        this.TicketID = ticketId;
    }

    public int TicketID { get; set; }

    [Required]
    [StringLength(1000, MinimumLength = 10)]
    [UIHint("MultiLineText")]
    public string Contenu { get; set; }

    public int CommentaireCount { get; set; }



    }
}