namespace LibraryTeamWinFormApp.Core.Models
{
    public class UserInfo
    {
        public int Id { get; }
        public string Name { get; }
        public string Password { get; }
        public string Rights { get; }

        public UserInfo(int id, string name, string password, string rights)
        {
            Id = id;
            Name = name;
            Password = password;
            Rights = rights;
        }
    }
}