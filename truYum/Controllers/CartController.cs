using Microsoft.AspNetCore.Mvc;
using truYum.Models;

namespace truYum.Controllers
{
    public class CartController : Controller
    {

        private readonly TruYumContext _context = null;

        public CartController(TruYumContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Cart")]
        public IActionResult Index()
        {
            //var cart = _context.Cart.ToList();
            return View();
        }

        [Route("Cart/AddToCart", Name = "menuItemId")]
        public IActionResult AddToCart(int menuItemId)
        {
            return RedirectToAction("Index");
        }
    }
}
