using System;
using System.Collections.Generic;

namespace Backend_1.Models
{
    public partial class SkladDod
    {
        public SkladDod()
        {
            PizzaSklad = new HashSet<PizzaSklad>();
        }

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public virtual ICollection<PizzaSklad> PizzaSklad { get; set; }
    }
}
