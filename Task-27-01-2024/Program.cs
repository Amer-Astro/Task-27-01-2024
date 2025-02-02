using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Task_27_01_2024
{
    class Book
    {
        public Book(string title, string author, string iSBN, bool availability = true)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Availability = availability;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

    }

    class Library
    {

        internal List<Book> books = new List<Book>();

        internal void AddBook(Book book)
        {
            books.Add(book);
        }

        internal string BorrowBook(string bookTitle)
        {
            foreach (var book in books)
            {
                if (book.Title == bookTitle && book.Availability)
                {
                    book.Availability = false;
                    return $"The book {bookTitle} is Avalible";
                }
            }
            return $"The book {bookTitle} is not Avalible";
        }

        internal string ReturnBook(string bookTitle)
        {
            foreach (var book in books)
            {
                if (book.Title == bookTitle)
                {
                    book.Availability = true;
                    return $"The book {bookTitle} return is done";
                }
            }
            return $"This book is not borrowed";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            Console.WriteLine(library.BorrowBook("The Great Gatsby"));
            Console.WriteLine(library.BorrowBook("The Great Gatsby"));
            Console.WriteLine(library.BorrowBook("1984"));
            Console.WriteLine(library.BorrowBook("Harry Potter")); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            Console.WriteLine(library.ReturnBook("The Great Gatsby"));
            Console.WriteLine(library.ReturnBook("Harry Potter")); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
