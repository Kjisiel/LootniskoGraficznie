using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

//TODO przeglad i inne usuwanie (?) obiektow z list

namespace L1
{
    /// <summary>
    /// Klasa zwiera listy ze wszystkimi obiektami klas:
    /// -Klient
    /// -Samolot
    /// -Lotnikso
    /// -Trasa
    /// -Lot
    /// -Bilet
    /// oraz metody pozwalające na dodawanie i usuwanie obiektów tych list,
    /// a także metody pozwalające na zapisanie stanu systemu do plików XML oraz jego odczyt.
    /// </summary>
    class BazaDanych
    {
        public static List<Klient> klienci = new List<Klient>();
        public static List<Samolot> samoloty = new List<Samolot>();
        public static List<Lotnisko> lotniska = new List<Lotnisko>();
        public static List<Trasa> trasy = new List<Trasa>();
        public static List<Lot> loty = new List<Lot>();
        public static List<Bilet> bilety = new List<Bilet>();

        public static void dodajKlienta(Klient klient)
        {
            klienci.Add(klient);
        }

        public static void dodajSamolot(Samolot samolot)
        {
            samoloty.Add(samolot);
        }

        public static void dodajLotnisko(Lotnisko lotnisko)
        {
            lotniska.Add(lotnisko);
        }

        public static void dodajTrase(Trasa trasa)
        {
            trasy.Add(trasa);
        }

        public static void dodajLot(Lot lot)
        {
            loty.Add(lot);
        }

        public static void dodajBilet(Bilet bilet)
        {
            bilety.Add(bilet);
        }

        public static void usunKlienta(Klient klient)
        {
            klienci.Remove(klient);
        }

        public static void usunSamolot(Samolot samolot)
        {
            samoloty.Remove(samolot);
        }

        public static void usunLotnisko(Lotnisko lotnisko)
        {
            lotniska.Remove(lotnisko);
        }

        public static void usunTrase(Trasa trasa)
        {
            trasy.Remove(trasa);
        }

        public static void usunLot(Lot lot)
        {
            loty.Remove(lot);
        }

        public static void usunBilet(Bilet bilet)
        {
            bilety.Remove(bilet);
        }

        public void zapis()
        {
            XmlSerializer sklienci = new XmlSerializer(typeof(List<Klient>));
            StreamWriter zklienci = new StreamWriter("klienci.xml");
            sklienci.Serialize(zklienci, klienci);
            zklienci.Close();

            XmlSerializer ssamoloty = new XmlSerializer(typeof(List<Samolot>));
            StreamWriter zsamoloty = new StreamWriter("samoloty.xml");
            ssamoloty.Serialize(zsamoloty, samoloty);
            zsamoloty.Close();

            XmlSerializer slotniska = new XmlSerializer(typeof(List<Lotnisko>));
            StreamWriter zlotniska = new StreamWriter("lotniska.xml");
            slotniska.Serialize(zlotniska, lotniska);
            zlotniska.Close();

            XmlSerializer strasy = new XmlSerializer(typeof(List<Trasa>));
            StreamWriter ztrasy = new StreamWriter("trasy.xml");
            strasy.Serialize(ztrasy, trasy);
            ztrasy.Close();

            XmlSerializer sloty = new XmlSerializer(typeof(List<Lot>));
            StreamWriter zloty = new StreamWriter("loty.xml");
            sloty.Serialize(zloty, loty);
            zloty.Close();

            XmlSerializer sbilety = new XmlSerializer(typeof(List<Bilet>));
            StreamWriter zbilety = new StreamWriter("bilety.xml");
            sbilety.Serialize(zbilety, bilety);
            zbilety.Close();
        }

        public void odczyt()
        {
            XmlSerializer dklienci = new XmlSerializer(typeof(List<Klient>));
            StreamReader oklienci = new StreamReader("klienci.xml");
            klienci = (List<Klient>)dklienci.Deserialize(oklienci);
            oklienci.Close();

            XmlSerializer dsamoloty = new XmlSerializer(typeof(List<Samolot>));
            StreamReader osamoloty = new StreamReader("samoloty.xml");
            samoloty = (List<Samolot>)dsamoloty.Deserialize(osamoloty);
            osamoloty.Close();

            XmlSerializer dlotniska = new XmlSerializer(typeof(List<Lotnisko>));
            StreamReader olotniska = new StreamReader("lotniska.xml");
            lotniska = (List<Lotnisko>)dlotniska.Deserialize(olotniska);
            olotniska.Close();

            XmlSerializer dtrasy = new XmlSerializer(typeof(List<Trasa>));
            StreamReader otrasy = new StreamReader("trasy.xml");
            trasy = (List<Trasa>)dtrasy.Deserialize(otrasy);
            otrasy.Close();

            XmlSerializer dloty = new XmlSerializer(typeof(List<Lot>));
            StreamReader oloty = new StreamReader("loty.xml");
            loty = (List<Lot>)dloty.Deserialize(oloty);
            oloty.Close();

            XmlSerializer dbilety = new XmlSerializer(typeof(List<Bilet>));
            StreamReader obilety = new StreamReader("bilety.xml");
            bilety = (List<Bilet>)dbilety.Deserialize(obilety);
            obilety.Close();
        }
    }
}
