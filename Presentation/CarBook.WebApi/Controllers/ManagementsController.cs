using CarBook.Application.Interfaces.ManagementInterfaces;
using CarBook.Application.ViewModels.ManagementViewModels;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementsController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IManagementRepository _managementRepository;
        public ManagementsController(SignInManager<AppUser> signInManager, IManagementRepository managementRepository)
        {
            _signInManager = signInManager;
            _managementRepository = managementRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel request)
        {
            if (ModelState.IsValid)
            {
                (bool, AppUser) result = await _managementRepository.Register(request);

                if (result.Item1)
                {
                    return Ok("Kayıt işlemi başarılı.");
                }

                return BadRequest("Kayıt işlemi başarısız.");

            }
            return BadRequest("Geçersiz model.");
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

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _managementRepository.GetAllUsers();
            if (users.Any())
            {
                return Ok(users);
            }
            
            return BadRequest("Hiçbir kullanıcı bulunamadı.");
        }
    }
}
