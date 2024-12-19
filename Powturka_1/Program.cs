using System;
using System.Collections.Generic;

namespace Powturka_1
{
    internal class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
            public override string ToString()
            {
                return $"{FirstName} {LastName}";
            }
        }

        public class Autor : Person
        {
            public Autor(string firstName, string lastName) : base(firstName, lastName) { }
            public override string ToString()
            {
                return $"Autor: {FirstName} {LastName}";
            }
        }

        public class Book
        {
            public string Title { get; set; }
            public int YearOfPublication { get; set; }
            public Autor Autor { get; set; }

            public Book(string title, int yearOfPublication, Autor autor)
            {
                Title = title;
                YearOfPublication = yearOfPublication;
                Autor = autor;
            }

            public override string ToString()
            {
                return $"{Title} ({YearOfPublication}), {Autor}";
            }
        }
        public class Reader : Person
        {
            public List<Book> BorrowBooks { get; set; }

            public Reader(string firstName,string lastName) : base(firstName, lastName) 
            { 
                BorrowBooks = new List<Book>();
            }
            public void BorrowbookAdd(Book book)
            {
                BorrowBooks.Add(book);
                Console.WriteLine($"{FirstName}, {LastName} wypożyczył książkę {book.Title}");
            }
        }
        static void Main(string[] args)
        {
            // Lista osób (w tym autorów)
            List<Person> listPerson = new List<Person>
            {
                new Person("Tomek", "Nowacki"),
                new Autor("Kuba", "Nowakowski"),
            };

            // Tworzenie listy książek
            List<Book> books = new List<Book>();
            Autor autor1 = new Autor("Tomek", "Nowak");
            Book book1 = new Book("Hobbit", 1939, autor1);

            // Dodanie autora do listy osób i książki do listy książek
            listPerson.Add(autor1);
            books.Add(book1);

            List<Reader> readers = new List<Reader>();
            Reader reader = new Reader("Marcin","Nowak");
            readers.Add(reader);

            // Wyświetlanie osób
            Console.WriteLine("Lista osób:");
            foreach (Person person in listPerson)
            {
                Console.WriteLine(person);
            }

            // Wyświetlanie książek
            Console.WriteLine("\nLista książek:");
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\nCzytelnicy:");
            foreach (Reader reader1 in readers) 
            { 
                Console.WriteLine(reader1);
            }
        }
    }
}
