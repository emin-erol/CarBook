using CarBook.Dto.ManagementDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminManagement")]
    public class AdminManagementController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminManagementController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("UserList")]
        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7239/api/Managements/GetAllUsers");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<UserDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
