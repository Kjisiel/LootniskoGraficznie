using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    /// <summary>
    /// Klasa zwiera pole z nazwą firmy pośredniczącej. Pochodna klasy Klient.
    /// </summary>
    class Posrednik : Klient
    {
        public string nazwa { get; set; }

        public Posrednik() { }

        public Posrednik(int ID, string nazwa) : base(ID)
        {
            this.nazwa = nazwa;
        }
    }
}
