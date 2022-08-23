namespace Opendata.Models
{
    public class DailyTimetable
    {
        public string TrainDate { get; set; }

        public DailyTrain DailyTrainInfo { get; set; }

        public DateTime UpdateTime { get; set; }

        public List<StopTime> StopTimes { get; set; }

        public int VersionID { get; set; }
    }

    public class DailyTrain
    {
        public string TrainNo { get; set; }

        public byte Direction { get; set; }

        public string StartingStationID { get; set; }

        public StationName StartingStationName { get; set; }

        public string EndingStationID { get; set; }

        public StationName EndingStationName { get; set; }

        //public string Note { get; set; }
    }

    public class StationName
    {
        public string Zh_tw { get; set; }

        public string En { get; set; }
    }

    public class StopTime
    {
        public int StopSequence { get; set; }

        public string StationID { get; set; }

        public StationName StationName { get; set; }

        public string ArrivalTime { get; set; }

        public string DepartureTime { get; set; }
    }

    public class Auth
    {
        public string user { get; set; }

        public string password { get; set; }
    }

    public class OpendataToken
    {
        public string Token { get; set; }
    }

    public class JList
    {
        public string date { get; set; }

        public List<string> list { get; set; }
    }

    public class JParam
    {
        public string Token { get; set; }

        public string J { get; set; }
    }

    public class JDoc
    {
        public string JID { get; set; }

        public string JYEAR { get; set; }

        public string JCASE { get; set; }

        public string JNO { get; set; }

        public string JDATE { get; set; }

        public string JTITLE { get; set; }

        public JFULL JFULL { get; set; }
    }

    public class JFULL
    {
        public string JFULLTYPE { get; set; }

        public string JFULLCONTENT { get; set; }

        public string JFULLPDF { get; set; }
    }

}
