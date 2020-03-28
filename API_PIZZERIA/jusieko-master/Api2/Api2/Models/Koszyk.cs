using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class Koszyk
    {
        public Koszyk()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdKosz { get; set; }
        public int PizzaIdPizz { get; set; }
        public int Suma { get; set; }
        public int DodatkiIdDod { get; set; }

        public virtual Dodatki DodatkiIdDodNavigation { get; set; }
        public virtual PizzaZam PizzaIdPizzNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
