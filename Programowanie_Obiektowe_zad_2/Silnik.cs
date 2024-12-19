using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_Obiektowe_zad_2
{
    internal class Silnik
    {
        public double Pojemnosc { get; set; }
        public double IloscPaliwa { get; set; }
        public double SpalanieL100km { get; set; }
        public double SpalanieMPG { get; set; }

        public static readonly double DomyslnaPojeknoscBaku = 10.0;
        private readonly double poejmnoscBaku;
        public void Przeliczenie_spalania(double wartosc_Litr_or_Gal)
        {
            Console.WriteLine(235.215 / wartosc_Litr_or_Gal);
        }
        public double PojemnoscBaku // Wartość tylko do odczyty
        {
            get { return poejmnoscBaku; }

        }
        public Silnik(double pojemnosc, double iloscPaliwa, double? pojemnoscBaku = null)
        {
            Pojemnosc = pojemnosc;
            IloscPaliwa = iloscPaliwa;
            this.poejmnoscBaku = pojemnoscBaku ?? DomyslnaPojeknoscBaku;
        }
        public Silnik(double pojemnosc, double iloscPaliwa) : this(pojemnosc, iloscPaliwa, DomyslnaPojeknoscBaku) { }

    }
}