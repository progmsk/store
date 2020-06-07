using Microsoft.AspNetCore.Mvc;
using Store.Web.App;

namespace Store.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(int id)
        {
            var model = bookService.GetById(id);
            
            return View(model);
        }
    }
}