﻿namespace Application.Interfaces
{
    public interface ISecurePasswordHasher
    {
        /// <summary>
        /// Creates a hash from a password
        /// </summary>
        /// <param name="password">the password</param>
        /// <returns>the hash</returns>
        string Hash(string password);

        /// <summary>
        /// Check if hash is supported
        /// </summary>
        /// <param name="hashString">the hash</param>
        /// <returns>is supported?</returns>
        bool IsHashSupported(string hashString);

        /// <summary>
        /// verify a password against a hash
        /// </summary>
        /// <param name="password">the password</param>
        /// <param name="hashedPassword">the hash</param>
        /// <returns>could be verified?</returns>
        bool Verify(string password, string hashedPassword);
    }
}
