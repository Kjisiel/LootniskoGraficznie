using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    /// <summary>
    /// Klasa zwiera pola z informacjami o klientach indywidualnych:
    /// -imię
    /// -nazwisko.
    /// Pochodna klasy Klient.
    /// </summary>
    public class Indywidualny : Klient
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
