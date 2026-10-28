namespace APIproj.Controllers
{
    //In C#, public properties are written in PascalCase (Id, UserName, Password, FirstName, LastName).
    //If you rename them, file.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    public class User
    {
        
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }



    }
}
