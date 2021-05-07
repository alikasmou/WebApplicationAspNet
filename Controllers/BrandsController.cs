using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Models;
using ecommerce.Vm;
using Microsoft.AspNetCore.Http;

namespace ecommerce.Controllers
{
    public class BrandsController : Controller
    {
        public ApplicationDbContext _ApplicationDbContext { get; set; }

        public BrandsController( ApplicationDbContext DbContext)
        {
            _ApplicationDbContext = DbContext;
        }

        public IActionResult Index()
        {
            /*var ListBrands = _ApplicationDbContext.Brands.Where(x => x.IsDelete == false)
                .Select(x=> new BrandsVm()
                {
                    Id = x.Id,
                    Name = x.BrnadName,
                    CreateDate = x.CreateDate

                })
                .ToList();
            */
            var ListBrands = _ApplicationDbContext.Brands.Where(brands => brands.IsDelete == false);

            var ListBrandsVm = ListBrands.Select(brand => new BrandsVm()
            {
                Id = brand.Id,
                Name = brand.BrnadName,
                CreateDate = brand.CreateDate
            });

            var SelectedRows = ListBrandsVm;
            return View(SelectedRows);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( BrandsVm brands, IFormFile file)
        {

            var NewBrand = new Brands()
            {
                BrnadName = brands.Name,
                Description = brands.Description
            };
            await _ApplicationDbContext.Brands.AddAsync(NewBrand);
            await _ApplicationDbContext.SaveChangesAsync();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            /*
            var brand = _ApplicationDbContext.Brands.SingleOrDefault( brand => brand.Id == id);

            OR 
            
            var brand = _ApplicationDbContext.Brands.FirstOrDefault(brand=> brand.Id == id);
            
            Notes :
            *but if query returns more than 1 row you will get an error
            ** in these cases function must be public IActionResult Edit()
             * No need to async Task<>
            
            */
            var brandDb = await _ApplicationDbContext.Brands.FindAsync(id);

            var brand = new BrandsVm()
            {
                Id = brandDb.Id,
                Name = brandDb.BrnadName,
                Description = brandDb.Description
            };
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( BrandsVm brand)
        {
            //fetching the object from database
            var brandDb = _ApplicationDbContext.Brands.SingleOrDefault(x => x.Id == brand.Id);
            brandDb.BrnadName = brand.Name;
            brandDb.LastModify = DateTime.Now;
            brandDb.Description = brand.Description;
            await
            _ApplicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Trash(int id)
        {

            // get the object from database
            var brandDb = _ApplicationDbContext.Brands.SingleOrDefault(x=> x.Id == id);
            brandDb.IsDelete = true;
            await _ApplicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Trashed()
        {

            var ListBrands = _ApplicationDbContext.Brands.Where(brands => brands.IsDelete == true);

            var ListBrandsVm = ListBrands.Select(brand => new BrandsVm()
            {
                Id = brand.Id,
                Name = brand.BrnadName,
                CreateDate = brand.CreateDate
            });

            var SelectedRows = ListBrandsVm;
            return View(SelectedRows);
        }

        public async Task<IActionResult> Restore(int id)
        {

            // get the object from database
            var brandDb = _ApplicationDbContext.Brands.SingleOrDefault(x => x.Id == id);
            brandDb.IsDelete = false;
            await _ApplicationDbContext.SaveChangesAsync();
            return RedirectToAction("Trashed");
        }

        public async Task<IActionResult> Drop(int id)
        {

            // get the object from database
            var brandDb = _ApplicationDbContext.Brands.SingleOrDefault(x => x.Id == id);

            _ApplicationDbContext.Remove(brandDb);
            await _ApplicationDbContext.SaveChangesAsync();
            return RedirectToAction("Trashed");


        }



    }
}
