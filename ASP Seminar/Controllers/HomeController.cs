using ASP_Seminar.Data;
using ASP_Seminar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_Seminar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            if( _context.Product != null )
            {
                Random rand = new Random();
                int total = _context.Product.Count();
                int toPick = 10 <= total ? 10 : total;
                List<int> pickedProducts = new List<int>();
                for(int i = 0; i < toPick; i++)
                {
                    var buff = rand.Next(0, total);
                    if (!pickedProducts.Contains(buff)) pickedProducts.Add(buff);
                    else i--;
                }
                int j = 0;
                foreach (var item in _context.Product )
                {
                    if (pickedProducts.Contains(j++)) products.Add(item);
                }
            }


            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}