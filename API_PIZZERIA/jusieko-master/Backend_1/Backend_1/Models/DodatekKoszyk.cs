using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class DodatekKoszyk
    {
        public int Id { get; set; }
        public int DodatekId { get; set; }
        public int KoszykId { get; set; }

        public virtual Dodatek Dodatek { get; set; }
        public virtual Koszyk Koszyk { get; set; }
    }
}
