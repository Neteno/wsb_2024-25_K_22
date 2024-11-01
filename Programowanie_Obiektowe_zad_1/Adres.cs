using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_Obiektowe_zad_1
{
    internal class Adres
    {
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string NumerMieszkania { get; set; }
        public string Kodpocztowy { get; set; }
        public string Miasto { get; set; }
        public string Panstwo { get; set; }
        public string FormatPocztowy => $"Ul. {Ulica} {NumerDomu}/{NumerMieszkania}\n{Kodpocztowy} {Miasto}\n{Panstwo}";
    }
}
