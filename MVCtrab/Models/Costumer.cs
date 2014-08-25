using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtrab.Models
{

    public class Costumer
    {
        //ID do cliente
        public int Id { get; set; }

        //Nome do cliente
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        //Ramo do cliente
        [Required]
        [Display(Name = "Branch")]
        public String Branch { get; set; }

        //Nome do proprietario
        [Required]
        [Display(Name = "Owner")]
        public String Owner { get; set; }

        //public virtual ICollection<Phones> CostumerPhone { get; set; }

    }

}