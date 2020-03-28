using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class Zamowienie
    {
        public int IdZam { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public int KoszykId { get; set; }

        public virtual Koszyk Koszyk { get; set; }
    }
}
