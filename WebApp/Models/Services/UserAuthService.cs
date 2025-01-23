using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Collections.Generic;
using System;

namespace WebApp.Models.Services
{
    public class UserAuthService
    {
        private readonly Dictionary<string, (string PasswordHash, string Salt)> _users = new Dictionary<string, (string, string)>();
        
        public bool Register(string username, string password)
        {
            if (_users.ContainsKey(username))
                return false; 
            
            var salt = GenerateSalt();
            
            var passwordHash = HashPassword(password, salt);

            _users.Add(username, (passwordHash, salt));
            return true;
        }
        
        public bool Authenticate(string username, string password)
        {
            if (_users.ContainsKey(username))
            {
                var (storedHash, storedSalt) = _users[username];
                return VerifyHashedPassword(storedHash, storedSalt, password);
            }

            return false; 
        }
        
        private string HashPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                Convert.FromBase64String(salt),
                KeyDerivationPrf.HMACSHA1,
                10000,
                256 / 8));
        }
        
        private bool VerifyHashedPassword(string hashedPassword, string salt, string password)
        {
            var hashedInputPassword = HashPassword(password, salt);
            return hashedPassword == hashedInputPassword;
        }
        
        private string GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }
        
        public bool IsAuthenticated(string username)
        {
            return _users.ContainsKey(username);
        }
    }
}
