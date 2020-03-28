using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class Rozmiar
    {
        public Rozmiar()
        {
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public float MnoznikCeny { get; set; }

        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
    }
}
