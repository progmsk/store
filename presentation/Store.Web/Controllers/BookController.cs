using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult Index(int id)
        {
            Book book = bookRepository.GetById(id);
            
            return View(book);
        }
    }
}