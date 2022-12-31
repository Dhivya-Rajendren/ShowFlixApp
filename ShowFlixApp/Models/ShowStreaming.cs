using System;

namespace ShowFlixApp.Models
{
    public class ShowStreaming
    {
        public int StreamId { get; set; }
        public Show Show{ get; set; }
        public string Period { get; set; }

        public DateTime ShowDateTime { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
