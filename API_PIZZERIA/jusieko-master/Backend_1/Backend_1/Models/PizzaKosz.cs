using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class PizzaKosz
    {
        public int Id { get; set; }
        public int PizzaZamowienieId { get; set; }
        public int KoszykId { get; set; }

        public virtual Koszyk Koszyk { get; set; }
        public virtual PizzaZamowienie PizzaZamowienie { get; set; }
    }
}
