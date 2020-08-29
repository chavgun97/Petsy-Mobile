namespace Petsy.Models
{
    public class ResultAuth
    {
        public bool isError { get; set; }
        public string UID { get; set; }
        public string Token { get; set; }
        public string ErrorMsg { get; set; }
        public string Name { get; set; }

    }
}