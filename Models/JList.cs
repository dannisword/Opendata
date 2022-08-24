namespace Opendata.Models
{
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