﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Controllers
{
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
