namespace Interface_4_2
{
    internal class Program
    {
        class Book : IComparable<Book>
        {
            public string title { get; set; }
            public string Autor { get; set; }
            public int YearOfPublication { get; set; }
            public double Price;

            public Book(string title, string autor, int yearOfPublication, double price)
            {
                this.title = title;
                Autor = autor;
                YearOfPublication = yearOfPublication;
                Price = price;
            }

            public override string ToString()
            {
                return $"{title}, {Autor}, {YearOfPublication}, {Price} zł";
            }
            public int CompareTo(Book? other)
            {
                return Price.CompareTo(other.Price);
            }
        }
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Hobbit", "Nowak", 1937, 45.99));
            books.Add(new Book("Hobbit2", "Pawlak", 2000, 60.99));
            books.Add(new Book("Hobbit3", "Arbuz", 2054, 89.99));
            books.Add(new Book("Hobbit4", "Arkadusz", 2077, 3.99));
            bool petla = true;
            while (petla)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Wyświetl wszyskie książki");
                Console.WriteLine("2. Sortuj książki według ceny");
                Console.WriteLine("3. Sortuj książki według daty publikacji");
                Console.WriteLine("4. Sortuj książki według Autora");
                Console.WriteLine("5. Dodaj nową książke");
                Console.WriteLine("6. Usuń książkę");
                Console.WriteLine("7. Exit");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int wybor))
                {
                    
                    switch (wybor)
                    {
                        case 1:
                            Console.WriteLine("Lista książek: ");
                            foreach (Book book in books)
                            {
                                Console.WriteLine(book);
                            }
                            break;

                        case 2:
                            Console.WriteLine("\nLista posortowanych książek: ");
                            books.Sort();
                            foreach (Book book in books)
                            {
                                Console.WriteLine(book);
                            }
                            break;
                        case 3:
                            Console.WriteLine("\nLista posortowanych książek wedługł daty publikacji: ");
                            var sortedByYear = books.OrderBy(b => b.YearOfPublication);
                            foreach (Book book in sortedByYear)
                            {
                                Console.WriteLine(book);
                            }
                            break;
                        case 4:
                            Console.WriteLine("\nLista posortowanych książek wedługł Autora nie rosnąco: ");
                            var sortedByAuthorDESC = books.OrderBy(b => b.Autor);
                            foreach (Book book in sortedByAuthorDESC)
                            {
                                Console.WriteLine(book);
                            }
                            break ;
                        case 5:
                            Console.WriteLine("Dodaj nową książke:");
                            Console.WriteLine("Podaj Tytył");
                            string tytul = Console.ReadLine();
                            Console.WriteLine("Podaj Nazwisko Autora");
                            string nazwisko = Console.ReadLine();
                            Console.WriteLine("Podaj Rok wydania");
                            string rok = Console.ReadLine();
                            int.TryParse(rok, out int rokINT);
                            Console.WriteLine("Podaj Cene");
                            string cena = Console.ReadLine();
                            double.TryParse(cena, out double cenaINT);
                            books.Add(new Book(tytul,nazwisko,rokINT,cenaINT));
                            Console.WriteLine($"Książka {tytul},{nazwisko},{rokINT},{cenaINT}");
                            break;
                        case 6:
                            Console.WriteLine("Usuń książkę po tytule");
                            Console.Write("Podaj tytuł: ");
                            string tytulDoUsuniecia = Console.ReadLine();

                            int usuniete = books.RemoveAll(book => book.title.Equals(tytulDoUsuniecia, StringComparison.OrdinalIgnoreCase));

                            if (usuniete > 0)
                            {
                                Console.WriteLine($"Usunięto {usuniete} książkę/książki o tytule '{tytulDoUsuniecia}'.");
                            }
                            else
                            {
                                Console.WriteLine($"Nie znaleziono książki o tytule '{tytulDoUsuniecia}'.");
                            }
                            break;
                        case 7:
                            petla = false;
                            break;
                            
                        default:
                            Console.WriteLine("Nie ma takiej opcji.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Nie podałeś liczby.");
                }
            }

            //Console.WriteLine("Lista książek: ");
            //foreach (Book book in books) 
            //{
            //    Console.WriteLine(book);
            //}

            //Console.WriteLine("\nLista posortowanych książek: ");
            //books.Sort();
            //foreach (Book book in books)
            //{
            //    Console.WriteLine(book);
            //}

            //Console.WriteLine("\nLista posortowanych książek wedługł daty publikacji: ");
            //var sortedByYear = books.OrderBy(b => b.YearOfPublication);
            //foreach (Book book in sortedByYear)
            //{
            //    Console.WriteLine(book);
            //}

            //Console.WriteLine("\nLista posortowanych książek wedługł Autora nie rosnąco: ");
            //var sortedByAuthorDESC = books.OrderBy(b => b.Autor);
            //foreach (Book book in sortedByAuthorDESC)       
            //{
            //    Console.WriteLine(book);
            //}

            //Console.WriteLine("\nLista posortowanych książek według ceny nie rosnąco, a następnie według roku publikacji książaki: ");
            //var sortedByPriceAndYear = books.OrderBy(b => b.Price).ThenBy(b => b.YearOfPublication);
            //foreach (Book book in sortedByPriceAndYear)
            //{
            //    Console.WriteLine(book);
            //}

            //// 1. Sposób
            //Book book1 = new Book("Hobbit","Nowak",1937,47.99);
            //Book book2 = new Book("Hobbit2", "Pawlak", 2000, 15.99);
            //int comparisonResult = book1.CompareTo(book2);
            //Console.WriteLine(comparisonResult);

            //// 2. Sposób
            //var comparer = Comparer<Book>.Create((b1, b2) => b1.Price.CompareTo(b2.Price));
            //int comparisonResult2 = comparer.Compare(book1, book2);
            //Console.WriteLine(comparisonResult2);

            //Console.ReadKey();
        }
    }
}
