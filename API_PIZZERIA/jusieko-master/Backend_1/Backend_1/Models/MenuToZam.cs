using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class MenuToZam
    {
        public int Id { get; set; }
        public int PizzaZamowienieId { get; set; }
        public int PizzaMenuId { get; set; }

        public virtual PizzaMenu PizzaMenu { get; set; }
        public virtual PizzaZamowienie PizzaZamowienie { get; set; }
    }
}
