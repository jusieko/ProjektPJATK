using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class PizzaMenu
    {
        public PizzaMenu()
        {
            PizzaZam = new HashSet<PizzaZam>();
        }

        public int IdMen { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public string ListaSkladnikow { get; set; }

        public virtual ICollection<PizzaZam> PizzaZam { get; set; }
    }
}
