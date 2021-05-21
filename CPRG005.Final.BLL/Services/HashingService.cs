using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace CPRG005.Final.BLL.Services
{
    public interface IHashingService
    {
        string Hash(string password);
        bool Check(string hash, string password);
    }

    /// <summary>
    /// Plagarism note
    /// I honestly don't remember where I found this code snippet, but it was some tutorial on jwt tokens.
    /// I didn't write this from scratch, although I did modify it a bit.
    /// </summary>
    public sealed class HashingService : IHashingService
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit

        public HashingService(IOptions<HashingOptions> options)
        {
            Options = options.Value;
        }

        private HashingOptions Options { get; }

        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              SaltSize,
              Options.Iterations,
              HashAlgorithmName.SHA512))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{Options.Iterations}.{salt}.{key}";
            }
        }

        public bool Check(string hash, string password)
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

    public sealed class HashingOptions
    {
        public int Iterations { get; set; } = 10000;
    }
}
