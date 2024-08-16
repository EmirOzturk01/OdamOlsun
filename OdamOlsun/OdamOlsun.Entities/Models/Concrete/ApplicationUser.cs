using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OdamOlsun.Entities.Models.Concrete
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string? SocialInstagram { get; set; }

        public string? SocialSnapchat { get; set; }

        public ICollection<Ilan> Ilans { get; set; }
        
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}