using CarBook.Application.Interfaces.ManagementInterfaces;
using CarBook.Application.ViewModels.ManagementViewModels;
using CarBook.Domain.Entities;
using CarBook.Dto.ManagementDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IManagementRepository _managementRepository;
        public ManagementsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IManagementRepository managementRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _managementRepository = managementRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel request)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _userManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email }, request.Password);

                if (identityResult.Succeeded)
                {
                    return Ok("Kayıt işlemi başarılı.");
                }

                return BadRequest(identityResult.Errors);
            }
            return BadRequest("Invalid model");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            if (!string.IsNullOrEmpty(request.Email))
            {
                var model = await _managementRepository.Login(request);
                if (model.Item1)
                {
                    await _signInManager.SignInAsync(model.Item2, isPersistent: false);
                    return Ok("Giriş işlemi başarılı.");
                }
                else
                {
                    return BadRequest("Giriş işlemi başarısız.");
                }
            }
            return Unauthorized("Email bulunamadı.");
        }
    }
}
