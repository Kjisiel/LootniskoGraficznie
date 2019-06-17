using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Samolot
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public int zasieg { get; set; }
        public int liczbamiejsc { get; set; }
        public double sredniaPredkosc { get; set; }
        public Lotnisko obecneLotnisko { get; set; }

        

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
