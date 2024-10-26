namespace Dziediczenie
{
    internal class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Person(string FirstName, string lastName)
            {
                this.FirstName = FirstName;
                LastName = lastName;
            }
        }

        public class Author : Person
        {
            public List<Book> BooksList { get; set; }
            public Author(string firstName, string lastName) : base(firstName, lastName)
            {
                BooksList = new List<Book>();
            }
            public void AddBook(Book book)
            {
                BooksList.Add(book);
            }
        }

        public class Book
        {
            public string Title { get; set; }
            public int PublicationYear { get; set; }
            public Author Author { get; set; }

            public Book(string title, int publicationYear, Author author)
            {
                Title = title;
                PublicationYear = publicationYear;
                Author = author;
            }
        }

        public class Reader : Person
        {
            public List<Book> BorrowedBooksList { get; set; }

            public Reader(string FirstName, string lastName) : base(FirstName, lastName)
            {
                BorrowedBooksList = new List<Book>();
            }

            public void BorrowBook(Book book)
            {
                BorrowedBooksList.Add(book);
                Console.WriteLine($"Czytelnik {FirstName} {LastName} wypożyczył książkę: {book.Title}");
            }
        }

        public class Library
        {
            public List<Book> BooksList { get; set; }
            public List<Reader> ReadersList { get; set; }

            public Library()
            {
                BooksList = new List<Book>();
                ReadersList = new List<Reader>();
            }

            public void AddBook(Book book)
            {
                BooksList.Add(book);
                Console.WriteLine($"Dodano książkę: {book.Title}");
            }

            public void AddReader(Reader reader)
            {
                ReadersList.Add(reader);
                Console.WriteLine($"Dodano czytelnika: {reader.FirstName} {reader.LastName}");
            }

            //metoda umozliwiająca wypozyczenie ksiazki przez czytelnika
            public void BorrowBook(Reader reader, Book book)
            {
                if (BooksList.Contains(book))
                {
                    reader.BorrowBook(book);
                    BooksList.Remove(book);
                    Console.WriteLine($"Książka {book.Title} zostałą wypożyczona przez {reader.FirstName} {reader.LastName}");
                }
                else
                {
                    Console.WriteLine($"Książka {book.Title} nie jest dostępna w bibliotece");
                }
            }
        }


        static void Main(string[] args)
        {
            Person person = new Person("Jan", "Nowak");

            //dodac ksiazke oraz autora (obiekty)
            Author author = new Author("Adam", "Mickiewicz");

            Book book = new Book("Pan Tadeusz", 1834, author);
            author.AddBook(book);

            Reader reader = new Reader("Jan", "Kowal");

            Library library = new Library();
            library.AddBook(book);
            library.AddReader(reader);

            library.BorrowBook(reader, book);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Dodaj autora");
                Console.WriteLine("2. Dodaj książkę");
                Console.WriteLine("3. Dodaj czytelnika");
                Console.WriteLine("4. Wypożycz książkę");
                Console.WriteLine("5. Wyświetl wszystkie książki");
                Console.WriteLine("6. Wyświetl wszystkich autorów");
                Console.WriteLine("7. Wyświetl wszystkie wypożyczone książki");
                Console.WriteLine("8. Wyjście");
                Console.Write("Wybierz opcję:");
            }

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Podaj imię autora:");
                    string authorFirstName = Console.ReadLine();
                    Console.Write("Podaj nazwisko autora:");
                    string authorLastName = Console.ReadLine();
                    //dokończyć metoda AddAuthor()
                    break;
                case "8":
                    exit = true;
                    break;
            }

            Console.ReadKey();
        }
    }
}