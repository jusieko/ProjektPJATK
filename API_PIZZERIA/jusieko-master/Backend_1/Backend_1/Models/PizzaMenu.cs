using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class PizzaMenu
    {
        public PizzaMenu()
        {
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public string ListaSkladnikow { get; set; }

        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
    }
}
