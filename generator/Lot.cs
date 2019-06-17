using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    class Lot
    {
        public int ID { get; set; }
        public int wykupioneMiejsca { get; set; }
        public float kwota { get; set; }
        public float czasLotu { get; set; }
        public Trasa trasa;
        public Samolot samolot;

   
        public Lot(int iD, int wykupioneMiejsca, float kwota, Trasa trasa, Samolot samolot,float czasLotu)
        {
            ID = iD;
            this.wykupioneMiejsca = wykupioneMiejsca;
            this.kwota = kwota;
            this.trasa = trasa;
            this.samolot = samolot;
            this.czasLotu = czasLotu;
        }
    }
}
