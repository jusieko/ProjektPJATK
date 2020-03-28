using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class Zamowienie
    {
        public int IdZam { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public int KoszykIdKosz { get; set; }

        public virtual Koszyk KoszykIdKoszNavigation { get; set; }
    }
}
