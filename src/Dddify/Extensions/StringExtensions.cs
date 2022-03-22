using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace System
{
    /// <summary>
    /// This class is used to provide <see cref="string"/> type extension method.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether the current string is null or an <see cref="string.Empty"/> string.
        /// </summary>
        /// <param name="target">The string to indicate.</param>
        /// <returns>true if the current string is null or an empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }

        /// <summary>
        /// Splits the current string into substrings based on the string in an array.
        /// </summary>
        /// <param name="target">The string to split.</param>
        /// <param name="separator">The separator string, default is comma.</param>
        /// <returns>An array whose elements contain the substrings in this string that are delimited by a separator.</returns>
        public static string[] ToArray(this string target, string separator = ",")
        {
            return target.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Computes the hash value for the current string.
        /// </summary>
        /// <param name="target">The string to compute.</param>
        /// <param name="length">The length to output.</param>
        /// <returns>The computed hash code from the string.</returns>
        public static string ComputeHash(this string target, int length = 32)
        {
            if (length != 32 && length != 16)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            using (var md5 = new MD5CryptoServiceProvider())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(target));

                if (length == 16)
                {
                    return BitConverter.ToString(bytes, 4, 8).Replace("-", string.Empty).ToLower();
                }
                if (length == 32)
                {
                    var result = new StringBuilder();
                    foreach (byte t in bytes)
                    {
                        result.Append(t.ToString("x2"));
                    }
                    return result.ToString();
                }
            }

            return null;
        }

        /// <summary>
        /// Converts the first character of a string to lowercase.
        /// </summary>
        /// <param name="target">The string to convert.</param>
        /// <returns>The converted string.</returns>
        public static string ToCamelCase(this string target)
        {
            if (!string.IsNullOrEmpty(target) && target.Length > 1)
            {
                return char.ToLowerInvariant(target[0]) + target[1..];
            }
            return target;
        }
    }
}
