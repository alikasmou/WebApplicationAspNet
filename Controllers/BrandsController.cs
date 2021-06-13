using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ecommerce.Data;
using ecommerce.Models;
using ecommerce.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ecommerce.Controllers
{
    public class BrandsController : Controller
    {
        public ApplicationDbContext _ApplicationDbContext { get; set; }

        // this variable for uploading function
        private readonly IHostingEnvironment _hostingEnvironment;

        public BrandsController( ApplicationDbContext DbContext, IHostingEnvironment hostingEnvironment)
        {
            _ApplicationDbContext = DbContext;

            // uploading function constructor
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var ListBrands = _ApplicationDbContext.Brands.Where(brands => brands.IsDelete == false);

            var ListBrandsVm = ListBrands.Select(brand => new BrandsVm()
            {
                Id = brand.Id,
                Name = brand.BrnadName,
                CreateDate = brand.CreateDate,
                ImageId = brand.ImageId
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
            // upload function

            var NewBrand = new Brands()
            {
                BrnadName = brands.Name,
                Description = brands.Description
            };

            if (file.Length > 0)
            {
                var ImgId = "logo_"+brands.Name;
                // using file upload constructor
                var Uploads = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/img/{ImgId}.png");
                //var Uploads = Path.GetTempPath();
                using ( var Stream = System.IO.File.Create(Uploads))
                {
                    await file.CopyToAsync(Stream);
                }

                // add ImgId to the Brand Object
                NewBrand.ImageId = ImgId.ToString();

            }
            
            // insert into database
            await _ApplicationDbContext.Brands.AddAsync(NewBrand);
            await _ApplicationDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            var brandDb = await _ApplicationDbContext.Brands.FindAsync(id);

            var brand = new BrandsVm()
            {
                Id = brandDb.Id,
                Name = brandDb.BrnadName,
                Description = brandDb.Description,
                ImageId = brandDb.ImageId
            };
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( BrandsVm brand, IFormFile file )
        {

            //fetching the object from database
            var brandDb = _ApplicationDbContext.Brands.SingleOrDefault(x => x.Id == brand.Id);

            bool MoveFile = false;
            var Img = brandDb.ImageId;
            if (String.IsNullOrEmpty(Img))
            {
                Img = "logo_" + brand.Name + ".png";
            }
            else
            {
                //Img = "Updated_"+Img;
                MoveFile = true;
            }

            // Moving old img to trash to solve file existed error
            // Resource https://docs.microsoft.com/en-us/dotnet/api/system.io.file.move?view=net-5.0
            
            if (MoveFile)
            {
                var OldImagePath = "wwwroot/uploads/img/" + Img +".png";
                var SrcPath = OldImagePath.ToString();
                var TrashPath = "trash/";
                var DestPath = TrashPath.ToString();
                /* ERROR I couldn't Move it to trash */
                // System.IO.File.Move(SrcPath, DestPath, true);
                // So instead I will delete it
                System.IO.File.Delete(OldImagePath);
            }
            

            if (file.Length > 0 )
            {
                
                var Uploads = Path.Combine(_hostingEnvironment.WebRootPath,$"uploads/img/{Img}.png");
                using ( var Stream = System.IO.File.Create(Uploads))
                {
                    await file.CopyToAsync(Stream);
                }

                brandDb.ImageId = Img.ToString();
            }

            

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
