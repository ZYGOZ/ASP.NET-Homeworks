using ASP.NET_HomeWork_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_HomeWork_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<CarModel>? Data { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Data = new List<CarModel>
            {
                new CarModel { Id = 1, Email = "2", Password = "2323", ConfirmPassword = "2323" }
            };
        }

        public IActionResult Index()
        {
            return View();
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

        // GET: Auth
        public async Task<IActionResult> Cars()
        {
            var users = Data;


            return View(users);
        }

        // GET: Auth/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auth/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCar([Bind("Id,Email,Password,ConfirmPassword")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                Data.Add(carModel);
                return RedirectToAction(nameof(Cars));
            }
            return View(carModel);
        }
    }
}