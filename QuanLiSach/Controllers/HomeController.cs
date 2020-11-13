using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuanLiSach.Models;
using QuanLiSach.Viewmodel;

namespace QuanLiSach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Appcontext _appDbContext;

        public HomeController(ILogger<HomeController> logger, Appcontext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var books = _appDbContext.Books.Include(p => p.categoryBook).ToList();
           
            return View(books);
            
        }
       
        public IActionResult Create()
        {
            HomeIndex homeIndex = new HomeIndex()
            {
                Book = new Book(),
                CategoriesSelectList = _appDbContext.CategoryBooks.Select(item => new SelectListItem
                {
                    Text = item.Category,
                    Value = item.Id.ToString()
                }),
               
            };
            return View(homeIndex);
        }
    
        [HttpPost]
        public IActionResult Create(HomeIndex homeIndex)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Books.Add(homeIndex.Book);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(homeIndex);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var book = _appDbContext.Books.Find(id);
            if (book == null) return NotFound();

            return View(book);
        }
        [HttpPost]
        public IActionResult DeleteBooks(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var book = _appDbContext.Books.Find(id);
            if (book == null) return NotFound();

            _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var book = _appDbContext.Books.Find(id);
            if (book == null) return NotFound();
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _appDbContext.Books.Update(book);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
