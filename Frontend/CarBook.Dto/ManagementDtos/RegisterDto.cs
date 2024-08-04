using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ManagementDtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Lütfen geçerli bir ad soyad giriniz.")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Lütfen geçerli bir eposta adresi giriniz")]
        [Required(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli bir telefon giriniz.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Lütfen bir büyük harf,bir küçük harf ve bir sayı içeren bir şifre giriniz.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Lütfen aynı şifreyi giriniz.")]
        public string PasswordCheck { get; set; }
    }
}
