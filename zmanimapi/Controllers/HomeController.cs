﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace zmanimapi.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult spa()
        {
            return File("~/index.html","text/html");
        }
    }
}