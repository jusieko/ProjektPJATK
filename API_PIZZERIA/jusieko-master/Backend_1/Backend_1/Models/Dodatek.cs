using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class Dodatek
    {
        public Dodatek()
        {
            DodatekKoszyk = new HashSet<DodatekKoszyk>();
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Ilosc { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<DodatekKoszyk> DodatekKoszyk { get; set; }
    }
}
