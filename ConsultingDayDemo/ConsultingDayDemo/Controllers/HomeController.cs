﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConsultingDayDemo.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using ConsultingDayDemo.CloudinaryHelper;

namespace ConsultingDayDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Cloudinary cloudinary;

        public HomeController(ILogger<HomeController> logger,Cloudinary cloudinary)
        {
            _logger = logger;
            this.cloudinary = cloudinary;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            var result = await CloudinaryExtension.UploadAsync(this.cloudinary,files);

            this.ViewBag.links = result;

            return Redirect("/");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
