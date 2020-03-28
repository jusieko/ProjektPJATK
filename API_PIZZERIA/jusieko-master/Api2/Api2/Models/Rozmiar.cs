using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class Rozmiar
    {
        public Rozmiar()
        {
            PizzaZam = new HashSet<PizzaZam>();
        }

        public int IdRoz { get; set; }
        public string Nazwa { get; set; }
        public float MnoznikCeny { get; set; }

        public virtual ICollection<PizzaZam> PizzaZam { get; set; }
    }
}
