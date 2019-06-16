using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Indywidualny : Klient
    {
        public string imie { set; get; }
        public string nazwisko { set; get; }

        public Indywidualny() { }

        public Indywidualny(int ID, string imie, string nazwisko) : base(ID)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}
