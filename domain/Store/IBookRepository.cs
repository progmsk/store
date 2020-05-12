namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string isbn);
        
        Book[] GetAllByTitleOrAuthor(string titleOrAuthor);
        
        Book GetById(int id);
    }
}
