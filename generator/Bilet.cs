using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    /// <summary>
    /// Klasa zawiera pola z informacjami o biletach:
    /// -ID
    /// -miejsce w samolocie
    /// -klient, który zakupił bilet
    /// -lot, na który bilet został zakupiony
    /// </summary>
    public class Bilet
    {
        public int ID { get; set; }
        public int miejsce { get; set; }
        public Klient klient;
        public Lot lot;

        public Bilet() { }

        public Bilet(int iD, int miejsce, Klient klient, Lot lot)
        {
            ID = iD;
            this.miejsce = miejsce;
            this.klient = klient;
            this.lot = lot;
        }
    }
}
