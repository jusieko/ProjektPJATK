using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class Dodatki
    {
        public Dodatki()
        {
            Koszyk = new HashSet<Koszyk>();
        }

        public int IdDod { get; set; }
        public int PrzekaskiIdPrzek { get; set; }
        public int NapojeIdNap { get; set; }
        public int Cena { get; set; }
        public string Nazwa { get; set; }

        public virtual Napoje NapojeIdNapNavigation { get; set; }
        public virtual Przekaski PrzekaskiIdPrzekNavigation { get; set; }
        public virtual ICollection<Koszyk> Koszyk { get; set; }
    }
}
