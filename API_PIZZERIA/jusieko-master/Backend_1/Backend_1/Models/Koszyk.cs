using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class Koszyk
    {
        public Koszyk()
        {
            DodatekKoszyk = new HashSet<DodatekKoszyk>();
            PizzaKosz = new HashSet<PizzaKosz>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int Id { get; set; }

        public virtual ICollection<DodatekKoszyk> DodatekKoszyk { get; set; }
        public virtual ICollection<PizzaKosz> PizzaKosz { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
