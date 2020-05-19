using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 0201038013", "D. Knuth", "Art Of Programming, Vol. 1",
                     "This volume begins with basic programming concepts and techniques, then focuses more particularly on information structures-the representation of information inside a computer, the structural relationships between data elements and how to deal with them efficiently.",
                     7.19m),

            new Book(2, "ISBN 0201485672", "M. Fowler", "Refactoring",
                     "As the application of object technology--particularly the Java programming language--has become commonplace, a new problem has emerged to confront the software development community.",
                     12.45m),

            new Book(3, "ISBN 0131101633", "B. W. Kernighan, D. M. Ritchie", "C Programming Language",
                     "Known as the bible of C, this classic bestseller introduces the C programming language and illustrates algorithms, data structures, and programming techniques.",
                     14.98m),
        };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;

            return foundBooks.ToArray();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
