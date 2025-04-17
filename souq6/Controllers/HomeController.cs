using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using souq6.Data;
using souq6.Models;

namespace souq6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            var product = _context.Products.Include(Y=>Y.category).ToList();

            return View(product);
        }

        public IActionResult GetCategory()
            
        {
            indexVM result =new indexVM();
            result.categories= _context.Categories.ToList();
            result.Products= _context.Products.ToList();

            return View(result);
        } 
        public IActionResult GetProductbyGategory(int id)
        {
            var product=_context.Products.Include(x=>x.category).Where(x=> x.CategoryID ==id).ToList();    
            return View(product);
        }

        public IActionResult Productsearch(string xname)
        {
            var pro = _context.Products.Include(x => x.category).Where(x => x.Name.Contains(xname)).ToList();
            return View(pro);
        }






        public IActionResult Review()
        {

            return View();
        }

        public IActionResult sendReview(Review review)
        {
         _context.Reviews.Add( new Review { Name=review.Name,Email=review.Email,Message=review.Message,Subject=review.Subject});
         _context.SaveChanges();
            return  RedirectToAction("Index");  
             
        }

        public IActionResult FilterbyPrice()
        {
            var product =_context.Products.Include(x => x.category).OrderBy(x => x.Price).ToList();  

            return View(product);
        }



        public IActionResult CurrentProduct(int id)
        {
            var product = _context.Products.Include(x => x.category).FirstOrDefault(x => x.ID == id);
            return View(product);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
