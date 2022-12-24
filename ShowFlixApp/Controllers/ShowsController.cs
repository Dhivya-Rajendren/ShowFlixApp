using Microsoft.AspNetCore.Mvc;
using ShowFlixApp.Models;
using System.Collections.Generic;

namespace ShowFlixApp.Controllers
{
    public class ShowsController : Controller
    {
        ShowsRepository repo;
        public IActionResult Index()
        {
            repo = new ShowsRepository();
            List<Show> shows = repo.GetAllShows();
          ViewBag.PageTitle = "Show Details From ShowFlix";
             return View(shows);
        }

        public IActionResult GetShow(int showId)
        {
            repo = new ShowsRepository();
            Show show = repo.GetShowById(showId);
            return View(show);
        }
    
  public IActionResult DeleteShow(int showId)
        {
            repo = new ShowsRepository();
            Show show = repo.GetShowById(showId);
            return View(show);
        }

        public IActionResult Yes(int showId)
        {
            repo = new ShowsRepository();
            repo.DeleteShow(showId);
            return RedirectToAction("Index");
        }

        public IActionResult CreateShow()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateShow(Show show)
        {
            repo = new ShowsRepository();
            repo.AddNewShow(show);
            return RedirectToAction("Index");
        }
    }
}
