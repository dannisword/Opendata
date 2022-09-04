using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("JUList")]
public class JUList
{
    [Key]
    public int ID { get; set; }

    public DateTime ListDate { get; set; }

    public string ListItem { get; set; }

    public DateTime CreateTime { get; set; }

    public int CreateUser { get; set; }

    public DateTime ModifyTime { get; set; }

    public int ModifyUser { get; set; }

}