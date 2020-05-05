using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string isbn);
        
        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
    }
}
