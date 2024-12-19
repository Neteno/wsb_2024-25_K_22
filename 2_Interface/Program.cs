namespace _2_Interface
{
    internal class Program
    {
        class Book : IComparable<Book>
        {
            string title { get; set; }
            public string Autor { get; set; }
            public int YearOfPublication { get; set; }
            public double Price { get; set; }

            public Book(string title, string autor, int yearOfPublication, double price)
            {
                this.title = title;
                Autor = autor;
                YearOfPublication = yearOfPublication;
                Price = price;
            }
            public override string ToString()
            {
                return $"{title}, {Autor}, {YearOfPublication}, {Price}zł";
            }
            public int CompareTo(Book other)
            {
                return Price.CompareTo(other.Price);
                //return -Price.CompareTo(other.Price); Dla sortowanie od tyłu
            }

        }

        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            books.Add(new Book("Hobbit", "Nowak", 1937, 1.99));
            books.Add(new Book("Hobbit2", "Pawlak", 2000, 50.99));
            books.Add(new Book("Hobbit3", "Arek", 2040, 15.99));
            books.Add(new Book("Hobbit4", "Arek", 2077, 17.99));

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            books.Sort(); // Sortowanie
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            var sortedByYear = books.OrderBy(b => b.YearOfPublication);
            foreach (Book book in sortedByYear)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            var sortedByAutor = books.OrderByDescending(b => b.Autor);
            foreach (Book book in sortedByAutor)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            var sortedByPriceByYear = books.OrderByDescending(b => b.Price).ThenBy(b => b.YearOfPublication);
            foreach (Book book in sortedByPriceByYear)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            Console.Clear();
            Book book1 = new Book("Hobbit", "Nowak", 1937, 15.99);
            Book book2 = new Book("Hobbit1", "Pawlak", 2080, 35.99);

            int comparisonReal = book1.CompareTo(book2);
            //Console.WriteLine(comparisonReal);

            var compare = Comparer<Book>.Create((b1, b2) => b1.Price.CompareTo(b2.Price));
            Console.WriteLine(compare);

            Console.ReadKey();


        }
    }
}
