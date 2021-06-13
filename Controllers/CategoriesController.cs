using ecommerce.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Vm;
using ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class CategoriesController : Controller
    {
        public ApplicationDbContext _applicationDbContext { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public CategoriesController( ApplicationDbContext DbContext, IHostingEnvironment hostingEnvironment) {
            _applicationDbContext = DbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var ListCategories = _applicationDbContext.Categories.Include(x=> x.Parent).Where( categories => categories.IsDelete == false);

            var ListCategoriesVm = ListCategories.Select(Categories => new CategoriesVm()
            {

                Id = Categories.Id,
                Name = Categories.Name,
                CreatedAt = Categories.CreateDate,
                ParentId = Categories.ParentId,
                Description = Categories.Description,
                ShortDescription = Categories.ShortDescription,
                ParentName = Categories.Parent.Name

            }) ;
            var SelectedRows = ListCategoriesVm;
            return View(SelectedRows);
        }

        public IActionResult Create() 
        {
            ViewBag.ListParentCategories = _applicationDbContext.Categories.Where( Category=> Category.IsDelete == false).Select( Category=> new SelectListItem() { Text = Category.Name, Value = Category.Id.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriesVm Category)
        {
            var NewCategory = new Categories()
            {
                Name = Category.Name,
                ParentId = Category.ParentId,
                ShortDescription = Category.ShortDescription,
                Description = Category.Description

            };
            await _applicationDbContext.Categories.AddAsync(NewCategory);
            await _applicationDbContext.SaveChangesAsync();


            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id) 
        {

            ViewBag.ListParentCategories = _applicationDbContext.Categories.Where(Category => Category.IsDelete == false).Select(Category => new SelectListItem() { Text = Category.Name, Value = Category.Id.ToString() }).ToList();

            var CategoryDb = await _applicationDbContext.Categories.FindAsync(id);

            var Category = new CategoriesVm()
            {
                Id = CategoryDb.Id,
                Name = CategoryDb.Name,
                Description = CategoryDb.Description,
                ShortDescription = CategoryDb.ShortDescription,
                ParentId = CategoryDb.ParentId,
                CategoryImage = CategoryDb.CategoryImage
            };

            return View(Category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriesVm Category) {


            var CategoryDb = _applicationDbContext.Categories.SingleOrDefault(x => x.Id == Category.Id);
            CategoryDb.Name = Category.Name;
            CategoryDb.ParentId = Category.ParentId;
            CategoryDb.ShortDescription = Category.ShortDescription;
            CategoryDb.Description = Category.Description;
            await _applicationDbContext.SaveChangesAsync();


            return RedirectToAction("Index");

        }

        public IActionResult Trashed() 
        {
            return View();
        }


    }
}
