using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarBook.WebApi.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new() { Code = "PasswordContainUsername", Description = "Şifre içinde kullanıcı adı bulunamaz" });
            }

            if (password!.ToLower().StartsWith("123"))
            {
                errors.Add(new() { Code = "PasswordStartsWith123", Description = "Şifre ardışık sayı ile başlayamaz" });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
