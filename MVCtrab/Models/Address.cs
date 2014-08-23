using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCtrab.Models
{
    public class Address
    {
        //ID do cliente
        public int Id { get; set; }

        [Display(Name = "IdCustomer")]
        public int IdCostumer { get; set; }

        //Telefone
        [Display(Name = "Address")]
        public String Local { get; set; }
    }
}