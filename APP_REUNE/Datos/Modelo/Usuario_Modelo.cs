 

namespace Datos.Modelo
{
    public class TokenResponse
    {
        public string Message { get; set; }
        public TokenData Data { get; set; }
    }

    public class TokenData
    {
        public string TokenAccess { get; set; }
    }

    public class LoginResponse
    {
        public string Msg { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public string TokenAccess { get; set; }
        public string Username { get; set; }
    }
}
