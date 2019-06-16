using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Lotnisko
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string panstwo { get; set; }
        public string miasto { get; set; }
        public double szerokoscGeo { get; set; }
        public double wysokoscGeo { get; set; }

        public Lotnisko() { }

        public Lotnisko(int iD, string nazwa, string panstwo, string miasto, double szerokoscGeo, double wysokoscGeo)
        {
            ID = iD;
            this.nazwa = nazwa;
            this.panstwo = panstwo;
            this.miasto = miasto;
            this.szerokoscGeo = szerokoscGeo;
            this.wysokoscGeo = wysokoscGeo;
        }
    }
}
