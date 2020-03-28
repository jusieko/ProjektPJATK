using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class PizzaZamowienie
    {
        public PizzaZamowienie()
        {
            PizzaKosz = new HashSet<PizzaKosz>();
            PizzaSklad = new HashSet<PizzaSklad>();
        }

        public int Id { get; set; }
        public int RozmiarId { get; set; }
        public int PizzaMenuId { get; set; }

        public virtual PizzaMenu PizzaMenu { get; set; }
        public virtual Rozmiar Rozmiar { get; set; }
        public virtual ICollection<PizzaKosz> PizzaKosz { get; set; }
        public virtual ICollection<PizzaSklad> PizzaSklad { get; set; }
    }
}
