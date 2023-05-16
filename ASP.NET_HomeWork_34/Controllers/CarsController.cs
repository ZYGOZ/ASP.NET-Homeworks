using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using ASP.NET_HomeWork_3.Models;

namespace ASP.NET_HomeWork_3.Controllers
{
    public class CarsController : Controller
    {
        public List<CarModel>? Data { get; set; }

        public CarsController()
        {
            Data.Add(new CarModel() { Id=1, Email = "2", Password="2323", ConfirmPassword="2323"});
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var users = Data;


            return View(users);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auth/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,ConfirmPassword")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                Data.Add(carModel);
                return RedirectToAction(nameof(Index));
            }
            return View(carModel);
        }

    }
}
