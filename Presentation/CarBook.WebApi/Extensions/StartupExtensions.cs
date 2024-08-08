using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.WebApi.CustomValidations;

namespace CarBook.WebApi.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityExt(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
            })
            .AddPasswordValidator<PasswordValidator>()
            .AddUserValidator<UserNameValidator>()
            .AddEntityFrameworkStores<CarBookContext>();
        }
    }
}
