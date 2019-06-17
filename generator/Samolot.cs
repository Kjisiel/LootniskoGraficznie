using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    /// <summary>
    /// Klasa zwiera pola z informacjami o samolotach:
    /// -ID
    /// -nazwa
    /// -zasięg
    /// -liczba miejsc
    /// -średnia prędkość
    /// -lotnisko, na którym obecnie się znajduje.
    /// </summary>
   public class Samolot
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public int zasieg { get; set; }
        public int liczbamiejsc { get; set; }
        public double sredniaPredkosc { get; set; }
        public Lotnisko obecneLotnisko { get; set; }

        public Samolot() { }
            
        

        public Samolot(int iD, string nazwa, int zasieg, int liczbamiejsc,double sredniaPredkosc)
        {
            ID = iD;
            this.nazwa = nazwa;
            this.zasieg = zasieg;
            this.liczbamiejsc = liczbamiejsc;
            this.sredniaPredkosc = sredniaPredkosc;
        }
    }
}
