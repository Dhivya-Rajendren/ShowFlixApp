using System.Collections.Generic;

namespace ShowFlixApp.Models
{
    public class ShowsRepository : IShowsRepository
    {
        private static List<Show> _showList = new List<Show>()
        {
             new Show() { ShowId = 1, ShowName = "Fall", Language = "Hindi", Category = "Thriller", LeadActors = "Anjali,Prem" ,ShowImg="/images/Fall.jpg"},
new Show() { ShowId = 2, ShowName = "Bilions", Language = "English", Category = "Money", LeadActors = "Methoew,Josh" ,ShowImg="/images/Billions.jpg"},
new Show() { ShowId = 3, ShowName = "the BigBang Theory", Language = "English", Category = "Comedy", LeadActors = "Julie,Grey" ,ShowImg="/images/BigBangtheory.jpg"}

    };

        public void AddNewShow(Show show)
        {
            int count = _showList.Count;
            count++;
            show.ShowId = count;

            _showList.Add(show);
        }

        public List<Show> GetAllShows()
        {
          return _showList;
        }

        public Show GetShowById(int id)
        {
          Show show= _showList.Find(x => x.ShowId == id);
            return show;
        }

        public void DeleteShow(int showId)
        {
            Show show = _showList.Find(x => x.ShowId == showId);
            _showList.Remove(show);


        }

        public List<ShowStreaming> ShowsStreaming()
        {
            throw new System.NotImplementedException();
        }
    }
}
