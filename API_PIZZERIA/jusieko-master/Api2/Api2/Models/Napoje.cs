using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class Napoje
    {
        public Napoje()
        {
            Dodatki = new HashSet<Dodatki>();
        }

        public int IdNap { get; set; }
        public int ObjetoscMl { get; set; }

        public virtual ICollection<Dodatki> Dodatki { get; set; }
    }
}
