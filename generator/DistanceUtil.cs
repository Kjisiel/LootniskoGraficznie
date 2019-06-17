using L1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generator
{
    class DistanceUtil
    {
        private static double CONST_40075 = 40075.704;
        private static double CONST_360= 360;
        public static Double calculate(Lotnisko odlot, Lotnisko przylot)
        {
            Double odleglosc;//Todo https://pl.wikibooks.org/wiki/Astronomiczne_podstawy_geografii/Odległości
            double x1 = odlot.szerokoscGeo;
            double x2 = przylot.szerokoscGeo;
            double y1 = odlot.wysokoscGeo;
            double y2 = przylot.wysokoscGeo;
            double xPowElem = Math.Pow((odlot.szerokoscGeo - przylot.szerokoscGeo), 2);
            double zElem = Math.Cos((odlot.szerokoscGeo * Math.PI) / 180);
            double yPowElem = Math.Pow((zElem * (przylot.wysokoscGeo- odlot.wysokoscGeo)), 2);
            odleglosc = Math.Sqrt(xPowElem + yPowElem) * (CONST_40075 / CONST_360);

            return odleglosc;

        }

    }
}
