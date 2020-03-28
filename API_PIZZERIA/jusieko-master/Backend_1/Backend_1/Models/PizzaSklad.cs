using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class PizzaSklad
    {
        public int Id { get; set; }
        public int SkladDodId { get; set; }
        public int PizzaZamowienieId { get; set; }

        public virtual PizzaZamowienie PizzaZamowienie { get; set; }
        public virtual SkladDod SkladDod { get; set; }
    }
}
