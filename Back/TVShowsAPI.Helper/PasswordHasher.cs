namespace TVShowsAPI.Helper
{
    public class PasswordHasher
    {
        public static string HashPassword ( string password )
        {
            // Hashea la contraseña utilizando BCrypt con un "work factor" de 12
            return BCrypt.Net.BCrypt.HashPassword ( password , workFactor: 12 );
        }

        public static bool VerifyPassword ( string password , string hashedPassword )
        {
            // Verifica si la contraseña coincide con el hash
            return BCrypt.Net.BCrypt.Verify ( password , hashedPassword );
        }
    }
}
