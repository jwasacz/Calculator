using ASP.NETLab1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NETLab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Kuba";
            ViewBag.Godzina = DateTime.Now.Hour;
            ViewBag.Powitanie = ViewBag.Godzina < 16 ? "Dzień dobry" : "Dobry wieczór";

            Dane[] osoby =
            {
                new Dane{Name = "Jakub", Surname = "Wąsacz" },
                new Dane{Name = "Jan", Surname = "Wąski" },
                new Dane{Name = "Paweł", Surname = "Kowalski" }

            };

            return View(osoby);
        }

        public IActionResult Urodziny(Urodziny urodziny) 
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie}, Masz {DateTime.Now.Year - urodziny.Rok} lat!";
            return View();
        }

        public IActionResult Calculator(Calculator calc)
        {
            if (calc.tot == "+")
            {
                ViewBag.wynik = $" Wynik to: {calc.nu1 + calc.nu2}";
            }
            else if (calc.tot == "-")
            {
                ViewBag.wynik = $" Wynik to: {calc.nu1 - calc.nu2}";
            }
            else if (calc.tot == "*")
            {
                ViewBag.wynik = $" Wynik to: {calc.nu1 * calc.nu2}";
            }
            else if (calc.tot == "/")
            {
                ViewBag.wynik = $" Wynik to: {calc.nu1 / calc.nu2}";
            }

            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}