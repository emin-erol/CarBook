using CarBook.Application.ViewModels.ManagementViewModels;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.ManagementInterfaces
{
    public interface IManagementRepository
    {
        Task<AppUser> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        Task<(bool, AppUser)> Login(LoginViewModel model);
    }
}
