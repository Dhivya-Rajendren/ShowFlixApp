using Microsoft.AspNetCore.Mvc;
using ShowFlixApp.Models;
using System.Collections.Generic;

namespace ShowFlixApp.Controllers
{
    public class ShowsController : Controller
    {
        SQLServerShowRepository repo;
        public IActionResult Index()
        {
            repo = new SQLServerShowRepository();
            List<Show> shows = repo.GetAllShows();
          ViewBag.PageTitle = "Show Details From ShowFlix";
             return View(shows);
        }

        public IActionResult GetShow(int showId)
        {
            repo = new SQLServerShowRepository();
            Show show = repo.GetShowById(showId);
            return View(show);
        }
    
  public IActionResult DeleteShow(int showId)
        {
            repo = new SQLServerShowRepository();
            Show show = repo.GetShowById(showId);
            return View(show);
        }

        public IActionResult Yes(int showId)
        {
            repo = new SQLServerShowRepository();
            repo.DeleteShow(showId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateShow()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateShow(Show show)
        {
            repo = new SQLServerShowRepository();
            repo.AddNewShow(show);
            return RedirectToAction("Index");
        }
    }
}
