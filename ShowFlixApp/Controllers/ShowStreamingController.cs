using Microsoft.AspNetCore.Mvc;
using ShowFlixApp.Models;

namespace ShowFlixApp.Controllers
{
    public class ShowStreamingController : Controller
    {
        SQLServerShowRepository repo = new SQLServerShowRepository();
        public IActionResult Index()
        {
           
            return View(repo.ShowsStreaming());
        }

        public IActionResult StreamingDetail(int streamId)
        {
            ShowStreaming streaming = repo.ShowsStreaming().Find(r => r.StreamId == streamId);
            return View(streaming);
        }

        public IActionResult DeleteStreaming(int streamId)
        {
            ShowStreaming streaming = repo.ShowsStreaming().Find(r => r.StreamId == streamId);
            return View(streaming);
        }
    }
}
