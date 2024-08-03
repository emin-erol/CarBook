using CarBook.Dto.ManagementDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ManagementController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ManagementController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterDto request)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(request);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7239/api/Managements", stringContent);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Kayıt İşlemi Başarılı";
                return RedirectToAction("Register");
            }

            return View();
        }
    }
}
