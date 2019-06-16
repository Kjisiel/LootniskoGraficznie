using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
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
