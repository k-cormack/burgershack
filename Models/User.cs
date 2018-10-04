using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace burgershack.Models
{
    public class UserLogin //HELPER MODEL
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
    public class UserRegistration //HELPER MODEL
    {
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
    public class User
    {
        public string Id { get; set; }
        public bool Active { get; set; } = true;
        [Required]
        public string UserName { get; set; }
        [Required]
        internal string Hash { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ClaimsPrincipal _principal { get; private set; } //IS ESSENTIALLY THE JSON WEB TOKEN(JWT)

        internal void SetClaims()
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, Id), //req.session.uid = id in .js
          };
          var userIdentity = new ClaimsIdentity(claims, "Login");
          _principal = new ClaimsPrincipal(userIdentity);
        }
    }
}