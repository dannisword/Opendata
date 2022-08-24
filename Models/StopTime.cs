namespace Opendata.Models
{
    public class StopTime
    {
        public int StopSequence { get; set; }

        public string StationID { get; set; }

        public StationName StationName { get; set; }

        public string ArrivalTime { get; set; }

        public string DepartureTime { get; set; }
    }
}