using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_Obiektowe_zad_1
{
    internal class Osoba
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adres AdresZamieszkania { get; set; }
        public string PelnyAdres => AdresZamieszkania.FormatPocztowy;
        public void UstawDane(string firstName, string lastName,Adres adres)
        {
            FirstName = firstName;
            LastName = lastName;
            AdresZamieszkania = adres;
        }
        public string PrzedstawSie()
        {
            return $"Nazywam się {FirstName} {LastName}.\nAdres:\n{PelnyAdres}";
        }
    }
}
