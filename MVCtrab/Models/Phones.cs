using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtrab.Models
{
    public class Phones
    {
        //ID do cliente
        public int Id { get; set; }

        [Display(Name = "IdCostumer")]
        public int IdCostumer { get; set; }

        //Telefone
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Número de Telefone Inválido")]
        public String Telephone { get; set; }
    }
}