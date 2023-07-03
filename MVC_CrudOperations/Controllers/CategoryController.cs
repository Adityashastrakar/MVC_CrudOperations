using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CrudOperations.Data;
using MVC_CrudOperations.Models;

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
        public async Task<IActionResult> AddCategory(int? id)
        {
            Category category=new Category();
            if (id == null&& id!=0)
            {
                category = await context.Categories.FindAsync(id);
            }

            return View(category);
        }
        [HttpPost]

        public async Task<IActionResult> AddCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                if (category.CategoryId==0)
                {
                    await context.Categories.AddAsync(category);
                    await context.SaveChangesAsync();
                    TempData["success"]="Category Added";
                }
                else
                {
                    context.Categories.Update(category);
                    TempData["success"]="Category Updated";
                }
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id !=0)
            {
                bool status=context.Products.Any(x=>x.CategoryId==id);
                if(status)
                {
                    TempData["Warning"]="Category product is available";
                }
                else
                {
                    var category = await context.Categories.FindAsync(id);
                    if(category==null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        context.Categories.Remove(category);
                        await context.SaveChangesAsync();
                        TempData["success"] = "Category Deleted Successfuly";
                    }
                }
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }
    }
}
 