using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Seminar.Data;
using ASP_Seminar.Models;

namespace ASP_Seminar.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
              return _context.Category != null ? 
                          View(await _context.Category.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Category'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            if (_context.ProductCategory != null)
            {
                category.ProductCategories = _context.ProductCategory.Where(x => x.CategoryId == category.Id).ToList();

                foreach (var item in category.ProductCategories)
                {
                    if (_context.Product != null)
                        item.ProductTitle = _context.Product.FirstOrDefault(x => x.Id == item.ProductId)?.Title;
                }
            }

            return View(category);
        }

        private bool CategoryExists(int id)
        {
          return (_context.Category?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
