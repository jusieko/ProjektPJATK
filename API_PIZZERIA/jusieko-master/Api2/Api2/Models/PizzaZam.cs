using System;
using System.Collections.Generic;

namespace Api2.Models
{
    public partial class PizzaZam
    {
        public PizzaZam()
        {
            Koszyk = new HashSet<Koszyk>();
        }

        public int IdPizz { get; set; }
        public int RozmiarIdRoz { get; set; }
        public int Cena { get; set; }
        public int SkladDodIdSklad { get; set; }
        public int PizzaMenuIdMen { get; set; }

        public virtual PizzaMenu PizzaMenuIdMenNavigation { get; set; }
        public virtual Rozmiar RozmiarIdRozNavigation { get; set; }
        public virtual SkladDod SkladDodIdSkladNavigation { get; set; }
        public virtual ICollection<Koszyk> Koszyk { get; set; }
    }
}
