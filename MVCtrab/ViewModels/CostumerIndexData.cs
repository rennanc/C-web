using MVCtrab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtrab.ViewModels
{
    public class CostumerIndexData
    {
        public IEnumerable<Costumer> Costumers { get; set; }
        public IEnumerable<Phones> Phones { get; set; }
        public IEnumerable<Address> Adress { get; set; }
    }
}