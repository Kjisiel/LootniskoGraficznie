using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    /// <summary>
    /// Klasa zawiera ID klienta. Bazowa klas Indywidualny i Posrednik.
    /// </summary>
    class Klient
    {
        public int ID { get; set; }

        public Klient() { }

        public Klient(int ID)
        {
            this.ID = ID;
        }
    }
}
