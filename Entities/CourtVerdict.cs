using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Opendata.Entities
{
    [Table("CourtVerdict")]
    public class CourtVerdict
    {
        [Key]
        public int Seq { get; set; }

        public string JID { get; set; }

        public string JYear { get; set; }

        public string JCase { get; set; }

        public string JNo { get; set; }

        public string JDate { get; set; }

        public string JTitle { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateUser { get; set; }

        public DateTime ModifyTime { get; set; }

        public int ModifyUser { get; set; }


    }
}