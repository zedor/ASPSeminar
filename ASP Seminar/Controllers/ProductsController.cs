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
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Product != null ? 
                          View(await _context.Product.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Product'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            if (_context.ProductCategory != null)
            {
                product.ProductCategories = _context.ProductCategory.Where(x => x.ProductId == product.Id).ToList();

                foreach (var item in product.ProductCategories)
                {
                    if (_context.Category != null)
                        item.CategoryTitle = _context.Category.FirstOrDefault(x => x.Id == item.CategoryId)?.Title;
                }
            }

            return View(product);
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
