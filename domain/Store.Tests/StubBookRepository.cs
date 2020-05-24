using System.Collections.Generic;

namespace Store.Tests
{
    class StubBookRepository : IBookRepository
    {
        public Book[] ResultOfGetAllByIsbn { get; set; }

        public Book[] ResultOfGetAllByTitleOrAuthor { get; set; }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            throw new System.NotImplementedException();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            return ResultOfGetAllByIsbn;
        }

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return ResultOfGetAllByTitleOrAuthor;
        }

        public Book GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
