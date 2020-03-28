using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class SkladDod
    {
        public SkladDod()
        {
            PizzaZam = new HashSet<PizzaZam>();
        }

        public int IdSklad { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<PizzaZam> PizzaZam { get; set; }
    }
}
