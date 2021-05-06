﻿using Microsoft.AspNetCore.Mvc;
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
            var ListBrands = _ApplicationDbContext.Brands.Where(x => x.IsDelete == false)
                .Select(x=> new BrandsVm()
                {
                    Id = x.Id,
                    Name = x.BrnadName,
                    CreateDate = x.CreateDate

                })
                .ToList();
            return View(ListBrands);
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

    }
}
