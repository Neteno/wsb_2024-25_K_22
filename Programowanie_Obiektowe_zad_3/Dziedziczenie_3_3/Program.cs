namespace Dziedziczenie_3_3
{
    using System;
    using System.Collections.Generic;

    public class Muzyka
    {
        public string Tytul { get; set; }
        public string Wykonawca { get; set; }

        // Konstruktor klasy bazowej
        public Muzyka(string tytul, string wykonawca)
        {
            Tytul = tytul;
            Wykonawca = wykonawca;
        }

        // Metoda do odtwarzania utworu, może być nadpisana przez klasy dziedziczące
        public virtual void Play()
        {
            Console.WriteLine($"Odtwarzam utwór: {Tytul} - {Wykonawca}");
        }
    }

    public class Pop : Muzyka
    {
        public string Brzmienie { get; set; }

        // Konstruktor klasy Pop
        public Pop(string tytul, string wykonawca, string brzmienie)
            : base(tytul, wykonawca)
        {
            Brzmienie = brzmienie;
        }

        // Nadpisana metoda Play()
        public override void Play()
        {
            base.Play();
            Console.WriteLine($"Brzmienie popowe: {Brzmienie}");
        }
    }

    public class Rock : Muzyka
    {
        public string Brzmienie { get; set; }

        // Konstruktor klasy Rock
        public Rock(string tytul, string wykonawca, string brzmienie)
            : base(tytul, wykonawca)
        {
            Brzmienie = brzmienie;
        }

        // Nadpisana metoda Play()
        public override void Play()
        {
            base.Play();
            Console.WriteLine($"Brzmienie rockowe: {Brzmienie}");
        }
    }

    public class Jazz : Muzyka
    {
        public string Brzmienie { get; set; }

        // Konstruktor klasy Jazz
        public Jazz(string tytul, string wykonawca, string brzmienie)
            : base(tytul, wykonawca)
        {
            Brzmienie = brzmienie;
        }

        // Nadpisana metoda Play()
        public override void Play()
        {
            base.Play();
            Console.WriteLine($"Brzmienie jazzowe: {Brzmienie}");
        }
    }

    public class Elektronika : Muzyka
    {
        public string Brzmienie { get; set; }

        // Konstruktor klasy Elektronika
        public Elektronika(string tytul, string wykonawca, string brzmienie)
            : base(tytul, wykonawca)
        {
            Brzmienie = brzmienie;
        }

        // Nadpisana metoda Play()
        public override void Play()
        {
            base.Play();
            Console.WriteLine($"Brzmienie elektroniczne: {Brzmienie}");
        }
    }

    public class Klasyka : Muzyka
    {
        public string Brzmienie { get; set; }

        // Konstruktor klasy Klasyka
        public Klasyka(string tytul, string wykonawca, string brzmienie)
            : base(tytul, wykonawca)
        {
            Brzmienie = brzmienie;
        }

        // Nadpisana metoda Play()
        public override void Play()
        {
            base.Play();
            Console.WriteLine($"Brzmienie klasyczne: {Brzmienie}");
        }
    }

    public class Player
    {
        private List<Muzyka> playlist = new List<Muzyka>();

        // Metoda dodająca utwór do playlisty
        public void Add(Muzyka song)
        {
            playlist.Add(song);
        }

        // Metoda usuwająca utwór z playlisty
        public void Remove(int songNumer)
        {
            if (songNumer >= 0 && songNumer < playlist.Count)
            {
                playlist.RemoveAt(songNumer);
                Console.WriteLine("Utwór został usunięty.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowy numer utworu.");
            }
        }

        // Metoda odtwarzająca utwór z playlisty
        public void Play(int songNumer)
        {
            if (songNumer >= 0 && songNumer < playlist.Count)
            {
                playlist[songNumer].Play();
                playlist.RemoveAt(songNumer);  // Usuwamy utwór po odtworzeniu
            }
            else
            {
                Console.WriteLine("Nieprawidłowy numer utworu.");
            }
        }

        // Metoda odtwarzająca wszystkie utwory w kolejności ich dodania
        public void PlayAll()
        {
            while (playlist.Count > 0)
            {
                Console.WriteLine("\nOdtwarzanie utworu:");
                Play(0);  // Odtwarzamy pierwszy utwór na liście
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Player player = new Player();
            bool continueAdding = true;

            // Wprowadzanie utworów
            while (continueAdding)
            {
                Console.WriteLine("Podaj gatunek muzyczny (Pop, Rock, Jazz, Elektronika, Klasyka): ");
                string genre = Console.ReadLine();

                Console.WriteLine("Podaj tytuł utworu: ");
                string title = Console.ReadLine();

                Console.WriteLine("Podaj wykonawcę utworu: ");
                string artist = Console.ReadLine();

                Console.WriteLine("Podaj brzmienie charakterystyczne dla tego gatunku: ");
                string sound = Console.ReadLine();

                // Tworzymy odpowiedni utwór na podstawie gatunku
                Muzyka song = genre.ToLower() switch
                {
                    "pop" => new Pop(title, artist, sound),
                    "rock" => new Rock(title, artist, sound),
                    "jazz" => new Jazz(title, artist, sound),
                    "elektronika" => new Elektronika(title, artist, sound),
                    "klasyka" => new Klasyka(title, artist, sound),
                    _ => throw new ArgumentException("Nieznany gatunek muzyczny.")
                };

                player.Add(song);

                Console.WriteLine("Chcesz dodać kolejny utwór? (t/n): ");
                string response = Console.ReadLine();
                continueAdding = response.ToLower() == "t";
            }

            // Odtwarzanie wszystkich utworów w kolejności dodania
            Console.WriteLine("\nOdtwarzanie wszystkich utworów:");
            player.PlayAll();
        }
    }

}
