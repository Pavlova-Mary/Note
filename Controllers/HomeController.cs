using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Note> notes = new List<Note>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] Note note)
        {
            notes.Add(note);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View(notes.Where(x => x.Id == id).FirstOrDefault());
        }

        public IActionResult Delete(int id)
        {

            return View(notes.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Delete(int Id, Note note)
        {
            var n = notes.Where(x => x.Id == Id).FirstOrDefault();

            notes.Remove(n); ;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int Id, [FromForm] Note note)
        {
            var w = notes.Where(x => x.Id == Id).FirstOrDefault();
            w.Text = note.Text;
            w.Created = note.Created;
            w.IsCurrent = note.IsCurrent;

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
