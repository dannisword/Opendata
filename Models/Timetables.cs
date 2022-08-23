using System;

namespace Opendata.Models
{
    public class Timetables
    {
        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string[] TrainDates { get; set; }
    }
}