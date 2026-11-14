namespace Entities
{
    public class User
    {

        //Tip: the property names must stay as they are, because the data file uses them. To read the data case-insensitively, look at PropertyNameCaseInsensitive
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }



    }
    public class Login
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
