using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarBook.WebApi.CustomValidations
{
    public class UserNameValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();
            var isDigit = int.TryParse(user.UserName![0].ToString(), out _);

            if (isDigit)
            {
                errors.Add(new() { Code = "UsernameStartsWithNumeric", Description = "Kullanıcı adı sayı ile başlayamaz"});
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
