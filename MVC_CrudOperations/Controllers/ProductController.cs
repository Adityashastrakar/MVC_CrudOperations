using Microsoft.AspNetCore.Mvc;
using MVC_CrudOperations.Data;
using MVC_CrudOperations.Models;
using MVC_CrudOperations.Models.ViewModel;

namespace MVC_CrudOperations.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext context;
        public ProductController(ApplicationContext context)
        { 
            this.context = context;
        }
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            ProductCategoryListViewModel prd = new ProductCategoryListViewModel();
            var prdData = context.Products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            var catData = context.Categories.ToList();
            prd.products = prdData;
            prd.categories = catData;
            return View(prd);
        }
       

        [HttpPost]

        public async Task<IActionResult> AddProduct()
        {
            ViewBag.department = context.Products.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCategoryListViewModel productCategory)
        {
            return View();
        }
    }
}

    

