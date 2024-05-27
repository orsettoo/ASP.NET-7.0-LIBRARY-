using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebUygulamaProje1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int Ogrencino { get; set; }

        public string? Adres {  get; set; }

        public string? Fakulte { get; set; }

        public string? Bolum { get; set; }

       
    }
}
