using System;
using System.Linq;
using System.Security.Cryptography;

namespace CPRG005.Final.BLL.Services
{
    public interface IHashingService
    {
        bool CheckHash(string hash, string password);
    }

    /// <summary>
    /// Plagarism note
    /// I honestly don't remember where I found this code snippet, but it was some tutorial on hashing.
    /// I didn't write this from scratch, although I did modify it a bit.
    /// </summary>
    public sealed class HashingService : IHashingService
    {
        private const int KeySize = 32; // 256 bit

        public bool CheckHash(string hash, string password)
        {
            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format. " +
                  "Should be formatted as `{iterations}.{salt}.{hash}`");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              salt,
              iterations,
              HashAlgorithmName.SHA512))
            {
                var keyToCheck = algorithm.GetBytes(KeySize);

                var verified = keyToCheck.SequenceEqual(key);

                return verified;
            }
        }
    }
}
