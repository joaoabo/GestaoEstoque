﻿using Microsoft.AspNetCore.Mvc;

namespace GestaoEstoque.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
