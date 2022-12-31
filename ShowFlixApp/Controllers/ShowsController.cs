using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowFlixApp.Models;
using System.Collections.Generic;
using System.IO;

namespace ShowFlixApp.Controllers
{
    public class ShowsController : Controller
    {
        SQLServerShowRepository repo;
        private readonly IHostingEnvironment environment;

        public ShowsController(IHostingEnvironment environment)
        {
            this.environment = environment;
        }
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
        public IActionResult CreateShow(Show show,IFormFile file)
        {
            string wwwPath = this.environment.WebRootPath;// wwwroot/

            string contentPath = Path.Combine(this.environment.WebRootPath, "images");
            string fileName = Path.GetFileName(file.FileName);
            using (FileStream stream = new FileStream(Path.Combine(contentPath, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
                show.ShowImg = "images/" + file.FileName;
            }

            repo = new SQLServerShowRepository();
            repo.AddNewShow(show);
            return RedirectToAction("Index");
        }
    }
}
