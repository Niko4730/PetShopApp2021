using MySecurity.Entities;

namespace MySecurity.Authentication
{
    public interface IAuthenticationHelper
    {
        /// <summary>
        /// Create a hash of the given password. Will return both hash and the salt used.
        /// </summary>
        /// <param name="password">The original password</param>
        /// <param name="passwordHash">The hash of the password</param>
        /// <param name="passwordSalt">The salt use in the hashing process of the password</param>
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        
        /// <summary>
        /// Verifies if a given password matches a given hash using the given salt 
        /// </summary>
        /// <param name="password">The original password</param>
        /// <param name="storedHash">The hash of the password + salt</param>
        /// <param name="storedSalt">The salt to use</param>
        /// <returns>True if the hash and password+salt matches, false otherwise</returns>
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
        
        /// <summary>
        /// Generate a fresh token for the user to use
        /// </summary>
        /// <param name="user">The user requesting a token</param>
        /// <returns>The token for the user</returns>
        string GenerateToken(AppUser user);
    }
}
