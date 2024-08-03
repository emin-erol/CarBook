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
        public ManagementsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto request)
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
    }
}
