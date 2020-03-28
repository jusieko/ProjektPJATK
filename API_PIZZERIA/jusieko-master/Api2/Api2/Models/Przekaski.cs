using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class Przekaski
    {
        public Przekaski()
        {
            Dodatki = new HashSet<Dodatki>();
        }

        public int IdPrzek { get; set; }
        public int IloscSzt { get; set; }

        public virtual ICollection<Dodatki> Dodatki { get; set; }
    }
}
