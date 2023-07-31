using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_Seminar.Data;
using ASP_Seminar.Models;

namespace ASP_Seminar.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductApi
        [Route("api/products")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductApiModel>>> GetProduct()
        {
          if (_context.Product == null)
          {
              return NotFound();
          }


            var products = await _context.Product.ToListAsync();

            List<ProductApiModel> resultList = new List<ProductApiModel>();
            foreach (var item in products)
            {
                ProductApiModel buff = new ProductApiModel();
                buff.Id = item.Id;
                buff.Title = item.Title;
                buff.Description = item.Description;
                buff.Quantity = item.Quantity;
                buff.Price = item.Price;
                buff.HasImage = item.HasImage;
                var buffCat = _context.ProductCategory?.Where(x => x.ProductId == item.Id).ToList();
                foreach (var item2 in buffCat)
                {
                    var buffName = _context.Category.FirstOrDefault(x => x.Id == item2.CategoryId);
                    buff.Categories.Add(buffName.Title);
                }
                resultList.Add(buff);
            }

            return resultList;

        }

        // GET: api/ProductApi/5
        [Route("api/product/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductApiModel>> GetProduct(int id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ProductApiModel buff = new ProductApiModel();
            buff.Id = product.Id;
            buff.Title = product.Title;
            buff.Description = product.Description;
            buff.Quantity = product.Quantity;
            buff.Price = product.Price;
            buff.HasImage = product.HasImage;
            var buffCat = _context.ProductCategory?.Where(x => x.ProductId == product.Id).ToList();
            foreach (var item2 in buffCat)
            {
                var buffName = _context.Category.FirstOrDefault(x => x.Id == item2.CategoryId);
                buff.Categories.Add(buffName.Title);
            }

            return buff;
        }

    }
}
