using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LearningMVC.Security
{
    public class MD5Hasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
                return md5.ComputeHash(Encoding.ASCII.GetBytes(password))
                          .Select(x => x.ToString("X2"))
                          .Aggregate((ag, s) => ag + s);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return HashPassword(providedPassword) == hashedPassword ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}