using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Trasa
    {
        public int ID { get; set; }
        public Lotnisko odlot;
        public Lotnisko przylot;
        public double odleglosc { get; set; }
     

        public Trasa() { }

        public Trasa(int iD, Lotnisko odlot, Lotnisko przylot, int odleglosc)
        {
            ID = iD;
            this.odlot = odlot;
            this.przylot = przylot;
            this.odleglosc = odleglosc;
            
        }
    }
}
