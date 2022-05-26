using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using truYum.Models;
using truYum.ViewModels;

namespace truYum.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly TruYumContext _context = null;

        public MenuItemsController(TruYumContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("menuitems", Name = "isAdmin")]
        public IActionResult Index(string isAdmin)
        {
            if (isAdmin == "True")
            {
                ViewBag.Name = "Admin";
                var items = _context.MenuItem.Include(c => c.Category).ToList();
                return View(items);
            }
            ViewBag.Name = "Customer Page";
            var custometItems = _context.MenuItem.Where(c => c.IsActive == true).Include(c => c.Category).ToList();
            return View(custometItems);
        }

        [Route("menuitems/create")]
        public IActionResult Create()
        {
            var category = _context.Category.ToList();
            ViewBag.Category = new SelectList(category, "Id", "Name");
            foreach (var item in category)
            {
                Debug.WriteLine(item);
            }
            var viewModel = new CategoryViewModel()
            {
                Category = category,
            };
            return View(viewModel);
        }


        [HttpPost]
        [Route("menuitems/create")]
        public IActionResult Create(MenuItem menuItem)
        {
            //var item = new MenuItem()
            //{
            //    Name = menuItem.Name,
            //    FreeDelivery = menuItem.FreeDelivery,
            //    DateOfLaunch = menuItem.DateOfLaunch,
            //    CategoryId = menuItem.CategoryId
            //};

            _context.MenuItem.Add(menuItem);
            _context.SaveChanges();

            return RedirectToAction("Index","MenuItems", new { isAdmin = "True" });
        }

        [Route("menuitems/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var category = _context.Category.ToList();
            ViewBag.Category = new SelectList(category, "Id", "Name");
            var data = _context.MenuItem.Where(c => c.Id == id).Include(c => c.Category).FirstOrDefault();
            TempData["id"] = id;
            TempData.Keep();
            return View(data);
        }

        [HttpPost]
        [Route("menuitems/edit/{id}")]
        public IActionResult Edit(MenuItem menuItem)
        {
            int id = (int)TempData["id"];
            var data = _context.MenuItem.Where(c => c.Id == id).Include(c => c.Category).FirstOrDefault();

            Debug.WriteLine(id);
            Debug.WriteLine("This is Edit Post");

            data.Name = menuItem.Name;
            data.Price = menuItem.Price;
            data.IsActive = menuItem.IsActive;
            data.FreeDelivery = menuItem.FreeDelivery;
            data.DateOfLaunch = menuItem.DateOfLaunch;
            data.CategoryId = menuItem.CategoryId;
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index", "MenuItems", new {isAdmin= "True" });
        }
    }
}
