namespace TVShowsAPI.Models
{
    public class User
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } // User's name
        public string Email { get; set; } // User's email
        public string Password { get; set; } // User's password (store securely in production)
    }
}
