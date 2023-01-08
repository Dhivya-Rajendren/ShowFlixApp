using Microsoft.AspNetCore.Mvc;
using ShowFlixApp.Models;
using System.Threading.Tasks;

namespace ShowFlixApp.ViewComponents
{
    public class ShowViewComponent:ViewComponent
    {
        SQLServerShowRepository repo = new SQLServerShowRepository();
        public IViewComponentResult Invoke(int showId,string viewName)
        {
            ViewData["ViewName"] = viewName;
            return  View(repo.GetShowById(showId));
        }
    }
}
