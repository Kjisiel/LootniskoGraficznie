using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    /// <summary>
    /// Klasa zwiera pola z informacjami o trasach:
    /// -ID
    /// -lotniska, z których następuje odlot oraz przylot
    /// -odległość między lotniskami
    /// </summary>
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
