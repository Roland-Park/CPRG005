using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace CPRG005.Final.Roland.Helpers
{
    public interface IHashingHelper
    {
        string Hash(string password);
    }

    /// <summary>
    /// Plagarism note
    /// I honestly don't remember where I found this code snippet, but it was some tutorial on hashing.
    /// I didn't write this from scratch, although I did modify it a bit.
    /// </summary>
    public sealed class HashingHelper : IHashingHelper
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit

        public HashingHelper(IOptions<HashingOptions> options)
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
    }

    public sealed class HashingOptions
    {
        public int Iterations { get; set; } = 10000;
    }
}
