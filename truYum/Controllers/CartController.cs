using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var cart = _context.Cart.ToList();
            return View(cart);
        }

        [Route("Cart/AddToCart", Name = "menuItemId")]
        public IActionResult AddToCart(string menuItemId)
        {
            int id = Int32.Parse(menuItemId);
            var menuItems = _context.MenuItem.Where(c => c.Id == id).FirstOrDefault();

            var data = new Cart()
            {
                Name = menuItems.Name,
                FreeDelivery = menuItems.FreeDelivery,
                Price = menuItems.Price,
                MenuItemId = menuItems.Id,
            };
            _context.Cart.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Route("Cart/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var cartItem = _context.Cart.Where(c => c.Id == id).FirstOrDefault();

            _context.Entry(cartItem).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
