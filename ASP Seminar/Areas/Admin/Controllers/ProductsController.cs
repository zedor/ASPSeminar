using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_Seminar.Data;
using ASP_Seminar.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ASP_Seminar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
              return _context.Product != null ? 
                          View(await _context.Product.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Product'  is null.");
        }

        // GET: Admin/Products/Details/5
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
                    if ( _context.Category != null )
                        item.CategoryTitle = _context.Category.FirstOrDefault(x => x.Id == item.CategoryId)?.Title;
                }
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
            ProductVM productModel = new ProductVM();
            var buff = await _context.Category.ToListAsync();
            foreach (var item in buff)
            {
                productModel.Categories.Add(new CategoryVM { Id = item.Id, Title = item.Title, Selected = false });
            }

            return View(productModel);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Quantity,Price,HasImage,ImgFile,Categories")] ProductVM modelProduct)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product = ViewModelToProduct(modelProduct);

                if (product.ImgFile == null) product.HasImage = false; else product.HasImage = true;
                
                _context.Add(product);
                await _context.SaveChangesAsync();

                if (product.ImgFile != null)
                {
                    string fileName = product.Id.ToString() + ".png";
                    string wwwRootPath = "wwwroot";
                    string path = wwwRootPath + "/images/" + fileName;

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        product.ImgFile?.CopyTo(fileStream);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(modelProduct);
        }

        [NonAction]
        private Product ViewModelToProduct(ProductVM product)
        {
            Product result = new Product();
            result.Id = product.Id;
            result.Title = product.Title;
            result.Description = product.Description;
            result.Quantity = product.Quantity;
            result.Price = product.Price;
            result.HasImage = product.HasImage;
            result.ImgFile = product.ImgFile;
            result.ProductCategories = new List<ProductCategory>();

            foreach (var item in product.Categories)
            {
                if (item.Selected)
                {
                    ProductCategory buff = new ProductCategory();
                    buff.CategoryId = item.Id;
                    buff.ProductId = product.Id;
                    //_context.ProductCategory?.Add(buff);
                    result.ProductCategories.Add(buff);
                }
            }

            //_context.SaveChanges();

            return result;
        }

        [NonAction]
        private ProductVM ProductToViewModel(Product product)
        {
            ProductVM result = new ProductVM();
            result.Id = product.Id;
            result.Title = product.Title;
            result.Description = product.Description;
            result.Quantity = product.Quantity;
            result.Price = product.Price;
            result.HasImage = product.HasImage;
            result.ImgFile = product.ImgFile;
            result.Categories = new List<CategoryVM>();

            if (_context.ProductCategory != null)
            {
                product.ProductCategories = _context.ProductCategory.Where(x => x.ProductId == product.Id).ToList();

                foreach (var item in product.ProductCategories)
                {
                    if (_context.Category != null)
                        item.CategoryTitle = _context.Category.FirstOrDefault(x => x.Id == item.CategoryId)?.Title;
                }
            }

            var buff = _context.Category.ToList();
            foreach (var item in buff)
            {
                bool boolValue;
                if (product.ProductCategories == null) boolValue = false;
                else boolValue = product.ProductCategories.Any(x => x.CategoryId == item.Id);
                
                result.Categories.Add(new CategoryVM { Id = item.Id, Title = item.Title,  Selected = boolValue });
            }

            return result;
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(ProductToViewModel(product));
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Quantity,Price,ImgFile,Categories")] ProductVM modelProduct)
        {
            if (id != modelProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Product product = new Product();
                try
                {
                    product = ViewModelToProduct(modelProduct);
                    

                    string fileName = product.Id.ToString() + ".png";
                    string wwwRootPath = "wwwroot";
                    string path = wwwRootPath + "/images/" + fileName;

                    if (product.ImgFile != null)
                    {
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            product.ImgFile?.CopyTo(fileStream);
                        }
                        product.HasImage = true;
                    }
                    else if (System.IO.File.Exists(path)) product.HasImage = true;
                    else product.HasImage = false;

                    if (_context.ProductCategory != null) await _context.ProductCategory.Where(x => x.ProductId == product.Id).ForEachAsync(x => _context.Remove(x));

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(modelProduct);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                if( _context.ProductCategory != null ) await _context.ProductCategory.Where(x => x.ProductId == product.Id).ForEachAsync(x => _context.Remove(x));
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
