using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShowFlixApp.Models
{
    public class SQLServerShowRepository : IShowsRepository
    {
        string connectionString = "Server=Dhivya-pc\\Sqlexpress;Database=ShowFlixDB;integrated security= true;multipleActiveresultsets=true";

        SqlConnection con; 
        SqlCommand com;
        SqlDataReader reader;// Reading the data only 

        public SQLServerShowRepository()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }



        public void AddNewShow(Show show)
        {
            //DML -Insert , update,delete

            com = new SqlCommand("insert into ShowFlix values('" + show.ShowName + "','" + show.Category + "','" + show.Language + "','" + show.LeadActors + "','" + show.ShowImg + "')", con);
            com.ExecuteNonQuery();
        }

        public void DeleteShow(int showId)
        {
            throw new System.NotImplementedException();
        }

        public List<Show> GetAllShows()
        {
            com = new SqlCommand("Select * from showFlix", con);
            reader = com.ExecuteReader();
            List<Show> shows = new List<Show>();
            while(reader.Read())
                {
                Show show = new Show();
                show.ShowId = reader.GetInt32(0);
                show.ShowName = reader.GetString(1);
                show.Category = reader.GetString(2);
                show.Language = reader.GetString(3);
                show.LeadActors = reader.GetString(4);
                show.ShowImg = "/"+reader.GetString(5);
                shows.Add(show); 
            }
        
         
            return shows;
        }

        public Show GetShowById(int id)
        {
            Show show = GetAllShows().Find(x => x.ShowId == id);
           
            return show;
        }

        public List<ShowStreaming> ShowsStreaming()
        {
           if(con.State==System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
         
         SqlCommand   com1 = new SqlCommand("Select * from Showstreaming", con);
        SqlDataReader    reader1= com1.ExecuteReader();
            List<ShowStreaming> showStreamings = new List<ShowStreaming>();
            while (reader1.Read())
            {
                ShowStreaming streaming = new ShowStreaming();
                streaming.StreamId = reader1.GetInt32(0);
                streaming.Show = GetShowById(reader1.GetInt32(1));
                streaming.Period = reader1.GetString(2);
                streaming.ShowDateTime = reader1.GetDateTime(3);
                streaming.DurationInMinutes = reader1.GetInt32(4);
                showStreamings.Add(streaming);
            }
         

            return showStreamings;
        }
    }
}
