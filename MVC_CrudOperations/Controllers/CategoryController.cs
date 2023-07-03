using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CrudOperations.Data;

namespace MVC_CrudOperations.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext context;

        public CategoryController(ApplicationContext context)
        {
            this.context=context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await context.Categories.ToListAsync();
            return View(data);
        }
    }
}
