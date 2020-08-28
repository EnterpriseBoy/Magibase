namespace MagiApi.Models.User
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool RememberLogin { get; set; }
    }
}
