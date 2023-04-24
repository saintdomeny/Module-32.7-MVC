using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Module_32._7_MVC.Models;
using Module_32._7_MVC.Models.Db;
using Module_32._7_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Module_32._7_MVC.Controllers
{
    public class FeedbackController : Controller
    {
        /// <summary>
        ///  Метод, возвращающий страницу с отзывами
        /// </summary>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Метод для Ajax-запросов
        /// </summary>
        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
