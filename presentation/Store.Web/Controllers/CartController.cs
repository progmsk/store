using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository bookRepository;

        public CartController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult Add(int id)
        {
            var book = bookRepository.GetById(id);
            Cart cart;
            if (!HttpContext.Session.TryGetCart(out cart))
                cart = new Cart();

            if (cart.Items.ContainsKey(id))
                cart.Items[id]++;
            else
                cart.Items[id] = 1;

            cart.Amount += book.Price;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new { id });
        }
    }
}