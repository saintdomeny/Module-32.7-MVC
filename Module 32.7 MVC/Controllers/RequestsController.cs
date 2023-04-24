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
    public class RequestsController : Controller
    {
        private readonly IRequestRepository _repo;

        public RequestsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _repo.GetRequests();
            return View(requests);
        }
    }
}
