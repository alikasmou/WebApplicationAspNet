using ecommerce.Data;
using ecommerce.Vm;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Controllers
{
    public class ItemsController : Controller
    {
        public ApplicationDbContext _ApplicationDbContext { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public ItemsController(ApplicationDbContext DbContext, IHostingEnvironment hostingEnvironment) 
        {
            _ApplicationDbContext = DbContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            var ListItems = _ApplicationDbContext.Items.Where(Items => Items.IsDelete == false);
            var ListItemsVm = ListItems.Select(Items => new ItemsVm()
            {

                Id = Items.Id,
                Name = Items.Name,
                Description = Items.Description,
                Price = Items.Price,
                Currency = Items.Currency,
                Category = Items.Categories.Name,
                Brand = Items.Brands.BrnadName



            });
            var SelectedRows = ListItemsVm;
            return View(SelectedRows);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ItemsVm Item)
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(ItemsVm Item, IFormFile file)
        {
            return View();
        }
        public IActionResult Trash()
        {
            return View();
        }




    }
}
