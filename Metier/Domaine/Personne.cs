﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier.Domaine
{
    public  class Personne
    {
        private ICollection<Ticket> tickets;
        private ICollection<Commentaire> commentaires;

        public Personne()
        {
            this.tickets = new HashSet<Ticket>();
            this.commentaires = new HashSet<Commentaire>();
        }
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = " Nom")]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Nom + ", " + Prenom;
            }
        }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        //public int Profil { get; set; }

        public virtual ICollection<Ticket> Tickets
        {
            get { return this.tickets; }
            set { this.tickets = value; }
        }

        public virtual ICollection<Commentaire> Commentairess
        {
            get { return this.commentaires; }
            set { this.commentaires = value; }
        }


    }
}
