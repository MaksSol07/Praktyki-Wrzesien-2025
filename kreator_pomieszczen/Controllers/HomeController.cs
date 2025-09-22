using System.Diagnostics;
using kreator_pomieszczen.Data;
using kreator_pomieszczen.Models;
using Microsoft.AspNetCore.Mvc;

namespace kreator_pomieszczen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PomieszczeniaDbContext _context;

        public HomeController(ILogger<HomeController> logger, PomieszczeniaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pomieszczenia()
        {
            var wszystkiePomieszczenia = _context.Pomieszczenia.ToList();
            return View(wszystkiePomieszczenia);
        }

        public IActionResult UsunPomiszczenie(int id)
        {
            var pomieszczenieWDb = _context.Pomieszczenia.FirstOrDefault(pomieszczenie => pomieszczenie.Id == id);
            _context.Pomieszczenia.Remove(pomieszczenieWDb);
            _context.SaveChanges();
            return RedirectToAction("Pomieszczenia");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult KreatorPomieszczen(int? id)
        {
            if (id != null)
            {
                var pomieszczenieWDb = _context.Pomieszczenia.FirstOrDefault(pomieszczenie => pomieszczenie.Id == id);
                return View(pomieszczenieWDb);
            }

            return View();
        }

        public IActionResult KreatorPomieszczenForm(Pomieszczenie model)
        {
            if(model.Id == 0)
            {
                _context.Pomieszczenia.Add(model);
            } else
            {
                _context.Pomieszczenia.Update(model);
            }

            _context.SaveChanges();

            return RedirectToAction("Pomieszczenia");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
