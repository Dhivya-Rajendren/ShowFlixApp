using System.Collections.Generic;

namespace ShowFlixApp.Models
{
    public interface IShowsRepository
    {
        List<Show> GetAllShows();
        Show GetShowById(int id);

        void AddNewShow(Show show);
        void DeleteShow(int showId);
    }
}
