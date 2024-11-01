namespace Programowanie_Obiektowe_zad_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Osoba osoba = new Osoba();
            //Adres adres = new Adres
            //{
            //    Ulica = "ulica",
            //    NumerDomu = "11-11",
            //    NumerMieszkania = "a",
            //    Kodpocztowy = "11-111",
            //    Miasto = "Poznań",
            //    Panstwo = "Polska",

            //};
            //osoba.UstawDane("Szymon", "Kowalski", adres);

            //Console.WriteLine(osoba.PrzedstawSie());

            List<Osoba> kontakty = new List<Osoba>();

            Console.Write("Podaj liczbę kontaków jakom będziemt dodawać: ");
            int liczbaKontaktow = int.Parse(Console.ReadLine());

            for (int i = 0; i < liczbaKontaktow; i++)
            {
                Console.WriteLine($"Wprowadź dane kontaku {i + 1}");
                Console.Write("Imie: ");
                string imie = Console.ReadLine();
                Console.Write("Nazwisko: ");
                string nazwisko = Console.ReadLine();
                Console.Write("Ulica: ");
                string ulica = Console.ReadLine();
                Console.Write("Numer domu: ");
                string numerDomu = Console.ReadLine();
                Console.Write("Numer mieszkania: ");
                string numerMieszkania = Console.ReadLine();
                Console.Write("Kod pocztowy: ");
                string kodPocztowy = Console.ReadLine();
                Console.Write("Miasto: ");
                string miasto = Console.ReadLine();
                Console.Write("Państwo: ");
                string panstwo = Console.ReadLine();

                Adres adres = new Adres
                {
                    Ulica = ulica,
                    NumerDomu = numerDomu,
                    NumerMieszkania = numerMieszkania,
                    Kodpocztowy = kodPocztowy,
                    Miasto = miasto,
                    Panstwo = panstwo
                };

                Osoba kontakt = new Osoba();
                kontakt.UstawDane(imie, nazwisko, adres);
                kontakty.Add(kontakt); 
            }

            Console.WriteLine("\nLista Kontaków:");
            for (int i = 0; i < kontakty.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {kontakty[i].FirstName} {kontakty[i].LastName}");
            }

            while (true)
            {
                Console.WriteLine("\nWybierz numer kontaktu, aby zobaczyć szczegół lub wciśnij Enter aby zakończyć");
                string wybor = Console.ReadLine();

                if (string.IsNullOrEmpty(wybor)) break;
                if (int.TryParse(wybor, out int indeks) && indeks >= 1 && indeks <= kontakty.Count)
                {
                    Console.WriteLine(kontakty[indeks - 1].PrzedstawSie());
                }
                else
                {
                    Console.WriteLine("Niepoprawny numer.");
                }
            }

        }
    }
}
